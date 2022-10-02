using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int x = 0; 
            int lpg_max = 30, pb95_max = 45;
            int lpg_spalanie = 9, pb95_spalanie = 6;


            double lpg_teraz = 30, pb95_teraz = 45;
            double spalone;

            int[] dzien = new int[7];

            for (int i = 0; i < 7; i++)
            {
                dzien[i] = i;
            }
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] lines = File.ReadAllLines(@"C:\Users\Glucio\Desktop\Zadanie 3\lpg.txt");
            foreach (string line in lines)
            {
                var delimiters = new char[] { '\t' };
                var segments = line.Split(delimiters);

                dic.Add(segments[0], Int32.Parse(segments[1]));
                int trasa = dic[segments[0]];
                
                if (lpg_teraz > 15)
                {
                    spalone = (lpg_spalanie * trasa) / 100;
                    lpg_teraz -= spalone;
                }
                else
                {
                    spalone = (lpg_spalanie * trasa / 2) / 100;
                    lpg_teraz -= spalone;
                    spalone = (pb95_spalanie * trasa / 2) / 100;
                    pb95_teraz -= spalone;
                }
                if (lpg_teraz < 5)
                {
                    lpg_teraz = lpg_max;
                }
                if (dzien[x] == 3 && pb95_teraz < 40)
                {
                    pb95_teraz = pb95_max;
                }
                

                Console.WriteLine($"LPG teraz: {lpg_teraz}, PB95 teraz: {pb95_teraz}");
                x++;
                if (x == 7)
                {
                    x=0;
                }

            }
            

            
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
