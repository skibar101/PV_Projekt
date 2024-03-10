using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    /// <summary>
    /// Třída pro přístup k datům  pomocí DAO>.
    /// </summary>
    internal class PlatbaDao : IRepozitory<Platba>
    {

        /// <summary>
        /// Smaže entitu z databáze.
        /// </summary>
        /// <param name="platba">Entita, která má být smazána.</param>
        public void Delete(Platba platba)
        {
            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Platba WHERE id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", platba.Id);
                    command.ExecuteNonQuery();
                }
            
            
        }
        /// <summary>
        /// Načte všechny entity z databáze.
        /// </summary>
        /// <returns>Výčet všech entit.</returns>
        public IEnumerable<Platba> GetAll()
        {
            List<Platba> platby = new List<Platba>();

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Platba", conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Platba platba = new Platba
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Objednavka_id = Convert.ToInt32(reader["objednavka_id"]),
                            Castka = Convert.ToSingle(reader["castka"]),
                            Datum = Convert.ToDateTime(reader["datum"])
                        };
                        platby.Add(platba);
                    }
                    reader.Close();
                }
            
            

            return platby;
        }

        /// <summary>
        /// Načte entitu z databáze podle zadaného id.
        /// </summary>
        /// <param name="id">id hledané entity.</param>
        /// <returns>Entitu nebo null pokud není nalezena.</returns>
        public Platba GetByID(int id)
        {
            SqlConnection conn = Singleton.GetInstance();
            Platba platba = null;

            
               
                using (SqlCommand command = new SqlCommand("SELECT * FROM Platba WHERE id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        platba = new Platba
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Objednavka_id = Convert.ToInt32(reader["objednavka_id"]),
                            Castka = Convert.ToSingle(reader["castka"]),
                            Datum = Convert.ToDateTime(reader["datum"])
                        };
                    }
                    reader.Close();
                }
            
            

            return platba;
        }
        /// <summary>
        /// Uloží entitu do databáze.
        /// </summary>
        /// <param name="platba">Entita, která má být uložena.</param>
        public void Save(Platba platba)
        {
            SqlConnection conn = Singleton.GetInstance();


            if (platba.Id == 0)
                {
                  
                    using (SqlCommand command = new SqlCommand("INSERT INTO Platba (objednavka_id, castka, datum) VALUES (@Objednavka_id, @Castka, @Datum)", conn))
                    {
                        command.Parameters.AddWithValue("@Objednavka_id", platba.Objednavka_id);
                        command.Parameters.AddWithValue("@Castka", platba.Castka);
                        command.Parameters.AddWithValue("@Datum", platba.Datum);
                        command.ExecuteNonQuery();
                    }
                }   
                else
                {
                   
                    using (SqlCommand command = new SqlCommand("UPDATE Platba SET objednavka_id = @Objednavka_id, castka = @Castka, datum = @Datum WHERE id = @Id", conn))
                    {
                        command.Parameters.AddWithValue("@Objednavka_id", platba.Objednavka_id);
                        command.Parameters.AddWithValue("@Castka", platba.Castka);
                        command.Parameters.AddWithValue("@Datum", platba.Datum);
                        command.Parameters.AddWithValue("@Id", platba.Id);
                        command.ExecuteNonQuery();
                    }
                }
        }
    }
}
