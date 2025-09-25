namespace AlexLeeTakeHomeConsole;

public class DirectorySearcherResults
{
	public int NumberOfFilesProcessed { get; set; }
	public int NumberOfLinesSearchTextFound { get; set; }
	public int NumberOfOccurrencesSearchTextFound { get; set; }
	public List<string> FoundLines { get; set; } = new List<string>();
}