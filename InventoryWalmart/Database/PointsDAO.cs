using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class PointsDAO
    {

        public static List<points> ObtenerPuntosClientes()
        {
            List<points> lista = new List<points>();

            string query = @"
    SELECT 
        cc.card_number, 
        CONCAT(c.first_name, ' ', c.last_name) AS customer,
        c.dui,
        cc.points_balance,
        SUM(p.points_change) AS total_points_change
    FROM CUSTOMER_CARD cc
    INNER JOIN CUSTOMERS c ON c.id_customer = cc.id_customer
    INNER JOIN POINTS_HISTORY p ON p.id_card = cc.id_card
    GROUP BY 
        cc.card_number, 
        c.first_name, 
        c.last_name, 
        c.dui, 
        cc.points_balance
    ORDER BY 
        cc.card_number;";

            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                points info = new points
                                {
                                    CardNumber = reader["card_number"].ToString(),
                                    Customer = reader["customer"].ToString(),
                                    Dui = reader["dui"].ToString(),
                                    PointsBalance = Convert.ToInt32(reader["points_balance"]),
                                    TotalPointsChange = Convert.ToInt32(reader["total_points_change"])
                                };
                                lista.Add(info);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return lista;
        }


        //consulta de visualizacion de puntos filtrada
        public static List<points> ObtenerPuntosPorNumeroTarjeta(string cardNumber)
        {
            List<points> lista = new List<points>();

            string query = @"
    SELECT 
        cc.card_number, 
        CONCAT(c.first_name, ' ', c.last_name) AS customer,
        c.dui,
        cc.points_balance,
        SUM(p.points_change) AS total_points_change
    FROM CUSTOMER_CARD cc
    INNER JOIN CUSTOMERS c ON c.id_customer = cc.id_customer
    INNER JOIN POINTS_HISTORY p ON p.id_card = cc.id_card
    WHERE cc.card_number LIKE @CardNumber
    GROUP BY 
        cc.card_number, 
        c.first_name, 
        c.last_name, 
        c.dui, 
        cc.points_balance
    ORDER BY 
        cc.card_number;";

            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CardNumber", "%" + cardNumber + "%");

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                points info = new points
                                {
                                    CardNumber = reader["card_number"].ToString(),
                                    Customer = reader["customer"].ToString(),
                                    Dui = reader["dui"].ToString(),
                                    PointsBalance = Convert.ToInt32(reader["points_balance"]),
                                    TotalPointsChange = Convert.ToInt32(reader["total_points_change"])
                                };
                                lista.Add(info);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al consultar puntos por tarjeta: " + ex.Message);
                    }
                }
            }

            return lista;
        }

        public static int ObtenerPuntosPorDui(string dui)
        {
            int puntos = 0;

            string query = @"
                            SELECT TOP 1 cc.points_balance
                            FROM CUSTOMER_CARD cc
                            INNER JOIN CUSTOMERS c ON c.id_customer = cc.id_customer
                            WHERE c.dui = @Dui
                            ORDER BY cc.issue_date DESC;"; // Retorna la tarjeta más reciente

            using (SqlConnection conn = Connection.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Dui", dui);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        puntos = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener puntos por DUI: " + ex.Message);
                }
            }

            return puntos;
        }


    }
}
