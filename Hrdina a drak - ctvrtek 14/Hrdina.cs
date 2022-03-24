﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___ctvrtek_14
{
    public class Hrdina : Postava
    {
        public Mec Mec { get; set; }

        public Hrdina(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax, Mec mec) : base(jmeno, zdravi, zdraviMax, poskozeniMax, zbrojMax)
        {
            Mec = mec;
        }

        public override double Utok(Postava oponent)
        {
            if (Mec != null)
            {
                return Utok(oponent, Mec.PoskozeniMax);
            }
            else
            {
                //return Utok(oponent, PoskozeniMax);
                return base.Utok(oponent);
            }
        }

        public Hrdina Clone()
        {
            //Hrdina klon = new Hrdina(Jmeno, Zdravi, ZdraviMax, PoskozeniMax, ZbrojMax, Mec.Clone());
            //klon.Utekl = Utekl;
            Hrdina klon = this.MemberwiseClone() as Hrdina;
            klon.Mec = Mec.Clone();
            return klon;
        }

        public override string ToString()
        {
            return $"{Jmeno}, Zdravi: {Zdravi}, ZdraviMax: {ZdraviMax}, PoskozeniMax: {PoskozeniMax}, ZbrojMax: {ZbrojMax}, Utekl: {Utekl}, Mec-PoskozeniMax: {Mec.PoskozeniMax}, Hodnoceni postavy: {HodnoceniPostavy()}";
        }

        protected override bool KontrolaOponenta(Postava oponent)
        {
            return true;
        }
    }
}
