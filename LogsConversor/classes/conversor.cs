
namespace LogsConversor.classes
{
    public class Conversor
    {
        public List<string> convertLogs(string[] logLines)
        {


            List<string> result = [];

            for (int i = 0; i < logLines.Length; i++)
            {

                string[] data = logLines[i].Split("|");
                string responseSize = data[0];
                string statusCode = data[1];
                string cacheStatus = data[2];

                string[] uriData = data[3].Split(['/', ' '], StringSplitOptions.RemoveEmptyEntries);
                string method = uriData[0].Trim('\"');


                string path = "/" + uriData[1];

                string timeTaken = data[4].Trim();

                string parsedLine = $@"{method} {statusCode} {path} {responseSize} {timeTaken} {cacheStatus}";


                result.Add(parsedLine);
            }

            return result;
        }


        public void createFile(string path, List<string> parsedLines)
        {
            try
            {

                Directory.CreateDirectory(Path.GetDirectoryName(path));

                using (StreamWriter sw = new StreamWriter($@"{path}\logs.log"))
                {
                    foreach (string parsedLine in parsedLines)
                    {
                        Console.WriteLine(parsedLine);
                        sw.WriteLine(parsedLine);
                    }
                }
            }
            catch
            {
                Console.WriteLine("error");
            }

        }
    }
}
