using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    // <summary>
    /// Třída pro přístup k datům  pomocí DAO>.
    /// </summary>
    internal class ProduktDao : IRepozitory<Produkt>
    {

        /// <summary>
        /// Smaže entitu z databáze.
        /// </summary>
        /// <param name="produkt">Entita, která má být smazána.</param>
        public void Delete(Produkt produkt)
        {

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Produkt WHERE id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", produkt.Id);
                    command.ExecuteNonQuery();
                }
            
           
        }
        /// <summary>
        /// Načte všechny entity z databáze.
        /// </summary>
        /// <returns>Výčet všech entit.</returns>
        public IEnumerable<Produkt> GetAll()
        {
            List<Produkt> produkty = new List<Produkt>();

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Produkt", conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Produkt produkt = new Produkt
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nazev = reader["nazev"].ToString(),
                            Cena = Convert.ToDouble(reader["cena"]),
                            Skladem = Convert.ToBoolean(reader["skladem"])
                        };
                        produkty.Add(produkt);
                    }
                    reader.Close();
                }
            
            

            return produkty;
        }
        /// <summary>
        /// Načte entitu z databáze podle zadaného id.
        /// </summary>
        /// <param name="id">id hledané entity.</param>
        /// <returns>Entitu nebo null pokud není nalezena.</returns>
        public Produkt GetByID(int id)
        {
            Produkt produkt = null;

            SqlConnection conn = Singleton.GetInstance();



            using (SqlCommand command = new SqlCommand("SELECT * FROM Produkt WHERE id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        produkt = new Produkt
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nazev = reader["nazev"].ToString(),
                            Cena = Convert.ToDouble(reader["cena"]),
                            Skladem = Convert.ToBoolean(reader["skladem"])
                        };
                    }
                    reader.Close();
                }
            
            

            return produkt;
        }
        /// <summary>
        /// Uloží entitu do databáze.
        /// </summary>
        /// <param name="produkt">Entita, která má být uložena.</param>
        public void Save(Produkt produkt)
        {
            SqlConnection conn = Singleton.GetInstance();

            if (produkt.Id == 0)
                {
                   
                    using (SqlCommand command = new SqlCommand("INSERT INTO Produkt (nazev, cena, skladem) VALUES (@Nazev, @Cena, @Skladem)", conn))
                    {
                        command.Parameters.AddWithValue("@Nazev", produkt.Nazev);
                        command.Parameters.AddWithValue("@Cena", produkt.Cena);
                        command.Parameters.AddWithValue("@Skladem", produkt.Skladem);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                  
                    using (SqlCommand command = new SqlCommand("UPDATE Produkt SET nazev = @Nazev, cena = @Cena, skladem = @Skladem WHERE id = @Id", conn))
                    {
                        command.Parameters.AddWithValue("@Nazev", produkt.Nazev);
                        command.Parameters.AddWithValue("@Cena", produkt.Cena);
                        command.Parameters.AddWithValue("@Skladem", produkt.Skladem);
                        command.Parameters.AddWithValue("@Id", produkt.Id);
                        command.ExecuteNonQuery();
                    }
                }
            
            
        }
    }
}
