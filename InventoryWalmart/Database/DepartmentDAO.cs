using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;

namespace InventoryWalmart.Database
{
    internal class DepartmentDAO
    {
        public static List<Department> TraerDepartments()
        {
            List<Department> lista = new List<Department>();

            string query = "SELECT id_department, department_name FROM department";
            SqlConnection connection = Connection.ObtenerConexion();
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Department dept = new Department
                {
                    id_department = reader.GetInt32(0),
                    department_name = reader.GetString(1)
                };
                lista.Add(dept);
            }

            reader.Close();
            connection.Close();

            return lista;
        }

    }
}

