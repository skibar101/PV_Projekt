using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
/// <summary>
/// Třída pro přístup k datům  pomocí DAO>.
/// </summary>
{
    internal class ZakaznikDao : IRepozitory<Zakaznik>
    {
        /// <summary>
        /// Smaže entitu z databáze.
        /// </summary>
        /// <param name="zakaznik">Entita, která má být smazána.</param>
        public void Delete(Zakaznik zakaznik)
        {
            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Zakaznik WHERE id = @Id", conn))
            {
                command.Parameters.AddWithValue("@Id", zakaznik.Id);
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Načte všechny entity z databáze.
        /// </summary>
        /// <returns>Výčet všech entit.</returns>
        public IEnumerable<Zakaznik> GetAll()
        {
            List<Zakaznik> zakaznici = new List<Zakaznik>();

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Zakaznik", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Zakaznik zakaznik = new Zakaznik
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Jmeno = reader["jmeno"].ToString(),
                        Prijmeni = reader["prijmeni"].ToString(),
                        Email = reader["email"].ToString(),
                        Vek = Convert.ToInt32(reader["vek"])
                    };
                    zakaznici.Add(zakaznik);
                }
                reader.Close();
            }

            return zakaznici;
        }
        /// <summary>
        /// Načte entitu z databáze podle zadaného id.
        /// </summary>
        /// <param name="id">id hledané entity.</param>
        /// <returns>Entitu nebo null pokud není nalezena.</returns>
        public Zakaznik GetByID(int id)
        {
            Zakaznik zakaznik = null;

            SqlConnection conn = Singleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Zakaznik WHERE id = @Id", conn))
            {
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    zakaznik = new Zakaznik
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Jmeno = reader["jmeno"].ToString(),
                        Prijmeni = reader["prijmeni"].ToString(),
                        Email = reader["email"].ToString(),
                        Vek = Convert.ToInt32(reader["vek"])
                    };
                }
                reader.Close();
            }

            return zakaznik;
        }
        /// <summary>
        /// Uloží entitu do databáze.
        /// </summary>
        /// <param name="zakaznik">Entita, která má být uložena.</param>
        public void Save(Zakaznik zakaznik)
        {
            SqlConnection conn = Singleton.GetInstance();

            if (zakaznik.Id == 0)
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO Zakaznik (jmeno, prijmeni, email, vek) VALUES (@Jmeno, @Prijmeni, @Email, @Vek)", conn))
                {
                    command.Parameters.AddWithValue("@Jmeno", zakaznik.Jmeno);
                    command.Parameters.AddWithValue("@Prijmeni", zakaznik.Prijmeni);
                    command.Parameters.AddWithValue("@Email", zakaznik.Email);
                    command.Parameters.AddWithValue("@Vek", zakaznik.Vek);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand("UPDATE Zakaznik SET jmeno = @Jmeno, prijmeni = @Prijmeni, email = @Email, vek = @Vek WHERE id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Jmeno", zakaznik.Jmeno);
                    command.Parameters.AddWithValue("@Prijmeni", zakaznik.Prijmeni);
                    command.Parameters.AddWithValue("@Email", zakaznik.Email);
                    command.Parameters.AddWithValue("@Vek", zakaznik.Vek);
                    command.Parameters.AddWithValue("@Id", zakaznik.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
