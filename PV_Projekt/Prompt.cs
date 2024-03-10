using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    /// <summary>
    /// Vytvoření prostředí pro komuniakci s uživatelem
    /// </summary>
    internal class Prompt
    {
        List<ICommand> commands = new List<ICommand>// Seznam dostupných příkazů.
        {
            new ListUsers()
        };

        void Start()
        {
            for (int i = 0; i < commands.Count; i++) // Prochází všeechny příkazy v seznamu.
            {
                Console.WriteLine(i + ") " + commands[i].GetName()); // Získává název každého příkazu pomocí metody GetName a vypisuje ho do konzole.
            }
        }
    }
}
