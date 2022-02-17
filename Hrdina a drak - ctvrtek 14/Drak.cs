﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___ctvrtek_14
{
    public class Drak
    {
        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double ZdraviMax { get; set; }
        public double PoskozeniMax { get; set; }
        public double ZbrojMax { get; set; }

        public bool Utekl { get; set; }


        public Drak(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
        {
            Jmeno = jmeno;
            Zdravi = zdravi;
            ZdraviMax = zdraviMax;
            PoskozeniMax = poskozeniMax;
            ZbrojMax = zbrojMax;
            Utekl = false;
        }

        /// <summary>
        /// drak zaútočí na hrdinu vygenerovanou hodnotou. Hrdina se brání a případně se mu sníží životy.
        /// </summary>
        /// <param name="oponent">oponent draka - hrdina</param>
        /// <returns>hodnota utoku</returns>
        /// <exception cref="Exception">drak zaútočí, i když už útočit nemůže</exception>
        public double Utok(Hrdina oponent)
        {
            if (MuzeBojovat())
            {
                double hodnotaUtoku = 0;

                Random rnd = new Random();
                hodnotaUtoku = rnd.NextDouble() * PoskozeniMax;
                hodnotaUtoku -= oponent.Obrana();
                oponent.SnizeniZdravi(hodnotaUtoku);

                return hodnotaUtoku;
            }
            else
                throw new Exception("Drak zaútočil, i když nemůže bojovat!");
        }

        public double Obrana()
        {
            double hodnotaObrany = 0;

            //dodelat

            return hodnotaObrany;
        }

        public void SnizeniZdravi(double hodnotaSnizeni)
        {
            if (hodnotaSnizeni > 0)
            {
                Zdravi -= hodnotaSnizeni;
            }
        }

        public bool MuzeBojovat()
        {
            return JeZivy() && Utekl == false;
        }

        public bool JeZivy()
        {
            if (Zdravi > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
