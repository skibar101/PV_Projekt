using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    internal class AddCustomer : ICommand
    {
        /// <summary>
        /// Metoda pro přidáni zákazníka
        /// </summary>
        public void Execute()
        {
            
            Console.WriteLine("Zadejte jméno zákazníka:");//uživatel zadá jméno
            string jmeno = Console.ReadLine();

            Console.WriteLine("Zadejte příjmení zákazníka:"); //uživatel zadá přijmení
            string prijmeni = Console.ReadLine();

            Console.WriteLine("Zadejte email zákazníka:");//uživatel zadá mail
            string email = Console.ReadLine();

            Console.WriteLine("Zadejte věk zákazníka:");//uživatel zadá věk
            int vek;
            while (!int.TryParse(Console.ReadLine(), out vek))
            {
                Console.WriteLine("Neplatný věk. Zadejte prosím číslo.");
            }

           
            Zakaznik newCustomer = new Zakaznik(jmeno, prijmeni, email, vek);

          
            ZakaznikDao dao = new ZakaznikDao(); //načtení dao zákazníka
            dao.Save(newCustomer);

            Console.WriteLine("Zákazník byl úspěšně přidán do databáze.");
        }
        /// <summary>
        /// Info o metodě
        /// </summary>
        public string GetInfo()
        {
            return "Přidat nového zákazníka do databáze.";
        }
        /// <summary>
        /// Název v rozhraní
        /// </summary>
        public string GetName()
        {
            return "Přidání zákazníka";
        }
        /// <summary>
        /// validace
        /// </summary>
        public bool ValidateInput(string input)
        {
            return true;
        }
    }
}
