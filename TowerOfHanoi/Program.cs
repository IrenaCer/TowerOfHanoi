using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Move('A', 'B', 'C', 3);
            Console.Read();
        }
        public static void Move(char x, char y, char z, int n, List<String> xStatus = null, List<String> yStatus = null, List<String> zStatus = null, int id = 1)
        {
            if (n > 0)
            {
                xStatus = xStatus ?? Enumerable.Range(1, n).Select(num => n - num + 1).ToList();
                xStatus = xStatus ?? Enumerable.Range(1, n).Reverse().Select(num => num.ToString()).ToList();
                yStatus = yStatus ?? new List<String>();
                zStatus = zStatus ?? new List<String>();

                Move(x, z, y, n-1, xStatus, zStatus, yStatus);

                Console.Write("Diską {0} nuo {1} perkelti ant {2}. ", n, x, z);

                zStatus.Add(xStatus[xStatus.Count - 1]);
                xStatus.RemoveAt(xStatus.Count - 1);

                Console.Write("A=(");
                foreach (int i in xStatus) {
                    Console.Write(i + ",");
                }
                Console.Write("), B=(");
                foreach (int i in yStatus)
                {
                    Console.Write(i + ",");
                }
                Console.Write("), C=(");
                foreach (int i in zStatus)
                {
                    Console.Write(i + ",");
                }

                Console.WriteLine(").");
                Move(y, x, z, n-1, yStatus, xStatus, zStatus);
            }
        }

    }
}
