# LapackCSharpTest
Solving linear equation using lapack with csharp

Dependencies
```
$ sudo apt-get install liblapack3
$ sudo apt-get install liblapack-dev
$ sudo apt-get install libopenblas-base
$ sudo apt-get install libopenblas-dev
```

### Code
```
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace LapackCSharpTest
{
    class MainClass
    {
        [DllImport("lapack", EntryPoint = "dgesv_")]
        static extern void lapack_dgesv(ref int n, ref int nrhs, double[] a, ref int lda, int[] ipvt, double[] b, ref int ldb, ref int infos);

        [DllImport("mkl_rt", EntryPoint = "dgesv")]
        static extern void mkl_dgesv(ref int n, ref int nrhs, double[] a, ref int lda, int[] ipvt, double[] b, ref int ldb, ref int infos);

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
            int infos0 = 0;

            var a0 = a.ToArray();
            var b0 = b.ToArray();
            int[] ipvt0 = new int[n];

            lapack_dgesv(ref n, ref nrhs, a0, ref lda, ipvt0, b0, ref ldb, ref infos0);

            Console.WriteLine("Equations");
            Console.WriteLine("5X - 2Y = 7");
            Console.WriteLine("-X +  Y = 1");
            Console.WriteLine();

            Console.WriteLine("Solutions lapack");
            Console.WriteLine($"X = {b0[0]} and Y = {b0[1]}");
            Console.WriteLine();

            int infos1 = 0;
            var a1 = a.ToArray();
            var b1 = b.ToArray();
            int[] ipvt1 = new int[n];

            mkl_dgesv(ref n, ref nrhs, a1, ref lda, ipvt1, b1, ref ldb, ref infos1);

            Console.WriteLine("Solutions mkl");
            Console.WriteLine($"X = {b1[0]} and Y = {b1[1]}");

        }
    }
}


```

### Output
```
Equations
5X - 2Y = 7
-X +  Y = 1

Solutions lapack
X = 3 and Y = 4

Solutions mkl
X = 3 and Y = 4

```
