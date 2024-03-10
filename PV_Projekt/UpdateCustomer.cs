using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    internal class UpdateCustomer: ICommand
    {
        /// <summary>
        /// Provede aktualizaci údajů
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Zadejte id zákazníka, jehož údaje chcete upravit:");
            int customerId;
            while (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Neplatné id. Zadejte prosím číslo.");
            }

            try
            {
                using (SqlConnection conn = Singleton.GetInstance())
                {
                   
                    var existingCustomer = GetCustomerById(conn, customerId); // Získání nynějších údajů zákazníka

                    if (existingCustomer != null)
                    {
                       
                        Console.WriteLine($"Stávající údaje zákazníka s id {customerId}:");
                        Console.WriteLine(existingCustomer.ToString());

                       
                        Console.WriteLine("Zadejte nové údaje zákazníka:");  //Aktualizace údajů
                         
                        Console.Write("Jméno: "); //nové jméno
                        string jmeno = Console.ReadLine();

                        Console.Write("Příjmení: ");//nové přijemní
                        string prijmeni = Console.ReadLine();

                        Console.Write("Email: ");//nový mail
                        string email = Console.ReadLine();

                        Console.Write("Věk: ");//nový věk
                        int vek;
                        while (!int.TryParse(Console.ReadLine(), out vek))
                        {
                            Console.WriteLine("Neplatný věk. Zadejte prosím číslo.");
                        }

                        /// <summary>
                        /// Uložení nových údajů
                        /// </summary>
                        UpdateCustomerInDatabase(conn, customerId, jmeno, prijmeni, email, vek);

                        Console.WriteLine($"Údaje zákazníka s id {customerId} byly úspěšně aktualizovány.");
                    }
                    else
                    {
                        Console.WriteLine($"Zákazník s id {customerId} nebyl nalezen v databázi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při aktualizaci údajů zákazníka: {ex.Message}");
            }
        }

        /// <summary>
        /// nalezení zákazníka podle id
        /// </summary>
        private Zakaznik GetCustomerById(SqlConnection conn, int customerId)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Zakaznik WHERE id = @Id", conn))
            {
                command.Parameters.AddWithValue("@Id", customerId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Zakaznik
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Jmeno = reader.GetString(reader.GetOrdinal("jmeno")),
                            Prijmeni = reader.GetString(reader.GetOrdinal("prijmeni")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            Vek = reader.GetInt32(reader.GetOrdinal("vek"))
                        };
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Aktualizováni údajů v db
        /// </summary>
        private void UpdateCustomerInDatabase(SqlConnection conn, int customerId, string jmeno, string prijmeni, string email, int vek)
        {
            using (SqlCommand command = new SqlCommand("UPDATE Zakaznik SET jmeno = @Jmeno, prijmeni = @Prijmeni, email = @Email, vek = @Vek WHERE id = @Id", conn))
            {
                command.Parameters.AddWithValue("@Jmeno", jmeno);
                command.Parameters.AddWithValue("@Prijmeni", prijmeni);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Vek", vek);
                command.Parameters.AddWithValue("@Id", customerId);
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// info o metodě
        /// </summary>
        public string GetInfo()
        {
            return "Aktualizuje údaje zákazníka v databázi";
        }
        /// <summary>
        /// název v rozhraní
        /// </summary>
        public string GetName()
        {
            return "Aktualizace údajů zákazníka";
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
