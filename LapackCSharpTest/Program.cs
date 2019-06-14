using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace LapackCSharpTest
{
    class MainClass
    {
        [DllImport("liblapack.so")]
        static extern void dgesv_(ref int n, ref int nrhs, double[] a, ref int lda, int[] ipvt, double[] bx, ref int ldb, ref int infos);

        public static void Main(string[] args)
        {

            // 5X - 2Y = 7 
            // -X +  Y = 1
            double[] a = { 5, -1, -2, 1 };
            double[] b = { 7, 1 };

            int n = 2;
            int nrhs = 1;
            int lda = 2;
            int ldb = 2;
            int infos = 0;

            var a0 = a.ToArray();
            var b0 = b.ToArray();
            int[] ipvt = new int[n];

            dgesv_(ref n, ref nrhs, a0, ref lda, ipvt, b0, ref ldb, ref infos);

            Console.WriteLine("Equations");
            Console.WriteLine("5X - 2Y = 7");
            Console.WriteLine("-X +  Y = 1");
            Console.WriteLine();

            Console.WriteLine("Solutions");
            Console.WriteLine($"X = {b0[0]} and Y = {b0[1]}");
        }
    }
}
