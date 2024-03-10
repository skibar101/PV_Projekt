using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    internal interface ICommand
    /// <summary>
    /// Interface kde jsou definované metody, co můžou být provedeny.
    /// </summary>
    {
        public void Execute(); //Metoda, která provede operaci.

        /// <summary>
        /// Metoda pro získání informace operaci.
        /// </summary>
        /// <returns>Informace o operaci.</returns>
        
        public string GetInfo();

        /// <summary>
        /// Metoda pro získání názvu operace.
        /// </summary>
        /// <returns>Název operace.</returns>
        public string GetName();

        /// <summary>
        /// Metoda, která ověřuje správnost dat na vstupu.
        /// </summary>
        /// <param name="input">Vstupní data.</param>
        /// <returns>True, pokud jsou data platná, jinak false.</returns>
        public bool ValidateInput(string input);
    }
}
