using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryWalmart.Utils
{
    internal class Alertas
    {
        //Constructor
        public Alertas() { }

        //Metodos
        public static void AlertError(string tituloAlerta, string razoAlerta)
        {
            MessageBox.Show(razoAlerta,tituloAlerta, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AlertCorrect(string tituloAlerta, string razoAlerta) { 
            MessageBox.Show(razoAlerta,tituloAlerta, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void AlertInfo(string tituloAlerta, string razoAlerta)
        {
            MessageBox.Show(razoAlerta, tituloAlerta, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirmacion(string tituloAlerta, string razoAlerta)
        {
            DialogResult resultado = MessageBox.Show(razoAlerta, tituloAlerta, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        public DialogResult AlertConfirmacion(string tituloAlerta, string mensajeAlerta)
        {
            return MessageBox.Show(mensajeAlerta, tituloAlerta, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }


    }
}
