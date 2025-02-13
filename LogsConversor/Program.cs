using LogsConversor.classes;

class Program
{


    static void Main(string[] args)
    {
        Console.Write("Insert old logs file path: ");
        string filePath = Console.ReadLine();

        if (!File.Exists($@"{filePath}\logs.txt"))
        {
            Console.WriteLine("File don't exists");
            return;
        }

        string[] fileLines = File.ReadAllLines($@"{filePath}\logs.txt");

        Conversor conversorInstance = new Conversor();

        List<string> convertedLines = conversorInstance.convertLogs(fileLines);

        Console.Write("Insert path to save the new formated logs file:");
        string pathToSave = Console.ReadLine();

        conversorInstance.createFile(pathToSave, convertedLines);

    }





}