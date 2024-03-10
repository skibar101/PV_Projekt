using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{   /// <summary>
    /// Třída pro přístup k datům  pomocí DAO>.
    /// </summary>
    internal class Objednavka_produktDao : IRepozitory<Objednavka_produkt>
    { /// <summary>
      /// Smaže entitu z databáze.
      /// </summary>
      /// <param name="objednavkaProdukt">Entita, která má být smazána.</param>
        public void Delete(Objednavka_produkt objednavkaProdukt)
        {
            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Objednavka_produkt WHERE id = @Id", conn))
            {
                command.Parameters.AddWithValue("@Id", objednavkaProdukt.Id);
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Načte všechny entity z databáze.
        /// </summary>
        /// <returns>Výčet všech entit.</returns>
        public IEnumerable<Objednavka_produkt> GetAll()
        {
            List<Objednavka_produkt> objednavkaProdukty = new List<Objednavka_produkt>();

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavka_produkt", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Objednavka_produkt objednavkaProdukt = new Objednavka_produkt
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Mnozstvi = Convert.ToInt32(reader["mnozstvi"]),
                        Objednavka_id = Convert.ToInt32(reader["objednavka_id"]),
                        Produkt_id = Convert.ToInt32(reader["produkt_id"])
                    };
                    objednavkaProdukty.Add(objednavkaProdukt);
                }
                reader.Close();
            }

            return objednavkaProdukty;
        }
        /// <summary>
        /// Načte entitu z databáze podle zadaného id.
        /// </summary>
        /// <param name="id">id hledané entity.</param>
        /// <returns>Entitu nebo null pokud není nalezena.</returns>
        public Objednavka_produkt GetByID(int id)
        {
            Objednavka_produkt objednavkaProdukt = null;

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavka_produkt WHERE id = @Id", conn))
            {
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    objednavkaProdukt = new Objednavka_produkt
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Mnozstvi = Convert.ToInt32(reader["mnozstvi"]),
                        Objednavka_id = Convert.ToInt32(reader["objednavka_id"]),
                        Produkt_id = Convert.ToInt32(reader["produkt_id"])
                    };
                }
                reader.Close();
            }

            return objednavkaProdukt;
        }
        /// <summary>
        /// Uloží entitu do databáze.
        /// </summary>
        /// <param name="objednavkaProdukt">Entita, která má být uložena.</param>
        public void Save(Objednavka_produkt objednavkaProdukt)
        {
            SqlConnection conn = Singleton.GetInstance();

            if (objednavkaProdukt.Id == 0)
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO Objednavka_produkt (mnozstvi, objednavka_id, produkt_id) VALUES (@Mnozstvi, @Objednavka_id, @Produkt_id)", conn))
                {
                    command.Parameters.AddWithValue("@Mnozstvi", objednavkaProdukt.Mnozstvi);
                    command.Parameters.AddWithValue("@Objednavka_id", objednavkaProdukt.Objednavka_id);
                    command.Parameters.AddWithValue("@Produkt_id", objednavkaProdukt.Produkt_id);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand("UPDATE Objednavka_produkt SET mnozstvi = @Mnozstvi, objednavka_id = @Objednavka_id, produkt_id = @Produkt_id WHERE id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Mnozstvi", objednavkaProdukt.Mnozstvi);
                    command.Parameters.AddWithValue("@Objednavka_id", objednavkaProdukt.Objednavka_id);
                    command.Parameters.AddWithValue("@Produkt_id", objednavkaProdukt.Produkt_id);
                    command.Parameters.AddWithValue("@Id", objednavkaProdukt.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
