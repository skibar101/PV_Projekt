using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    internal class DeleteCustomer :ICommand
    {/// <summary>
     /// metoda, která maže zákazníka z databáze
     /// </summary>
        public void Execute()
        {
            Console.WriteLine("Zadejte id zákazníka, kterého chcete smazat:");
            int customerId;
            while (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Neplatné id. Zadejte prosím číslo.");
            }

            try
            {
                using (SqlConnection conn = Singleton.GetInstance())
                {
                   
                    using (SqlCommand command = new SqlCommand("DELETE FROM Zakaznik WHERE id = @Id", conn))
                    {
                        command.Parameters.AddWithValue("@Id", customerId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Zákazník s id {customerId} byl úspěšně smazán z databáze.");
                        }
                        else
                        {
                            Console.WriteLine($"Zákazník s id {customerId} nebyl nalezen v databázi.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při mazání zákazníka: {ex.Message}");
            }
        }
        /// <summary>
        /// info o metodě
        /// </summary>
        public string GetInfo()
        {
            return "Smaže zákazníka z databáze";
        }
        /// <summary>
        /// název v rozhraní
        /// </summary>
        public string GetName()
        {
            return "Smazání zákazníka";
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
