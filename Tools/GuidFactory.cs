using System;

namespace Tools
{
    public class GuidFactory
    {
        public static string Create()
        {
            string guid = Guid.NewGuid().ToString();
            return guid;
        }
    }
}
