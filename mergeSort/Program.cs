using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace heapSort
{
    class Program
    {
        //==================== #add
        static void add(int x) {
            hs++;
            h[hs] = x;
            siftUp(hs);
        }
        //==================== #up
        static void siftUp(int i)
        {
            if (i == 1) return;
            int p = i / 2;
            if (h[i] < h[p])
            {
                swap(ref h[i], ref h[p]);
                siftUp(p);
            }
        }
        //==================== #down
        static void siftDown(int i)
        {
            int k = i;
            if (2 * i <= hs && h[2 * i] < h[k]) k = 2 * i;
            if ((2 * i + 1) < hs && h[2 * i + 1] < h[k]) k = 2 * i + 1;

            if (k != i) {
                swap(ref h[i], ref h[k]);
                siftDown(k);
            }

        }
        //==================== #delete
        static void siftDelete(int i)
        {
            h[i] = h[hs];
            hs--;
            siftDown(i);
        }
        //----------------------------------------------------------------
        static void swap(ref int a, ref int b) {
            int k = a;
            a = b;
            b = k;
        }
        //----------------------------------------------------------------
        static int MaxheapSize = 1000000;
        static int[] h = new int[MaxheapSize]; // heap
        static int hs = 0; // heap size
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        static int[] sRNDmas(int amount) {
            int[] ret = new int[amount];

            for (int i = 0; i < amount; i++)
                ret[i] = rnd.Next(90);

            return ret;
        }


        static void sort(ref int[] mass)
        {
            hs = 0;
            //
            for (int i = 0; i < mass.Length; i++)
                add(mass[i]);
            //
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = h[1];
                siftDelete(1);
            }
        }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        static Random rnd = new Random(1);


       static public void tester(int tests) {
            Console.WriteLine("test on " + tests + " mass");

            // подготовка
            int[] a = new int[tests];
            Random R = new Random(999);

            for (int i = 0; i < tests; i++)
                a[i] = rnd.Next(90);

            // тест
            DateTime time = System.DateTime.Now;
            sort(ref a);
            Console.WriteLine( "time passed: " + (DateTime.Now - time));


            bool check = true;
            for (int i = 1; i < tests; i++)
                if (a[i] < a[i - 1]) check = false;

            Console.WriteLine("is sorted: " + check);
        }


        static void Main(string[] args)
        {

            Console.WriteLine("merge sort tests\n");

            tester(1000);
            tester(5000);
            tester(20000);
            tester(50000);
            tester(100000);

            Console.WriteLine("\nfinished");

            Console.ReadLine();
        }
    }
}
