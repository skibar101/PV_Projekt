using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    internal class ListUsers : ICommand
    {

        /// <summary>
        /// Metoda která vypíše všechny zákazníky
        /// </summary>
        void ICommand.Execute()
        {
            ZakaznikDao dao = new ZakaznikDao();

            var all = dao.GetAll().ToList();

            all.ForEach(c => Console.WriteLine(c));
        }
        /// <summary>
        /// Info o metodě
        /// </summary>
        string ICommand.GetInfo()
        {
            return "vypíše všechny zákazníky";
        }
        // <summary>
        /// Jméno v rozhraní
        /// </summary>
        string ICommand.GetName()
        {
            return "Vypsaní všech zákazníků ";
        }
        // <summary>
        /// Validace
        /// </summary>
        bool ICommand.ValidateInput(string input)
        {
           
            return false;
        }

    }
}
