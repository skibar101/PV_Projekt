using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
/// <summary>
/// Třída, která reprezentuje tabulku objednavka_produkt, ve třídě jsou pouze vlastnosti, konstruktory, gettery & settery a metoda to string
/// </summary>
{
    internal class Objednavka_produkt : IBaseClass
    {
        private int id;
        private int mnozstvi;
        private int objednavka_id;
        private int produkt_id;

        public Objednavka_produkt(int id, int mnozstvi, int objednavka_id, int produkt_id)
        {
            this.id = id;
            this.mnozstvi = mnozstvi;
            this.objednavka_id = objednavka_id;
            this.produkt_id = produkt_id;
        }

        public Objednavka_produkt(int mnozstvi, int objednavka_id, int produkt_id)
        {
            this.id = 0;
            this.mnozstvi = mnozstvi;
            this.objednavka_id = objednavka_id;
            this.produkt_id = produkt_id;
        }

        public Objednavka_produkt()
        {
         
        }

        public int Id { get => id; set => id = value; }
        public int Mnozstvi { get => mnozstvi; set => mnozstvi = value; }
        public int Objednavka_id { get => objednavka_id; set => objednavka_id = value; }
        public int Produkt_id { get => produkt_id; set => produkt_id = value; }

        public override string ToString()
        {
            return $"ID: {id}, Množství: {mnozstvi}, Objednávka ID: {objednavka_id}, Produkt ID: {produkt_id}";
        }
    }
}
