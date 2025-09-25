namespace AlexLeeTakeHomeConsole;

public class DirectorySearcher
{
	public DirectorySearcherResults SearchDirectory(string directoryPath, string searchText, string destinationPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
		}

		var results = new DirectorySearcherResults();

		//Assumption: We are making the assumption that we are only searching the top level of the directory
		var files = Directory.GetFiles(directoryPath, "*", SearchOption.TopDirectoryOnly);
		
		results.NumberOfFilesProcessed = files.Length;
		
		foreach (var filenamePath in files)
		{
			ProcessDirectory(filenamePath, searchText, results);
		}

		File.WriteAllLines(destinationPath, results.FoundLines);

		Console.WriteLine($"NumberOfFilesProcessed: {results.NumberOfFilesProcessed}");
		Console.WriteLine($"NumberOfLinesSearchTextFound: {results.NumberOfLinesSearchTextFound}");
		Console.WriteLine($"NumberOfOccurrencesSearchTextFound: {results.NumberOfOccurrencesSearchTextFound}");

		return results;
	}

	public void ProcessDirectory(string filenamePath, string searchText, DirectorySearcherResults results)
	{
		var lines = File.ReadAllLines(filenamePath);
		foreach (var line in lines)
		{
			//Assumption: we are ignoring case when searching for the text
			if (line.Contains(searchText, StringComparison.OrdinalIgnoreCase))
			{
				//todo: put locks here if we are doing this in parallel
				results.FoundLines.Add(line);
				results.NumberOfLinesSearchTextFound++;

				int index = 0;
				while ((index = line.IndexOf(searchText, index, StringComparison.OrdinalIgnoreCase)) != -1)
				{
					results.NumberOfOccurrencesSearchTextFound++;
					index += searchText.Length;
				}
			}
		}
	}
}

