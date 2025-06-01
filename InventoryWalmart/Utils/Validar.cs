using InventoryWalmart.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryWalmart.Validaciones
{
    internal class Validar
    {

        public void Vacios(TextBox text) {
            //if (text != null) { 
            //    Alertas
            //}
        }

        public static Boolean validarDescuento(string discount_code)
        {
            if (discount_code.Equals(""))
            {
                Alertas.AlertError("Error al aplicar el codigo", "El campo de codigo de descuento esta vacio");
                return false;
            }

            if (discount_code.Length != 10)
            {
                Alertas.AlertError("Error al aplicar el codigo","El codigo costituye de 10 letras y numeros");
                return false;
            }

            return true;
        }

        public static Boolean validarInputVacio(string inputInfo, string input)
        {

            if (inputInfo.Equals(""))
            {
                Alertas.AlertError("Error al encontrar "+input, "El campo "+input+" esta vacio");
                return true;
            }

            return false;
        }

        public static Boolean validarTargeta(string tarjeta)
        {
            Boolean esValida = Regex.IsMatch(tarjeta, @"^[a-zA-Z0-9]{20}$");

            if (!esValida) //si no es valida
            {
                Alertas.AlertError("Error al ingresar la targeta", "la targeta no tiene el formato correspondiente");
                return true;
            }

            return false;
        }

        public static Boolean validarDUI(string dui)
        {

            Boolean esValido = Regex.IsMatch(dui, @"^\d{8}-\d{1}$");

            if (!esValido)
            {
                Alertas.AlertError("Error al ingresar el dui", "El dui no tiene el formato correspondiente");
                return true;
            }
            
            return false;
        }

        public static bool ValidarTelefono(string telefono)
        {
            // Usa expresión regular para validar el formato 4 dígitos, guion, 4 dígitos
            return Regex.IsMatch(telefono, @"^\d{4}-\d{4}$");
        }

        public static bool ValidarEmail(string email)
        {
            // Expresión regular básica para validar correos comunes
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        //validar fecha para que sea mayor de 18
        public static bool EsMayorDeEdad(DateTime fechaNacimiento)
        {
            // Obtener la fecha actual
            DateTime hoy = DateTime.Today;

            // Calcular la edad
            int edad = hoy.Year - fechaNacimiento.Year;

            // Si todavía no ha cumplido años este año, restar uno
            if (fechaNacimiento.Date > hoy.AddYears(-edad))
            {
                edad--;
            }

            // Retorna true si tiene al menos 18 años
            return edad >= 18;
        }

        //validar porcentaje de descuento que no sobre pase100
        public static bool ValidarPorcentaje(string input)
        {
            if (int.TryParse(input, out int numero))
            {
                return numero <= 100;
            }
            return false;
        }


        //validar puntos requeridos que sean numeros
        public static bool ValidarNumero(string input)
        {
            return int.TryParse(input, out _);
        }

    }
}
