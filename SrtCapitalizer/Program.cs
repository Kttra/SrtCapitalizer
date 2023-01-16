// Create a list to store the file paths
List<string> filePaths = new List<string>();

// Get the file paths of all .srt files in the current directory
string[] paths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.srt");

foreach (string filePath in paths)
{
    // Read the lines of the file
    string[] lines = File.ReadAllLines(filePath);

    for (int i = 0; i < lines.Length; i++)
    {
        string line = lines[i];

        if (!string.IsNullOrEmpty(line) &&
            !line.Contains("-->"))
        {
            // Capitalize the first letter of the line
            lines[i] = char.ToUpper(line[0]) + line.Substring(1);
        }
    }

    // Write the capitalized lines back to the file
    File.WriteAllLines(filePath, lines);

    // Add the file path to the list
    filePaths.Add(filePath);
}

// Print the list of file paths
Console.WriteLine("The following .srt files were edited: ");
foreach (string filePath in filePaths)
{
    Console.WriteLine(filePath);
}
if (filePaths.Count == 0)
{
    Console.WriteLine("No files were edited.");
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();