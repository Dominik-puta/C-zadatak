/********************************************************************************************
 *                                                                                          *
 *                                               Nizovi                                     *
 *                                                                                          *   
 *   Tekst Zadatka na: https://www.facebook.com/laboshackerspace/posts/1452342314845151     *
 *                                                                                          *
 *   Zadatak nije uredno napisan zbog vremenskog ograničenja koje sam si zadao (35 min),    *
 *   ali su komentari dodani kasnije.                                                       *
 *                                                                                          *
 ********************************************************************************************/





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nizovi
{
    class Nizovi
    {
        //Deklarirane sve varijable koje će se koristiti kasnije.
        static int M;
        static int N;
        static int K;
        static int[] resultArray;
        static int[] brojevi;
        static List<int> KBrojevi = new List<int>();
        static int current;
        static public string[] brojevi_;

        //Funkcija za traženje parametara od korisnika.
        static void CollectData()
        {
            Console.WriteLine("Upisite N M K");
            string[] data = Console.ReadLine().Split(' ');

            string M_ = data[1];
            string N_ = data[0];
            string K_ = data[2];

            if (Int32.TryParse(M_, out M)) { }
            if (Int32.TryParse(N_, out N)) { }
            if (Int32.TryParse(K_, out K)) { }
            brojevi = new int[N];

            //Provjera za ispravnost zadatka.
            if (M < 2 || M >= N)
            {
                Console.WriteLine("NEVALJA!!!!");
                Console.WriteLine("Press any key to terminate program");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            if (K < 2 || K > M)
            {
                Console.WriteLine("NEVALJA!!!!");
                Console.WriteLine("Press any key to terminate program");
                Console.ReadKey();
                System.Environment.Exit(0);

            }
            if (N > 4)
                Console.WriteLine("Upisite " + N + " brojeva:");
            else
                Console.WriteLine("Upisite " + N + " broja:");

            brojevi_ = Console.ReadLine().Split(' ');
            int i = 0;

            //Parsira sve brojeve druge liste.
            foreach (string item in brojevi_)
            {

                int.TryParse(item, out int val);

                brojevi[i] = val;
                i++;
            }
        }

        //vrti brojeve u array-u te ih returna i kasnije pohrani u drugi array.
        static private IEnumerable<int> GetStringWrapped(int position)
        {

            while (true)
            {
                yield return brojevi[current];
                current += 1;
                current %= brojevi.Length;
            }
        }
        static void Main(string[] args)
        {
            //Prikupljanje user inputa.
            CollectData();
            current = 0;
            for (int i = 0; i < N; i++)                             //Sve se vrti N puta.
            {
                current = i;
                resultArray = GetStringWrapped(1).Take(M).ToArray(); // poziva enumerator koji se vrti M puta i
                current++;                                           // svaki krug vrati M brojeva.

                int Kbroj = (from number in resultArray    //Traži K brojeve tako sto u arrayu kojem su izdvojeni brojevi trazi K-ti najmanji broj.
                             orderby number ascending
                             select number).Distinct().Skip(K - 1).First();

                KBrojevi.Add(Kbroj); // Kbroj doda u listu Kbrojeva.
            }

            Console.WriteLine(KBrojevi.Min()); //ispisuje najmanji Kbroj.
            Console.ReadLine();
        }
    }
}













