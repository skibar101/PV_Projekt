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
    internal class ObjednavkaDao : IRepozitory<Objednavka>
    {
        /// <summary>
        /// Smaže entitu z databáze.
        /// </summary>
        /// <param name="objednavka">Entita, která má být smazána.</param>
        public void Delete(Objednavka objednavka)
        {
            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Objednavka WHERE id = @Id", conn))
            {
                command.Parameters.AddWithValue("@Id", objednavka.Id);
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Načte všechny entity z databáze.
        /// </summary>
        /// <returns>Výčet všech entit.</returns>
        public IEnumerable<Objednavka> GetAll()
        {
            List<Objednavka> objednavky = new List<Objednavka>();

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavka", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Objednavka objednavka = new Objednavka
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Datum = Convert.ToDateTime(reader["datum"]),
                        Zakaznik_id = Convert.ToInt32(reader["zakaznik_id"])
                    };
                    objednavky.Add(objednavka);
                }
                reader.Close();
            }

            return objednavky;
        }
        /// <summary>
        /// Načte entitu z databáze podle id.
        /// </summary>
        /// <param name="id">id hledané entity.</param>
        /// <returns>Entitu nebo null pokud není nalezena.</returns>
        public Objednavka GetByID(int id)
        {
            Objednavka objednavka = null;

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavka WHERE id = @Id", conn))
            {
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    objednavka = new Objednavka
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Datum = Convert.ToDateTime(reader["datum"]),
                        Zakaznik_id = Convert.ToInt32(reader["zakaznik_id"])
                    };
                }
                reader.Close();
            }

            return objednavka;
        }
        /// <summary>
        /// Uloží entitu do databáze.
        /// </summary>
        /// <param name="objednavka">Entita, která má být uložena.</param>
        public void Save(Objednavka objednavka)
        {
            SqlConnection conn = Singleton.GetInstance();

            if (objednavka.Id == 0)
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO Objednavka (datum, zakaznik_id) VALUES (@Datum, @Zakaznik_id)", conn))
                {
                    command.Parameters.AddWithValue("@Datum", objednavka.Datum);
                    command.Parameters.AddWithValue("@Zakaznik_id", objednavka.Zakaznik_id);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand("UPDATE Objednavka SET datum = @Datum, zakaznik_id = @Zakaznik_id WHERE id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Datum", objednavka.Datum);
                    command.Parameters.AddWithValue("@Zakaznik_id", objednavka.Zakaznik_id);
                    command.Parameters.AddWithValue("@Id", objednavka.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
