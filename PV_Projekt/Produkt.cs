using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    /// <summary>
    /// Třída, která reprezentuje tabulku produktu, ve třídě jsou pouze vlastnosti, konstruktory, gettery & settery a metoda to string
    /// </summary>
    internal class Produkt : IBaseClass
    {

        private int id;
        private string nazev;
        private double cena;
        private bool skladem;

        public Produkt(int id, string nazev, double cena, bool skladem)
        {
            this.id = id;
            this.nazev = nazev;
            this.cena = cena;
            this.skladem = skladem;
        }

        public Produkt(string nazev, double cena, bool skladem)
        {
            this.id = 0;
            this.nazev = nazev;
            this.cena = cena;
            this.skladem = skladem;
        }

        public Produkt()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Nazev { get => nazev; set => nazev = value; }
        public double Cena { get => cena; set => cena = value; }
        public bool Skladem { get => skladem; set => skladem = value; }

        public override string ToString()
        {
            return $"ID: {Id}, Název: {Nazev}, Cena: {Cena}, Skladem: {(Skladem ? "Ano" : "Ne")}";
        }

    }
}
