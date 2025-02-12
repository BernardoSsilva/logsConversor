using LogsConversor.classes;

class Program
{


    static void Main(string[] args) {
        Console.WriteLine("Insert txt file path");
        string filePath = Console.ReadLine();

        if (!File.Exists($@"{filePath}\logs.txt"))
        {
            Console.WriteLine("File don't exists");
            return;
        }

        string[] fileLines = File.ReadAllLines($@"{filePath}\logs.txt");

        Conversor conversorInstance = new Conversor();

        List<string> convertedLines = conversorInstance.convertLogs(fileLines);

        Console.WriteLine("Insert path to save the parsed log file");
        string pathToSave = Console.ReadLine();

        conversorInstance.createFile(pathToSave, convertedLines);

    }





}