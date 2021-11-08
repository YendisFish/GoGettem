using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Net.Sockets;

namespace GoGettem
{
    public class PyHandler
    {
        public List<String> LinkList = new();
        
        public static void RunScript(string SessionToken)
        {
            Console.WriteLine("Reading Config File");

            if (SessionToken != null)
            {
                ProcessStartInfo pipInstall = new ProcessStartInfo();
                pipInstall.FileName = "/bin/bash";
                pipInstall.Arguments = "pip install googlesearch-python";
                
                try
                {
                    Console.WriteLine("Tyring As Linux Machine");
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = "/bin/bash";
                    proc.Arguments = "python Scraper.py";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public static string[]? ReadPyOut(string SessionToken)
        {
            if (SessionToken != null)
            {
                string[] ret = File.ReadAllLines("Results.txt");
                return ret;
            }

            return null;
        }
    }
}