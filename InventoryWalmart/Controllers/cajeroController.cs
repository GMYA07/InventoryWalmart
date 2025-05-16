using InventoryWalmart.Database;
using InventoryWalmart.Model;
using InventoryWalmart.Utils;
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

        public List<Benefits> obtenerBeneficiosCliente(string targetaCliente,string duiCliente)
        {
            BenefitsDAO benefitsDAO = new BenefitsDAO();
            List<Benefits> benefits = new List<Benefits>(); //Lista que retornaremos

            benefits = benefitsDAO.obtenerBeneficiosClienteDAO(targetaCliente, duiCliente);

            if (benefits == null)
            {
                return null;
            }

            return benefits;
        }

        public Boolean verificarExistenciaTargetaCliente(string targetaCliente)
        {
            Customer customer = new Customer();

            return true;
        }
        public Boolean verificarExistenciaDUI(string targetaCliente)
        {
            return true;
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

        public decimal conocerCantidadDescuento(decimal subTotalVenta, string codDescuento)
        {
            decimal descuentoApli = 0;
            Discount discount = new Discount();
            discount = encontrarDescuento(codDescuento);


            descuentoApli = subTotalVenta * (discount.DiscountAmount/100); //aqui descubirmos 

            return Math.Round(descuentoApli,2)*-1;
        }

    }
}
