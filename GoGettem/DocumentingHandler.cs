using System;
using System.IO;
using System.Linq;

namespace GoGettem
{
    public class DocumentingHandler
    {
        public void AddReference(string SessionToken, string[] AdditionalInformation)
        {
            Console.WriteLine("Writing User Info...");

            if (!File.Exists("log.txt"))
            {
                var fs = File.Create("log.txt");
                fs.Close();
            }
            else
            {
                string ContentToWrite = SessionToken + " | " + AdditionalInformation.ToString(); 
                File.AppendAllText("log.txt", ContentToWrite);
            }
        }
    }
}