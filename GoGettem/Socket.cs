using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoGettem
{
    public class Socks
    {
        public static List<string> SessionTokens = null;
        public static string Addr = null;
        
        public static void ConnectionHandler()
        {
            IPAddress hostaddr = IPAddress.Parse("127.0.0.1");

            try
            {
                while (true)
                {
                    TcpListener Listener = new TcpListener(hostaddr, 47786);
                    Listener.Start();
                
                    Console.WriteLine($"Local endpoint is {Listener.LocalEndpoint}");
                
                    Console.WriteLine("Listening for connection...");

                    ThreadStart threadInf = new ThreadStart(() => T(Listener));
                    Thread threadStart = new Thread(threadInf);
                    threadStart.Start();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void T(TcpListener Listener)
        {
            Socket s = Listener.AcceptSocket();

            string CurrentSessionToken = new Guid().ToString();
            SessionTokens.Add(CurrentSessionToken);
            Console.WriteLine($"New connection | {s.RemoteEndPoint}");

            byte[] x = new byte[100];
            int y = s.Receive(x);
            string dat = "";
            for (int m = 0; m < y; m++)
            {
                dat = dat + Convert.ToChar(x[m]).ToString();
                Console.WriteLine(dat);
            }
            
            PyHandler.RunScript(CurrentSessionToken, dat);

            string sendBackParsed = Program.LattermostHandler(CurrentSessionToken);

            sender(s, sendBackParsed, CurrentSessionToken);
        }
        
        public static async Task sender(Socket socket, string ret, string SessionToken)
        {
            if (SessionToken != null)
            {
                ASCIIEncoding toSend = new ASCIIEncoding();
                try
                {
                    socket.SendTimeout = 10;
                    socket.Send(toSend.GetBytes(ret));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to send back to client");
                    socket.Send(toSend.GetBytes("Failed to send output to client"));
                }   
            }
        }
        
    }
}