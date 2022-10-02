using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test
{
    public class Paliwo
    {
        
        
        

        int[] dzien = new int[7];

        string[] lines = File.ReadAllLines(@"C:\Users\Glucio\Desktop\Zadanie 3\lpg.txt");
        public void Zad1()
        {
            for (int i = 0; i < 7; i++)
            {
                dzien[i] = i;
            }
            foreach (string line in lines)
            {
                int x = -1;
                int lpg_max = 30, pb95_max = 45;
                int lpg_spalanie = 9, pb95_spalanie = 6;

                double lpg_teraz = 30, pb95_teraz = 45;
                double spalone;

                var delimiters = new char[] { '\t' };
                var segments = line.Split(delimiters);

                x++;
                int trasa = Int32.Parse(segments[1]);
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
                if (x == 6)
                {
                    x = -1;
                }

                Console.WriteLine($"LPG teraz: {lpg_teraz}, PB95 teraz: {pb95_teraz}");

            }
        }
    }
}
