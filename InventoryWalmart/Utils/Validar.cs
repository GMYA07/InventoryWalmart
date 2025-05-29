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

        public static bool correo(TextBox text) {
            //bool valido = Regex.IsMatch(text, @"^$");

            return false;
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
    }
}
