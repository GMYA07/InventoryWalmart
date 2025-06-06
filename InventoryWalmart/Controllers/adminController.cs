﻿using InventoryWalmart.Database;
using InventoryWalmart.Model;
using InventoryWalmart.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryWalmart.Controllers
{
    internal class adminController
    {
        public adminController() { }

        //instancia de clase DAO
        DiscountDAO discountDAO = new DiscountDAO();
        ReturnsDAO returnsDAO = new ReturnsDAO();

        public List<Discount> mostrarDescuentos(string estado)
        {
            List<Discount> listaDescuentos = new List<Discount>();
            listaDescuentos = discountDAO.obtenerDescuentos(estado);

            if (listaDescuentos == null)
            {
               return null;
            }

            return listaDescuentos;
        }

        public int agregarDescuento(decimal cantidadDescuento, string descripcionDescuento) {

            Discount nuevoDescuento = new Discount();
            nuevoDescuento.DiscountCode = codigoGenerado();
            nuevoDescuento.DiscountAmount = cantidadDescuento;
            nuevoDescuento.Description = descripcionDescuento;
            nuevoDescuento.DiscountType = "Porcentual";
            nuevoDescuento.Status = "activo";

            if (discountDAO.insertarDescuento(nuevoDescuento) > 0)
            {
                Alertas.AlertCorrect("Agregando Descuento", "El codigo de descuento es: " + nuevoDescuento.DiscountCode);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int modificarDescuento(Discount descuentoModi)
        {

            if (discountDAO.modificarDescuento(descuentoModi) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int eliminarDescuento(int idDescuento)
        {
            if (discountDAO.eliminarDescuento(idDescuento) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //PARTE DE DEVOLUCIONES

        public List<Returns> mostrarDevoluciones(string estado)
        {
            List<Returns> listaDevoluciones = new List<Returns>();
            listaDevoluciones = returnsDAO.obtenerDevoluciones(estado);

            if (listaDevoluciones == null)
            {
                return null;
            }

            return listaDevoluciones;
        }

        public List<Returns> mostrarDevolucionesEspecificas(int idVenta)
        {
            List<Returns> listaDevoluciones = new List<Returns>();
            listaDevoluciones = returnsDAO.obtenerDevolucionesEspecifica(idVenta);

            if (listaDevoluciones == null)
            {
                return null;
            }

            return listaDevoluciones;
        }


        public Sale obtenerVenta(int idVenta)
        {
            Sale venta = new Sale();
            SaleDAO saleDAO = new SaleDAO();
            venta = saleDAO.obtenerVentaConId(idVenta);

            if (venta == null)
            {
                return null ;
            }
            return venta;
        }

        public List<Sale_Details> listaDetallesVenta(int idVenta)
        {
            List<Sale_Details> sale_Details = new List<Sale_Details>();
            Sale_DetailsDAO sale_detailsDAO = new Sale_DetailsDAO();

            sale_Details = sale_detailsDAO.obtenerListaDeDetallesVentaSinTargeta(idVenta);

            if (sale_Details == null)
            {
                return null;
            }

            return sale_Details;
        }

        public Customer obtenerCustomer(int idCustomer)
        {
            Customer customer = new Customer();
            CustomerDAO customerDAO = new CustomerDAO();

            customer = customerDAO.obtenerCustomerWithId(idCustomer);

            if (customer == null) { 
                return null ;
            }
            return customer;
        }

        public int cambiarEstadoDevo(Returns devolucionActu)
        {
            if (returnsDAO.actualizarDevolucion(devolucionActu) > 0)
            {
                return 1;
            }
            return 0;
        }

        public int existenciaDevolucionAceptada(int idProducto, int idVenta)
        {
            List<Returns> lista = new List<Returns>();

            lista = returnsDAO.obtenerDevolucionesEspecificasDeUnaVenta_Aceptada("aceptada", idVenta);

            if (lista == null)
            {
                return 0;
            }
            else
            {
                foreach (Returns devo in lista)
                {
                    int idProductoDevoAceptada = extraerInfoDevolverDeComentario(devo.Description,1);
                    if (idProducto == idProductoDevoAceptada)
                    {
                        return 1;
                    }
                }
                return 0;
            }
        }

        public string validarAceptacionDevolucionCuandoExisteOtraDevo(int idProducto, int idVenta, int cantidadRetornar)
        {
            string nuevaDescripcion = "";

            List<Returns> lista = new List<Returns>();
            Product producto = new Product();
            ProductDAO productDAO = new ProductDAO();
            producto = productDAO.obtenerProducto(idProducto);

            lista = returnsDAO.obtenerDevolucionesEspecificasDeUnaVenta_Aceptada("aceptada", idVenta);

            if (lista == null)
            {
                Alertas.AlertError("Aceptando Devolucion", "No se pudo encontrar la lista por q es nula");
                return "error";
            }
            else
            {
                int nuevoRestanteProducto = 0;

                foreach (Returns devo in lista)
                {
                    int idProductoDevoAceptada = extraerInfoDevolverDeComentario(devo.Description, 1);
                    
                    if (idProducto == idProductoDevoAceptada)
                    {
                        int restanteProductosComentDevo = extraerInfoDevolverDeComentario(devo.Description, 2);

                        if (restanteProductosComentDevo == 0)
                        {
                            Alertas.AlertError("Aceptando Devolucion", "Ya no se puede devolver este tipo de producto de esta venta dado que ya se devolvio todo, por favor rechazar esta solicitud");
                            return "error";
                        }

                        if (cantidadRetornar > restanteProductosComentDevo)
                        {
                            Alertas.AlertError("Aceptando Devolucion", "No se puede retornar este producto dado que es mas de lo que se puede devolver segun la venta o ya se devolvio todo el producto, por favor rechazar esta solicitud");
                            return "error";
                        }

                        nuevoRestanteProducto = restanteProductosComentDevo - cantidadRetornar;

                        nuevaDescripcion = "Se ha devuelto la cantidad de " + cantidadRetornar + " productos " + producto.GetNameProduct();
                        nuevaDescripcion += " con el id " + idProducto + ". Una vez exitosa la devolucion la nueva cantidad de productos de la compra serian: " + nuevoRestanteProducto;

                    }
                }

                return nuevaDescripcion;
            }
        }

        public string codigoGenerado()
        {
            Random rnd = new Random();
            string codigoNuevoDescuento = "";
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

            for (int i = 0; i < 10; i++)
            {
                int index = rnd.Next(caracteres.Length);
                codigoNuevoDescuento += caracteres[index];
            }

            return codigoNuevoDescuento;
        }
        
        public int extraerInfoDevolverDeComentario(string comentario, int valorExtraer)
        {
            int cantidadDevolver = 0;

            MatchCollection matches = Regex.Matches(comentario, @"\d+");

            if (matches.Count >= 3)
            {
                cantidadDevolver = int.Parse(matches[valorExtraer].Value);
            }

            return cantidadDevolver;
        }
    }
}
