using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___ctvrtek_14
{
    public class Postava : Object
    {

        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double ZdraviMax { get; set; }
        public double PoskozeniMax { get; set; }
        public double ZbrojMax { get; set; }

        public bool Utekl { get; set; }

        public Postava(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
        {
            Jmeno = jmeno;
            Zdravi = zdravi;
            ZdraviMax = zdraviMax;
            PoskozeniMax = poskozeniMax;
            ZbrojMax = zbrojMax;
            Utekl = false;
        }

        /// <summary>
        /// postava zaútočí na oponenta vygenerovanou hodnotou. Oponent se brání a případně se mu sníží životy.
        /// </summary>
        /// <param name="oponent">oponent postavy</param>
        /// <returns>hodnota utoku</returns>
        /// <exception cref="Exception">postava zaútočí, i když už útočit nemůže</exception>
        public virtual double Utok(Postava oponent)
        {
            return Utok(oponent, PoskozeniMax);
        }

        protected double Utok(Postava oponent, double poskozeniMax)
        {
            if (MuzeBojovat())
            {
                double hodnotaUtoku = 0;

                Random rnd = new Random();
                hodnotaUtoku = rnd.NextDouble() * poskozeniMax;
                hodnotaUtoku -= oponent.Obrana();
                oponent.SnizeniZdravi(hodnotaUtoku);

                return hodnotaUtoku;
            }
            else
                throw new Exception($"{Jmeno} zaútočil, i když nemůže bojovat!");
        }

        public virtual double Obrana()
        {
            double hodnotaObrany = 0;

            //dodelat

            return hodnotaObrany;
        }

        public Postava VyberOponenta(Postava[] postavy)
        {
            foreach (var postava in postavy)
            {
                if (postava.MuzeBojovat() && postava != this)
                {
                    return postava;
                }
            }
            return null;
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
