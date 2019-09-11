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
            hb('A', 'B', 'C', 3);

            Console.Read();
        }

        public static void hb(char xx, char yy, char zz, int nn)
        {
            Status status = new Status(xx, yy, zz, nn);

            //Move(x, y, z, n);
            //}

            Console.WriteLine("Veiksmu seka, kai n={0}", nn);
            Console.WriteLine("Pradine busena A:({0}) B:({1}) C:({2})", string.Join(", ", status.getStatus()['A']), string.Join(", ", status.getStatus()['B']), string.Join(", ", status.getStatus()['C']));


            void Move(char x, char y, char z, int n)
        {
            if (n > 0)
            {
                Move(x, z, y, n-1);

                    status.count += 1;

                    Console.Write("{3}. Diska {0} nuo {1} perkelti ant {2}. ", n, x, z, status.count);

                    
                    status.getStatus()[z].Add(status.getStatus()[x][status.getStatus()[x].Count - 1]);
                    status.getStatus()[x].RemoveAt(status.getStatus()[x].Count - 1);

                    Console.WriteLine("A:({0}) B:({1}) C:({2})", string.Join(", ", status.getStatus()['A']), string.Join(", ", status.getStatus()['B']), string.Join(", ", status.getStatus()['C']));
                /*zStatus.Add(xStatus[xStatus.Count - 1]);
                xStatus.RemoveAt(xStatus.Count - 1);

                Console.Write("A=(");
                foreach (String i in xStatus) {
                    Console.Write(i + ",");
                }
                Console.Write("), B=(");
                foreach (String i in yStatus)
                {
                    Console.Write(i + ",");
                }
                Console.Write("), C=(");
                foreach (String i in zStatus)

                {
                    Console.Write(i + ",");
                }

                Console.WriteLine(").");*/
                Move(y, x, z, n-1);
            }
        }

            Move(xx, yy, zz, nn);
                }

    }
    public class Status
    {
        public int count { get; set; }

        Dictionary<char, List<string>> status = new Dictionary<char, List<string>>();    

    public Status(char x, char y, char z, int n)
        {
            status.Add(x, Enumerable.Range(1, n).Reverse().Select(num => num.ToString()).ToList());
            status.Add(y, new List<string>());
            status.Add(z, new List<string>());

            count = 0;
        }

        public Dictionary<char, List<string>> getStatus()
        {
            return this.status;
        }

    }
}

