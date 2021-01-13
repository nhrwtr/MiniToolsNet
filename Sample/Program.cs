using System;
using Tools;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // GUID
            GuidFactorySample.Show();

            // Exception
            ThrowHelperSample.Show(args);
        }
    }
}
