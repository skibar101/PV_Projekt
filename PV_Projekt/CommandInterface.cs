using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    internal class CommandInterface
    /// <summary>
    /// Třída, která vytváří rozhraní pro komunikaci
    /// </summary>
    {
        private List<ICommand> commands;

        public CommandInterface(List<ICommand> commands)
        {
            this.commands = commands;
        }
        /// <summary>
        /// Zobrazí všechny příkazy
        /// </summary>
        public void ShowCommands()
        {
            Console.WriteLine("Pro ukončení programu zavřete konzoli");
            Console.WriteLine("Vyberte příkaz:");
            for (int i = 0; i < commands.Count; i++)//Zobrazuje dostupné příkazy
            {
                Console.WriteLine($"{i + 1}) {commands[i].GetName()}");
            }
        }
        /// <summary>
        /// Spustí  příkaz podle čísla(vstup), je zde cyklus, který se pořád opakuje dokud nezavřem okno
        /// </summary>
        public void RunCommand()
        {
            /// <summary>
            /// do while, který se stará o to, aby běželo rozhraní do té doby než uživatel ho zavře
            /// </summary>
            do
            {
                ShowCommands();
                Console.Write("Zadejte číslo příkazu: ");
                int commandNumber;
                if (!int.TryParse(Console.ReadLine(), out commandNumber) || commandNumber < 1 || commandNumber > commands.Count)
                {
                    Console.WriteLine("Neplatný příkaz.");
                    continue; 
                }

                Console.WriteLine("Spouštím vybraný příkaz...");
                commands[commandNumber - 1].Execute();

                Console.WriteLine("---------------------------------------------------------------------"); 
            } while (true);
        }
    }
}
