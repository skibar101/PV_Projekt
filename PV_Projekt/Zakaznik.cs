using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    /// <summary>
    /// Třída, která reprezentuje tabulku zákazníka, ve třídě jsou pouze vlastnosti, konstruktory, gettery & settery a metoda to string
    /// </summary>
    internal class Zakaznik : IBaseClass
    {
        private int id;
        private string jmeno;
        private string prijmeni;
        private string email;
        private int vek;

        public Zakaznik(int id, string jmeno, string prijmeni, string email, int vek)
        {
            this.id = id;
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.email = email;
            this.vek = vek;
        }

        public int Id { get => id; set => id = value; }
        public string Jmeno { get => jmeno; set => jmeno = value; }
        public string Prijmeni { get => prijmeni; set => prijmeni = value; }
        public string Email { get => email; set => email = value; }
        public int Vek { get => vek; set => vek = value; }

        public Zakaznik(string jmeno, string prijmeni, string email, int vek)
        {
            this.id = 0;
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.email = email;
            this.vek = vek;
        }

        public Zakaznik() { }


        public override string ToString()
        {
            return $"ID: {Id}, Jméno: {Jmeno}, Příjmení: {Prijmeni}, Email: {Email}, Věk: {Vek}";
        }
    }
}
