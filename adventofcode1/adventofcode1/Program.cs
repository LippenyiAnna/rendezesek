using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode1
{
    internal class Program
    {
        static void Minimumkivalasztasos_rendezes(List<int> lista) // Selection sort
        {
            for (int i = 0; i < lista.Count - 1; i++)
            {
                int mini = Legkisebb_elem_helye_innentol(lista, i);
                Csere(lista, mini, i);
            }
        }

        static void Csere(List<int> lista, int i, int j)
        {
            int temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }


        static int Legkisebb_elem_helye_innentol(List<int> lista, int innentol)
        {
            int mini = innentol;
            for (int i = innentol + 1; i < lista.Count; i++)
            {
                if (lista[i] < lista[mini])
                {
                    mini = i;
                }
            }
            return mini;
        }

        static int Kulonbseg(List<int> lista1, List<int> lista2)
        {
            Minimumkivalasztasos_rendezes(lista1);
            Minimumkivalasztasos_rendezes(lista2);
            int result = 0;
            for (int i = 0; i < lista1.Count ; i++)
            {
                int szam;
                if (lista1[i] < lista2[i])
                {
                    szam = lista2[i] - lista1[i];
                }
                else
                {
                    szam = lista1[i] - lista2[i];
                }
                result = result + szam;
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<int> lista1 = new List<int>() { 1, 2, 7, 5, 2, 0, 0 };
            List<int> lista2 = new List<int>() { 4, 7, 4, 1, 1, 0, 3 };
            Console.WriteLine(Kulonbseg(lista1, lista2));
        }
    }
}