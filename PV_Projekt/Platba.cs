using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
/// <summary>
/// Třída, která reprezentuje tabulku platby, ve třídě jsou pouze vlastnosti, konstruktory, gettery & settery a metoda to string
/// </summary>
{
    internal class Platba : IBaseClass
    {
        private int id;
        private int objednavka_id;
        private float castka;
        private DateTime datum;

        public Platba(int id, int objednavka_id, float castka, DateTime datum)
        {
            this.id = id;
            this.objednavka_id = objednavka_id;
            this.castka = castka;
            this.datum = datum;
        }

        public Platba(int objednavka_id, float castka, DateTime datum)
        {
            this.id = 0;
            this.objednavka_id = objednavka_id;
            this.castka = castka;
            this.datum = datum;
        }

        public Platba()
        {
           
        }

        public int Id { get => id; set => id = value; }
        public int Objednavka_id { get => objednavka_id; set => objednavka_id = value; }
        public float Castka { get => castka; set => castka = value; }
        public DateTime Datum { get => datum; set => datum = value; }

        public override string ToString()
        {
            return $"ID: {id}, Objednávka ID: {objednavka_id}, Částka: {castka}, Datum: {datum}";
        }


    }
}
