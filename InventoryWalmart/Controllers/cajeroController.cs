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

        public List<Benefits> obtenerBeneficiosClientes(string duiCliente)
        {

            BenefitsDAO benefitsDAO = new BenefitsDAO();
            List<Benefits> benefits = new List<Benefits>(); //Lista que retornaremos

            benefits = benefitsDAO.obtenerBeneficiosClientesDAO(duiCliente);

            if (benefits == null)
            {
                Alertas.AlertError("Error al encontrar la lista", "Parece que ocurrio un error al momento de encontrar la lista");
                return null;
            }

            return benefits;
        }

        public Benefits obtenerBeneficio(int idBene)
        {
            Benefits benefit = new Benefits();
            BenefitsDAO benefitDAO = new BenefitsDAO();

            benefit = benefitDAO.obtenerBeneficio(idBene);

            return benefit;
        }

        public Customer_Card obtenerCustomerCard(string targetaCliente)
        {
            Customer_Card customer_Card = new Customer_Card();
            Customer_CardDAO customer_CardDAO = new Customer_CardDAO();

            customer_Card = customer_CardDAO.obtenerCustomer_CardWithCardNumber(targetaCliente);

            if (customer_Card == null) {
                return null;
            }
            return customer_Card;
        }

        public string obtenerPtsCustomerCard(string targetaCliente)
        {
            Customer_Card customer_Card = obtenerCustomerCard(targetaCliente);

            if (customer_Card == null)
            {
                return "";   
            }
            string ptsCard = customer_Card.PointsBalance.ToString();

            return ptsCard;
        }

        public Boolean verificarAsociacionTargetaDui(string targetaCliente,string dui)
        {
            Customer customer = new Customer();
            Customer_CardDAO customerCardDAO = new Customer_CardDAO();
            CustomerDAO customerDAO = new CustomerDAO();

            customer = customerDAO.obtenerCustomerWithDUI(dui);

            return customerCardDAO.verificarAsociacionTargetaDuiDAO(targetaCliente, customer.IdCustomer.ToString());

        }

        public Boolean verificarExistenciaTargetaCliente(string targetaCliente)
        {
            Customer_Card customerCard = new Customer_Card();
            Customer_CardDAO customerCardDAO = new Customer_CardDAO();

            customerCard = customerCardDAO.obtenerCustomer_CardWithCardNumber(targetaCliente);

            if (customerCard == null)
            {
                return true;
            }
            return false;
        }
        public Boolean verificarExistenciaDUI(string dui)
        {
            Customer customer = new Customer();
            CustomerDAO customerDAO = new CustomerDAO();

            customer = customerDAO.obtenerCustomerWithDUI(dui);

            if (customer == null)
            {
                
                return true;
            }

            return false;
        }

        public Boolean verificarPuntosTargetaParaAplicarBeneficio(string codigoTargeta, int puntosRequeridos)
        {
            //Obtendremos los puntos de la targeta para verificar
            Customer_CardDAO customer_CardDAO = new Customer_CardDAO();
            Customer_Card customer_Card = new Customer_Card();
            customer_Card = customer_CardDAO.obtenerCustomer_CardWithCardNumber(codigoTargeta);

            if (customer_Card == null) {
                Alertas.AlertError("Error","No se encontro la targeta");
                return true;
            }
            else
            {
                decimal ptsTargeta = customer_Card.PointsBalance;

                if (ptsTargeta < puntosRequeridos)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
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

        public decimal aplicarBeneficioAlAgregar_QuitarProducto(decimal totalVenta, int idBeneficio, decimal subtotal, string tipo)
        {
            decimal totalVentaNew = totalVenta;
            Benefits beneficio = new Benefits();
            BenefitsDAO benefitDAO = new BenefitsDAO();
            beneficio = benefitDAO.obtenerBeneficio(idBeneficio); // se ocupara para poder usarlo mas adelante en los calculos

            if (tipo.Equals("agregando"))
            {
                totalVentaNew = aplicar_revertirDescuentoTotalVenta(totalVenta, beneficio.DiscountPercent, "revertir");
                totalVentaNew += subtotal;
                totalVentaNew = aplicar_revertirDescuentoTotalVenta(totalVentaNew, beneficio.DiscountPercent, "aplicar");

                return totalVentaNew;
            }
            else
            {
                totalVentaNew = aplicar_revertirDescuentoTotalVenta(totalVenta, beneficio.DiscountPercent, "revertir");
                totalVentaNew = totalVentaNew - subtotal;
                totalVentaNew = aplicar_revertirDescuentoTotalVenta(totalVentaNew, beneficio.DiscountPercent, "aplicar");
                return totalVentaNew;
            }
        }

        public decimal revertirDobleDescuento(decimal descuentoCodigo, decimal descuentoBeneficio, decimal totalActual, decimal dineroRetirarLista)
        {
            decimal totalVentaNew = 0;
            decimal factorDescuentoCodigo = (100 - descuentoCodigo) / 100;
            decimal factorDescuentoBeneficio = (100 - descuentoBeneficio) / 100;

            decimal totalVentaSinDescuentos = totalActual / (factorDescuentoBeneficio * factorDescuentoCodigo);
            Console.WriteLine("Ya reverti: " + totalVentaSinDescuentos);
            //ahora le retiramos la cantidad q se le quito
            totalVentaNew = totalVentaSinDescuentos - dineroRetirarLista;
            //ahora volvemos a aplicar el descuento
            totalVentaNew = aplicarDobleDescuento(descuentoCodigo,descuentoBeneficio,totalVentaNew);
            return totalVentaNew;
        }

        public decimal aplicarDobleDescuento(decimal descuentoCodigo, decimal descuentoBeneficio, decimal totalActual)
        {
            decimal totalVentaNew = 0;
            decimal factorDescuentoCodigo = (100 - descuentoCodigo) / 100;
            decimal factorDescuentoBeneficio = (100 - descuentoBeneficio) / 100;

            totalVentaNew = (totalActual * factorDescuentoCodigo) * factorDescuentoBeneficio;

            return Math.Round(totalVentaNew,2);
        }


        public decimal conocerCantidadDescuento(decimal subTotalVenta, string codDescuento)
        {
            decimal descuentoApli = 0;
            Discount discount = new Discount();
            discount = encontrarDescuento(codDescuento);


            descuentoApli = subTotalVenta * (discount.DiscountAmount/100); //aqui descubirmos 

            return Math.Round(descuentoApli,2)*-1;
        }

        public decimal conocerCantidadDescuentoDoble(decimal descuentoCodigo, decimal descuentoBeneficio, decimal totalActual)
        {
            decimal descuentoDinero = 0;
            decimal factorDescuentoCodigo = (100 - descuentoCodigo) / 100;
            decimal factorDescuentoBeneficio = (100 - descuentoBeneficio) / 100;
            decimal factorAPagar = factorDescuentoCodigo * factorDescuentoBeneficio;
            decimal descuentoTotal = 1 - factorAPagar;

            descuentoDinero = totalActual * descuentoTotal;

            return Math.Round(descuentoDinero, 2);
        }

        public decimal conocerBeneficioDescuento(decimal subTotalVenta, decimal porcentajeBeneficio)
        {
            decimal beneficioApli = 0;

            beneficioApli = subTotalVenta * (porcentajeBeneficio/100);

            return Math.Round(beneficioApli,2)*-1;
        }

        public Boolean validarPorcentajeDescuentoCodigo_DescuentoBeneficio(string codigo, decimal porcentaje, string tipo)
        {
            //Lo ocupamos por si viene de beneficios (aqui por si ya existe un descuento aplicado)
            Discount descuento = new Discount();
            DiscountDAO discountDAO = new DiscountDAO();
            //lo ocupamos por si viene de descuento por codigo (aqui por si existe ya un beneficio aplicado)
            Benefits beneficio = new Benefits();
            BenefitsDAO benefitsDAO = new BenefitsDAO();
            decimal sumaPorcentajes = 0;

            if (tipo.Equals("beneficio"))
            {
                descuento = discountDAO.obtenerDescuentoActivo(codigo);
            }
            else
            {
                int id = int.Parse(codigo);
                beneficio = benefitsDAO.obtenerBeneficio(id);
            }

            if (descuento == null || beneficio == null) //si no encontro ningun descuento se le envia false por q no hay q evaluar nada y haya se usara el operador ! para q pueda pasar el if
            {
                return false;
            }
            else
            {
                if (tipo.Equals("beneficio"))
                {
                    sumaPorcentajes = porcentaje + descuento.DiscountAmount;
                }
                else
                {
                    sumaPorcentajes = porcentaje + beneficio.DiscountPercent;
                }

                if (sumaPorcentajes > 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
