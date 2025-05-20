using InventoryWalmart.Model;
using InventoryWalmart.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryWalmart.Database
{
    internal class SupplierDAO_
    {
        public static List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            string query = @"SELECT
                            s.id_supplier,
                            s.manager_name,
                            s.company_name,
                            s.email,
                            s.phone,
                            d.department_name
                        FROM SUPPLIERS AS s
                        INNER JOIN DEPARTMENT AS d ON s.id_department = d.id_department
                        ;";
            SqlConnection connection = Connection.ObtenerConexion();
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Supplier supplier = new Supplier
                {
                    id_supplier = reader.GetInt32(0),
                    manager_name = reader.GetString(1),
                    company_name = reader.GetString(2),
                    email = reader.GetString(3),
                    phone = reader.GetString(4),
                    department_name = reader.GetString(5)
                };
                suppliers.Add(supplier);
            }

            reader.Close();
            connection.Close();

            return suppliers;
        }

        public static Supplier GetInfoSup(int id)
        {
            Supplier suppliers = new Supplier();

            string query = $@"SELECT
                            s.id_supplier,
                            s.manager_name,
                            s.company_name,
                            s.email,
                            s.phone,
                            d.id_department
                        FROM SUPPLIERS AS s
                        INNER JOIN DEPARTMENT AS d ON s.id_department = d.id_department
                        WHERE s.id_supplier = {id};";
            SqlConnection connection = Connection.ObtenerConexion();
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Supplier supplier = new Supplier
                {
                    id_supplier = reader.GetInt32(0),
                    manager_name = reader.GetString(1),
                    company_name = reader.GetString(2),
                    email = reader.GetString(3),
                    phone = reader.GetString(4),
                    id_department = reader.GetInt32(5)
                };
                suppliers = supplier;
            }

            reader.Close();
            connection.Close();

            return suppliers;
        }

        public static int GetidSup(string email)
        {
            int id = 0;

            string query = $@"SELECT
                            s.id_supplier
                        FROM SUPPLIERS AS s
                        WHERE s.email = '{email}';";
            SqlConnection connection = Connection.ObtenerConexion();
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                id = reader.GetInt32(0);

            }

            reader.Close();
            connection.Close();

            return id;
        }

        public static void InsertSupplier(Supplier supplier)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("insert_Supplier", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@manager_name", supplier.manager_name);
                    command.Parameters.AddWithValue("@company_name", supplier.company_name);
                    command.Parameters.AddWithValue("@email", supplier.email);
                    command.Parameters.AddWithValue("@phone", supplier.phone);
                    command.Parameters.AddWithValue("@id_department", supplier.id_department);

                    connection.Open();

                    Alertas.AlertCorrect("Exito","Usuario Agregado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UpdateSupplier(Supplier supplier)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("update_Supplier", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_supplier", supplier.id_supplier);
                    command.Parameters.AddWithValue("@manager_name", supplier.manager_name);
                    command.Parameters.AddWithValue("@company_name", supplier.company_name);
                    command.Parameters.AddWithValue("@email", supplier.email);
                    command.Parameters.AddWithValue("@phone", supplier.phone);
                    command.Parameters.AddWithValue("@id_department", supplier.id_department);

                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

                    Alertas.AlertCorrect("Exito", "Usuario actualizado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteSupplier(int id)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("delete_Supplier", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_supplier", id);

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
