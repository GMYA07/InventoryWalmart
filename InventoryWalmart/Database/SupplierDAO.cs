ing System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;
using System.Reflection;

namespace InventoryWalmart.Database
{
    internal class SupplierDAO
    {

        Suppliers suppliers = new Suppliers();


        public List<Model.Suppliers> GetAll()
        {
            var suppliers = new List<Model.Suppliers>();

            string query = @"
        SELECT 
            S.id_supplier, 
            S.manager_name, 
            S.company_name, 
            S.email, 
            S.phone,
            D.department_name
        FROM SUPPLIERS S
        INNER JOIN DEPARTMENT D ON S.id_department = D.id_department";

            // Obtener la cadena de conexión (no el objeto conexión)
            string connectionString = Connection.ObtenerConexion();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))  // <-- Faltaba el query aquí
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Model.Suppliers
                            {
                                // Asegúrate que las propiedades coincidan con tu clase Model.Suppliers
                                id_supplier = (int)reader["id_supplier"],
                                manager_name = reader["manager_name"].ToString(),
                                company_name = reader["company_name"].ToString(),
                                email = reader["email"].ToString(),
                                phone = reader["phone"].ToString(),

                                // Si tu modelo tiene relación con Department
                                Department = new Department
                                {
                                    department_name = reader["department_name"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            return suppliers;
        }

    }
}
