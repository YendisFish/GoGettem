using System;

namespace GoGettem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("init");

            Socks.ConnectionHandler();
        }

        public static string LattermostHandler(string SessionToken)
        {
            try
            {
                string[] toParse = PyHandler.ReadPyOut(SessionToken);

                if (toParse != null)
                {
                    string ret = toParse.ToString();
                    return ret;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}