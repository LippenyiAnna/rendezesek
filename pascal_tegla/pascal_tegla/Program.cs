using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pascal_tegla
{
    internal class Program
    {
        static void Tegla(string szo, int szam)
        {          
            for (int i = 0; i < szo.Length - szam + 1; i++) 
            {
                for (int j = i; j < szam + i - 1; j++)
                {
                    Console.Write(szo[j] + " ");
                }
                Console.WriteLine(szo[szam + i - 1]);
            }
        }

        static void Tegla2(string szo, int szam, int szam2)
        {
            for (int i = 0; i < szo.Length - szam2 + 1; i++)
            {
                if (i + szam < szo.Length - szam2)
                {
                    for (int j = i; j < szam + i - 1; j++)
                    {
                        Console.Write(szo[j] + " ");
                    }
                    Console.WriteLine(szo[szam + i - 1]);
                }
                else if(i + szam == szo.Length - szam2)
                {
                    for (int j = i; j < szam + szam2 + i - 2; j++)
                    {
                        Console.Write(szo[j] + " ");
                    }
                    Console.WriteLine(szo[szam + szam2 + i - 2]);
                    i += szam - 1;
                }
                else
                {
                    for (int j = 0; j < szam - 1; j++) Console.Write("  ");
                    for (int j = i; j < szam2 + i - 1; j++)
                    {
                        Console.Write(szo[j] + " ");
                    }
                    Console.WriteLine(szo[szam2 + i - 1]);
                }
            }
        }

        static int Utak(int szelesseg, int magassag)
        {
            List<int> utak = new List<int>();
            for (int i = 0; i < szelesseg; i++)
            {
                utak.Add(1);
            }
            for (int i = 1; i < magassag; i++)
            {
                for (int j = 1; j < utak.Count; j++)
                {
                    utak[j] = utak[j] + utak[j - 1];
                }
            }
            return utak[szelesseg - 1];
        }

        static int Utak2(int szelesseg, int magassag, int szelesseg2, int magassag2)
        {
            List<int> utak = new List<int>();
            for (int i = 0; i < szelesseg; i++)
            {
                utak.Add(1);
            }
            for (int i = 1; i < magassag; i++)
            {
                for (int j = 1; j < utak.Count; j++)
                {
                    utak[j] = utak[j] + utak[j - 1];
                }
            }        
            List<int> utak2 = new List<int>();
            for (int i = 0; i < szelesseg2; i++)
            {
                utak2.Add(utak[szelesseg - 1]);
            }
            for (int i = 1; i < magassag2; i++)
            {
                for (int j = 1; j < utak2.Count; j++)
                {
                    utak2[j] = utak2[j] + utak2[j - 1];
                }
            }
            return utak2[szelesseg2 - 1];
        }

        static void Main(string[] args)
        {
            bool hiba1 = true;
            bool hiba2 = true;
            while (hiba1)
            {
                Console.WriteLine("Kérlek írj be 1 szót, aztán a következő sorba a tégla szélességét (szám)");
                string szo = Console.ReadLine().ToUpper();
                int szam = int.Parse(Console.ReadLine());
                if (szo.Length < szam)
                {
                    Console.WriteLine("Kérlek a szám kisebb legyen, mint a szó hossza");
                }
                else
                {
                    Tegla(szo, szam);
                    Console.WriteLine($"A lehetséges utak száma: {Utak(szam, szo.Length - szam + 1)}");
                    hiba1 = false;
                }
            }
            while (hiba2)
            {
                Console.WriteLine("Kérlek írj be 1 szót, aztán a következő sorba a tégla szélességét (szám),");
                Console.WriteLine("az utána lévőbe a másik tégla szélességét (szám)");
                string szo2 = Console.ReadLine().ToUpper();
                int szam1 = int.Parse(Console.ReadLine());
                int szam2 = int.Parse(Console.ReadLine());
                if (szam1 + szam2 >= szo2.Length)
                {
                    Console.WriteLine("hiba: a két szám összege ne legyen egyenlő a szó hosszúságával");
                }
                else
                {               
                    Tegla2(szo2, szam1, szam2);
                    Console.WriteLine($"A lehetséges utak száma: {Utak2(szam1, szo2.Length - szam1 + 1 - szam2 , szam2, 2)}"); 
                    hiba2 = false;
                }
            }            
        }
    }
}