using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___ctvrtek_14
{
    public interface IZasazitelny
    {
        double Zdravi { get; set; }
        double Obrana();
        void SnizeniZdravi(double hodnota);
    }
}
