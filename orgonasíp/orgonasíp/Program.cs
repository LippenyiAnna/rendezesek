using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orgonasíp
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

        static void Orgonasip(List<int> lista)
        {
            Minimumkivalasztasos_rendezes(lista); // növekvő sorba rakja a lsitát
            bool paros_e = lista.Count % 2 == 0; // megnézi hogy páros vagy páratlan e a hossza
            if (paros_e) // minden első / második elemet a helyére rak. Ha páros a hossz akkor az első elemtől, ha páratlan akkor a másodiktól indul
            {
                for (int i = 0; i < lista.Count - 1; i = i + 1)
                {
                    int j = i;
                    while (j < lista.Count - 1 && lista[j] < lista[j + 1])
                    {
                        Csere(lista, j, j + 1);
                        j++;
                    }
                }
            }
            else
            {
                for (int i = 1; i < lista.Count - 1; i = i + 1)
                {
                    int j = i;
                    while (j < lista.Count - 1 && lista[j] < lista[j + 1])
                    {
                        Csere(lista, j, j + 1);
                        j++;
                    }
                }
            }
        }

        static void Main(string[] args)     
        {
            List<int> lista = new List<int>() { 1, 5, 3, 9, 2, 6, 7 , 0};
            Orgonasip(lista);
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write(lista[i] + ", ");
            }
        }
    }
}