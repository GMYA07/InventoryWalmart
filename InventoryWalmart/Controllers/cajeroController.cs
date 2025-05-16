using InventoryWalmart.Database;
using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Controllers
{
    internal class cajeroController
    {
        public cajeroController() { }

        public Product encontrarProducto(int idProducto) {
            Product productObtenido = new Product();

            ProductDAO productDAO = new ProductDAO();

            productObtenido = productDAO.obtenerProducto(idProducto);

            return productObtenido;

        }

        public Discount encontrarDescuento(string discount_code)
        {
            Discount discount = new Discount();
            DiscountDAO discountDAO = new DiscountDAO();

            discount = discountDAO.obtenerDescuentoActivo(discount_code);

            if (discount == null) {
                return null;
            }
            
            return discount;
        }

        public decimal aplicar_revertirDescuentoTotalVenta(decimal totalVenta, decimal descuento, string tipoOperacion) 
        { 

            decimal totalVentaNew = 0;

            // Convertimos el porcentaje a decimal dividiendo entre 100
            decimal factorDescuento = (100 - descuento) / 100;

            

            if (tipoOperacion.Equals("revertir"))
            {
                //revertimos el descuento
                totalVentaNew = totalVenta / factorDescuento;
            }
            else
            {
                //AplicamosDescuento
                totalVentaNew = totalVenta * factorDescuento;
            }

            return Math.Round(totalVentaNew,2);
        
        }

        public decimal aplicarDescuentoAlAgregar_QuitarProducto(decimal totalVenta,string codigoDescuento,decimal subtotal,string tipo)
        {
            decimal totalVentaNew = totalVenta;
            Discount discount = new Discount();
            discount = encontrarDescuento(codigoDescuento); // se ocupara para poder usarlo mas adelante en los calculos

            if (tipo.Equals("agregando"))
            {
                totalVentaNew = aplicar_revertirDescuentoTotalVenta(totalVenta, discount.DiscountAmount, "revertir");
                totalVentaNew += subtotal;
                totalVentaNew = aplicar_revertirDescuentoTotalVenta(totalVentaNew, discount.DiscountAmount, "aplicar");

                return totalVentaNew;
            }
            else
            {
                totalVentaNew = aplicar_revertirDescuentoTotalVenta(totalVenta, discount.DiscountAmount, "revertir");
                totalVentaNew = totalVentaNew - subtotal;
                totalVentaNew = aplicar_revertirDescuentoTotalVenta(totalVentaNew, discount.DiscountAmount, "aplicar");
                return totalVentaNew;
            }
        }

    }
}
