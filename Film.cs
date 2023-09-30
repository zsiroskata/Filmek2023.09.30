using System;
using System.Collections.Generic;
using System.Text;

namespace filmek
{
    class Film
    {
        //cim
        public string Cim { get; set; }
        //rendező
        public string Rendezo { get; set; }
        //ev
        public int Ev { get; set; }
        //ertekeles
        public double Ertekeles { get; set; }

        public Film (string sorok)
        {
            string[] sor = sorok.Split(",");
            Cim = sor[0];
            Rendezo = sor[1];
            Ev = Convert.ToInt32(sor[2]);
            Ertekeles = Convert.ToDouble(sor[3]);
        }
    }
}
