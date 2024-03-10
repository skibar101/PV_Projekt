using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
/// <summary>
/// Třída, která reprezentuje tabulku objednávky, ve třídě jsou pouze vlastnosti, konstruktory, gettery & settery a metoda to string
/// </summary>
{
    internal class Objednavka : IBaseClass
    {
        private int id;
        private DateTime datum;
        private int zakaznik_id;

        public Objednavka(int id, DateTime datum, int zakaznik_id)
        {
            this.id = id;
            this.datum = datum;
            this.zakaznik_id = zakaznik_id;
        }

        public Objednavka(DateTime datum, int zakaznik_id)
        {
            this.id = 0;
            this.datum = datum;
            this.zakaznik_id = zakaznik_id;
        }

        public Objednavka()
        {
           
        }

        public int Id { get => id; set => id = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public int Zakaznik_id { get => zakaznik_id; set => zakaznik_id = value; }

    }
}
