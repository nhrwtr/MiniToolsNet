using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class ThrowHelperSample
    {
        public static void Show(string[] args)
        {
            try
            {
                int x = 0;
                throw Tools.ThrowHelper.New<Exception>("exception!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                if (args.Length <= 1)
                {
                    throw Tools.ThrowHelper.New<ArgumentException>("args", args, "exception");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                string y = null;
                throw Tools.ThrowHelper.New<ArgumentNullException>("y", "null value!");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
