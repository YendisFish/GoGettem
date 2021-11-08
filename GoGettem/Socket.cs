using System;

namespace GoGettem
{
    public class Socks
    {
        public static string SessionToken = null;
        public static string Addr = null;
        
        public static void ConnectionHandler()
        {
            //vv ADD LOGIC BEFORE vv
            SessionToken = new Guid().ToString();
        }
    }
}