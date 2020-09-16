using System;

namespace verKdagDag
{
    class Program
    {
        static void Main(string[] args)
        {
            int dag, maand, jaar;
            int K;
            K = readInt("Voer de base in (1000 of 1024 worden aangeraden):");

            DateTime geboorteDatum = new DateTime();

            do
            {
                Console.WriteLine("Voer je geboortedatum in:");
                dag = readInt("Dag?");
                maand = readInt("Maand?");
                jaar = readInt("Jaar?");

                try
                {
                    geboorteDatum = new DateTime(jaar, maand, dag);
                }
                catch (Exception e)
                {
                    Console.WriteLine("De datum die je hebt ingevoerd is niet correct. Probeer het opnieuw.");
                }

            } while (geboorteDatum == new DateTime());
            
            int dagenTotK = K - (int)(((DateTime.Now - geboorteDatum).TotalDays) % K);

            if (dagenTotK == K)
                Console.WriteLine($"Gefeliciteerd! Het is vandaag je {K}e jubileum!");
            else
                Console.WriteLine($"Nog {dagenTotK} dagen tot je volgende {K}e jubileum!");

        }

        static int readInt (string msg)
        {
            string tmp = null;
            int ret = 0;

            do
            {
                Console.WriteLine(msg);
                tmp = Console.ReadLine();
                try
                {
                    ret = int.Parse(tmp);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Getal niet herkend. Probeer een natuurlijk getal in te voeren.");
                    tmp = null;
                }
            } while (tmp == null);

            return ret;
        }
    }
}
