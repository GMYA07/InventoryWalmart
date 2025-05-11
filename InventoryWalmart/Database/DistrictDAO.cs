using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;

namespace InventoryWalmart.Database
{

    internal class DistrictDAO
    {
        public static List<District> TraerDistrict(int id)
        {
            List<District> lista = new List<District>();

            string query = $"SELECT Id_district, district_Name, id_department FROM district WHERE id_department = {id}";
            SqlConnection connection = Connection.ObtenerConexion();
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                District dist = new District
                {
                    Id_district = reader.GetInt32(0),
                    district_Name = reader.GetString(1),
                    id_department = reader.GetInt32(2)
                };
                lista.Add(dist);
            }

            reader.Close();
            connection.Close();

            return lista;
        }

    }
}
