using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryWalmart.ModelRepors;

namespace InventoryWalmart.Database
{
    internal class ReporteDAO
    {
        // traer todos los datos de los reporte 
        //- ventas toteles por categorias

        public List<ventasTotalesCategorias> ventasTotalesCategorias(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ventasTotalesCategorias> lista = new List<ventasTotalesCategorias>();

            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("sp_reporte_ventas_por_categoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha_inicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fecha_fin", fechaFin);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ventasTotalesCategorias vtc = new ventasTotalesCategorias();
                        vtc.nombreCategoria = (reader.GetString(0));
                        vtc.totalPrecioVenta = Convert.ToDouble(reader.GetDecimal(1));
                        vtc.totalVentas = (reader.GetInt32(2));

                        lista.Add(vtc);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer datos para el reporte" + ex);
            }

            return lista;
        }

        //- ventas echas por el cajero
        
        public List<ventasPorCajero> ventasPosCajeros(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ventasPorCajero> lista = new List<ventasPorCajero>();

            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("ReporteVentasPorCajero", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ventasPorCajero ventas = new ventasPorCajero();
                        ventas.nombreCajero = (reader.GetString(0));
                        ventas.apellidoCajero = (reader.GetString(1));
                        ventas.numeroTranscciones = (reader.GetInt32(2));
                        ventas.productosVendidos = (reader.GetInt32(3));
                        ventas.totalVendidos = (Convert.ToDouble(reader.GetDecimal(4)));
                        ventas.promedioVentas = (Convert.ToDouble(reader.GetDecimal(5)));
                        lista.Add(ventas);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pude optener los datos: " + ex.Message);
                MessageBox.Show("No se pude optener los datos: " + ex);

            }
            return lista;
        }


        // compras de clientes 
        public List<gastosClientesTarjeta> gastosClientesTarjeta(DateTime fechaInicio, DateTime fechaFin)
        {
            List<gastosClientesTarjeta> lista = new List<gastosClientesTarjeta>();

            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("sp_reporte_gastos_clientes_tarjeta", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gastosClientesTarjeta gasto = new gastosClientesTarjeta();
                        gasto.nombreCliente = reader.GetString(0);
                        gasto.apellidoCliente = reader.GetString(1);
                        gasto.CardNumber = reader.GetString(2);

                        gasto.NumeroCompras = reader.GetInt32(3);
                        gasto.ProductosComprados = reader.GetInt32(4);
                        gasto.TotalGastado = reader.GetDecimal(5);
                    //    gasto.BeneficiosAdquiridos = reader.GetString(6);

                        lista.Add(gasto);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pude trear los datos de gastos clientes tarjeta: " + ex.Message);            
            }


            return lista;
        }

        // - Historial de ventas

        public List<HistorialVentas> ObtenerHistorialVentas(DateTime fechaInicio, string modo)
        {
            List<HistorialVentas> lista = new List<HistorialVentas>();

            try
            {
                using (SqlConnection conn = Connection.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_historial_ventas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fecha_inicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@modo", modo);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        HistorialVentas hv = new HistorialVentas
                        {
                            periodo = reader.GetDateTime(0),
                            cantidadVentas = reader.GetInt32(1),
                            totalVendido = Convert.ToDouble(reader.GetDecimal(2)),
                            totalInvertido = Convert.ToDouble(reader.GetDecimal(3)),
                            ganancia = Convert.ToDouble(reader.GetDecimal(4)),
                        };
                        lista.Add(hv);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial de ventas: " + ex.Message);
            }

            return lista;
        }

        // promociones
        public List<Promociones> promociones()
        {
            List<Promociones> lista = new List<Promociones>();

            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("sp_promociones", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Promociones prom = new Promociones();

                    prom.decripcion = reader.GetString(0);
                    prom.noseCODE = reader.GetString(1);
                    prom.noseTYPE = reader.GetString(2);
                    prom.status = reader.GetString(3);
                    lista.Add(prom);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show ("No se pudo traer los datos de promiciones" + ex.Message);
            }

            return lista;
        }







    }
}
