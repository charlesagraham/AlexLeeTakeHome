namespace AlexLeeTakeHomeConsole;

public class DirectorySearcher
{
	Lock _foundLinesLock = new Lock();
	Lock _numberOfLinesSearchTextFound = new Lock();
	Lock _numberOfOccurrencesSearchTextFound = new Lock();

	public async Task<DirectorySearcherResults> SearchDirectory(string directoryPath, string searchText, string destinationPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
		}

		
		//Assumption: We are making the assumption that we are only searching the top level of the directory
		var files = Directory.GetFiles(directoryPath, "*", SearchOption.TopDirectoryOnly);
		var results = new DirectorySearcherResults
		{
			NumberOfFilesProcessed = files.Length
		};

		List<Task> tasks = new List<Task>();
		foreach (var filenamePath in files)
		{
			tasks.Add(Task.Run(() => ProcessDirectory(filenamePath, searchText, results))); ;
		}

		Task.WaitAll(tasks);

		File.WriteAllLines(destinationPath, results.FoundLines);

		Console.WriteLine($"NumberOfFilesProcessed: {results.NumberOfFilesProcessed}");
		Console.WriteLine($"NumberOfLinesSearchTextFound: {results.NumberOfLinesSearchTextFound}");
		Console.WriteLine($"NumberOfOccurrencesSearchTextFound: {results.NumberOfOccurrencesSearchTextFound}");

		return results;
	}

	public Task ProcessDirectory(string filenamePath, string searchText, DirectorySearcherResults results)
	{
		var lines = File.ReadAllLines(filenamePath);
		foreach (var line in lines)
		{
			//Assumption: we are ignoring case when searching for the text
			if (line.Contains(searchText, StringComparison.OrdinalIgnoreCase))
			{
				lock (_foundLinesLock)
				{
					results.FoundLines.Add(line);
				}

				lock (_numberOfLinesSearchTextFound)
				{
					results.NumberOfLinesSearchTextFound++;
				}
				
				int index = 0;
				while ((index = line.IndexOf(searchText, index, StringComparison.OrdinalIgnoreCase)) != -1)
				{
					lock (_numberOfOccurrencesSearchTextFound)
					{
						results.NumberOfOccurrencesSearchTextFound++;
					}

					index += searchText.Length;
				}
			}
		}

		return Task.CompletedTask;
	}
}

