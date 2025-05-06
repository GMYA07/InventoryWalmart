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
        public void AlertError(string tituloAlerta, string razoAlerta)
        {
            MessageBox.Show(razoAlerta,tituloAlerta, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void AlertCorrect(string tituloAlerta, string razoAlerta) { 
            MessageBox.Show(razoAlerta,tituloAlerta, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
