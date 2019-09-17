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
            Console.Write("Įveskite diskų skaičių: ");
            string c = Console.ReadLine();
            int value;
            if (int.TryParse(c, out value) && value >= 1 && value <= 10) {
                hb('A', 'B', 'C', value);
            } else
            {
                Console.WriteLine("Įvedėte neteisingą diskų skaičių. Diskų skaičius gali būti nuo 1 iki 10.");
            }

        }

        public static void hb(char xx, char yy, char zz, int nn)
        {
            Status status = new Status(xx, yy, zz, nn);

            Console.WriteLine("Veiksmų seka, kai n={0}", nn);
            Console.WriteLine("Pradinė būsena A:({0}) B:({1}) C:({2}).", string.Join(", ", status.getStatus()['A']), string.Join(", ", status.getStatus()['B']), string.Join(", ", status.getStatus()['C']));


            void Move(char x, char y, char z, int n)
        {
            if (n > 0)
            {
                Move(x, z, y, n-1);

                    status.count += 1;

                    //Console.Write("{3}. Diska {0} nuo {1} perkelti ant {2}. ", n, x, z, status.count);
                    Console.Write("{3,5}. Diską {0,2} nuo {1} perkelti ant {2}.         ", n, x, z, status.count);


                    status.getStatus()[z].Add(status.getStatus()[x][status.getStatus()[x].Count - 1]);
                    status.getStatus()[x].RemoveAt(status.getStatus()[x].Count - 1);


                   Console.WriteLine(
                       "A:{0,-30} B:{1, -30} C:{2, -30}",
                       "(" + string.Join(", ", status.getStatus()['A']) + ")",
                       "(" + string.Join(", ", status.getStatus()['B']) + ")",
                       "(" + string.Join(", ", status.getStatus()['C']) + ")."
                   );
                /*zStatus.Add(xStatus[xStatus.Count - 1]);
                xStatus.RemoveAt(xStatus.Count - 1);
               */
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

