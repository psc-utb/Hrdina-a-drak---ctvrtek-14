using System;

namespace Hrdina_a_drak___ctvrtek_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Mec mec = new Mec(20);
            Hrdina hrdina = new Hrdina("Geralt", 100, 100, 10, 10, mec);
            Drak drak = new Drak("Alduin", 100, 100, 11, 10);
            Vlk vlk = new Vlk("Wolf", 50, 50, 5, 5);

            Hrdina hrdinaKlon = hrdina.Clone();
            hrdinaKlon.Jmeno += " (klon)";
            hrdinaKlon.Zdravi = 150.5;
            hrdinaKlon.Utekl = true;
            hrdinaKlon.Mec.PoskozeniMax = 50;
            Console.WriteLine(hrdina.ToString());
            Console.WriteLine(hrdinaKlon.ToString() + Environment.NewLine);

            /*
            Arena arena = new Arena(hrdina, drak);
            arena.Boj();*/

            Postava[] postavy = new Postava[] { hrdina, drak, vlk };
            ArenaProPostavy arenaProPostavy = new ArenaProPostavy(postavy);
            arenaProPostavy.Boj();
        }
    }
}
