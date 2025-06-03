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
                SqlCommand cmd = new SqlCommand("sp_reporte_gastos_clientes_tarjetas", conn);
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
                    prom.discount_amount = reader.GetDecimal(1);
                    prom.codigoDescuento = reader.GetString(2);
                    prom.tipodescuento = reader.GetString(3);
                    prom.status = reader.GetString(4);
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

        // ter los reportes aumomatizados
        // Reportes diarios

        public List<VentasDiarias> ObtenerVentasDiarias(int id)
        {
            List<VentasDiarias> lista = new List<VentasDiarias>();

            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerVentasDiarias", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        VentasDiarias vd = new VentasDiarias
                        {
                            id_ventaDia = reader.GetInt32(0),
                            fecha_reporte = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1),
                            total_productos = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            sup_total = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3),
                            total_descuento = reader.IsDBNull(4) ? 0m : reader.GetDecimal(4),
                            total_venta = reader.IsDBNull(5) ? 0m : reader.GetDecimal(5),
                        };
                        lista.Add(vd);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo traer los datos de ventas diarias: " + ex.Message);
            }

            return lista;
        }



        // traer las categorias por dias
        public List<CategoriasDIA> categoriasDIAs(DateTime fecha)
        {
            List<CategoriasDIA> lista = new List<CategoriasDIA>();

            try
            {
                string sql = "select * from REPORTE_VENTAS_DIARIAS_CATEGORIAS where fecha = @fecha;";

                using (SqlConnection conn = Connection.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoriasDIA c = new CategoriasDIA
                            {
                                fecha = reader.GetDateTime(1),
                                nombreCategoria = reader.GetString(2),
                                dineroVentas = reader.GetDecimal(3),
                                totalVentas = reader.GetInt32(4)
                            };
                            lista.Add(c);
                        }

                    }

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pude taer los datos de categorias dias: " + ex.Message);
            }

            return lista;

        }













        // reportes de ventas mensuales

        public List<VentasSemanuales> ventaSamana(int id)
        {
            List<VentasSemanuales> lista = new List<VentasSemanuales>();

            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerVentasSemanuales", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        VentasSemanuales vs = new VentasSemanuales
                        {
                            id_reporte = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            inicio_semana = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1),
                            fin_semana = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2),
                            cantidad_ventas = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            inversion = reader.IsDBNull(4) ? 0m : reader.GetDecimal(4),
                            subtotal = reader.IsDBNull(5) ? 0m : reader.GetDecimal(5),
                            total = reader.IsDBNull(6) ? 0m : reader.GetDecimal(6),
                            fecha_generacion = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7),
                        };

                        lista.Add(vs);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron obtener las ventas semanales: " + ex.Message);
            }

            return lista;
        }


        // treer las ventas categorisadas semanuales

        public List<CategoriasSemana> ObtenerReporteSemanalCategoria(DateTime inicio, DateTime fin)
        {
            List<CategoriasSemana> lista = new List<CategoriasSemana>();
            try
            {
                string sql =@"SELECT id_report, report_date, category_name, total_venta_categoria, total_ventas
                            from REPORT_WEEKLY_CATEGORY_SALES
                            WHERE report_date BETWEEN @inicio AND @fin;";


                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@inicio", inicio);
                    cmd.Parameters.AddWithValue("@fin", fin);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CategoriasSemana reporte = new CategoriasSemana
                        {
                            IdReporte = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            FechaReporte = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1),
                            NombreCategoria = reader.IsDBNull(2) ? "Sin categoría" : reader.GetString(2),
                            TotalVentaCategoria = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3),
                            TotalVentas = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                        };

                        lista.Add(reporte);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el reporte semanal por categoría: " + ex.Message);
            }

            return lista;
        }




        // tarer lo del mes-------------------------------------------------------------------------------------------------------

        public List<VentaMensual> ObtenerVentasMensuales(int id)
        {
            List<VentaMensual> lista = new List<VentaMensual>();

            try
            {
                string sql = "SELECT * FROM REPORTE_VENTAS_MENSUALES;";
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerVentasMensuales", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        VentaMensual vm = new VentaMensual
                        {
                            id_reporte_mes = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            mes_anio = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            cantidad_ventas = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            subtotal = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3),
                            total_descuento = reader.IsDBNull(4) ? 0m : reader.GetDecimal(4),
                            total_vendido = reader.IsDBNull(5) ? 0m : reader.GetDecimal(5),
                            inversion_mes = reader.IsDBNull(6) ? 0m : reader.GetDecimal(6),
                            ganancia_mes = reader.IsDBNull(7) ? 0m : reader.GetDecimal(7),
                            reinversion_20 = reader.IsDBNull(8) ? 0m : reader.GetDecimal(8),
                        };

                        lista.Add(vm);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de ventas mensuales: " + ex.Message);
            }

            return lista;
        }


        public List<CategoriasMes> ObtenerReporteMensualCategoria(DateTime inicio)
        {
            List<CategoriasMes> lista = new List<CategoriasMes>();
            try
            {
                // Definimos el rango de fechas para el mes
                DateTime fin = inicio.AddMonths(1);

                string sql = @"
            SELECT id_report, report_date, category_name, total_venta_categoria, total_ventas
            FROM REPORT_MESUAL_CATEGORY_SALES
            WHERE report_date >= @inicio AND report_date < @fin;
        ";

                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@inicio", inicio);
                    cmd.Parameters.AddWithValue("@fin", fin);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CategoriasMes reporte = new CategoriasMes
                        {
                            IdReporte = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            FechaReporte = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1),
                            NombreCategoria = reader.IsDBNull(2) ? "Sin categoría" : reader.GetString(2),
                            TotalVentaCategoria = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3),
                            TotalVentas = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                        };

                        lista.Add(reporte);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el reporte mensual por categoría: " + ex.Message);
            }

            return lista;
        }




    }
}
