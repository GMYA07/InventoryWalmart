using InventoryWalmart.Controllers;
using InventoryWalmart.Model;
using InventoryWalmart.Utils;
using InventoryWalmart.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryWalmart.views.Cajero
{
    public partial class viewRegistrarVentaCajero : Form
    {

        public viewRegistrarVentaCajero()
        {
            InitializeComponent();
        }

        //Se usara para llevar la lista de los productos de la venta
        List<Product>listaVenta = new List<Product>();
        //Se usara para llevar el total de la venta
        decimal totalVenta =0;
        decimal subTotalVentaMostrar = 0;
        decimal totalDescuentoMostrar = 0;
        Boolean codigoAplicado = false;
        Boolean beneficioAplicado = false;
        string codigoDescuento = "";

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void barAcciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkTieneTargeta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTieneTargeta.Checked )
            {
                inputTargetaCliente.Enabled = true;
                inputDui.Enabled = true;

            }
            
            if (!checkTieneTargeta.Checked )
            {
                inputTargetaCliente.Enabled = false;
                inputDui.Enabled = false;
                btnAplicarBeneficios.Enabled = false;
                inputTargetaCliente.Text = "";
                inputDui.Text = "";
                labelPtsTargeta.Text = "0";
                tablaBeneficiosAplicables.Rows.Clear();
            }
        }

        private void viewRegistrarVentaCajero_Load(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //variable que ocuparemos para saber el total de la venta mas adelante
            decimal subTotal = 0;
            //Se usara para la cantidad de productos en que desean agregar
            
            int cantidadProducto = int.Parse(inputCantidadProducto.Text);

            if (inputCodigoProducto.Text.Equals("") || cantidadProducto <= 0)
            {
                Alertas.AlertError("Error al Buscar el producto", "El campo de codigo esta vacio o la cantidad es igual a 0");
                return;
            }
            //Se instancia un controlador
            cajeroController cajeroController = new cajeroController();
            //Buscaremos el producto
            Product product = new Product();
            product = cajeroController.encontrarProducto(int.Parse(inputCodigoProducto.Text));

            if (product == null) { // este if verifica si fue exitoso la busqueda del producto

                Alertas.AlertError("Error al Buscar el producto", "El codigo del producto es erroneo");
                return;
            }

            //nos ayudara con el subtotal osea el precio de los productos mas lo q ha agarrado
            subTotal = product.GetPrice()*cantidadProducto;

            Boolean encontrar = false; //variable q nos ayudara a encontrar el producto dado si ya existe

            //Nos ayudara para tanto el agregar de un producto a su lista como a su edicion
            foreach (DataGridViewRow fila in tablaVenta.Rows)
            {
                // Aqui con esta condicion buscaremos un ID que coincida con el producto que ya esta en la lista y asi solo agregarlo
                if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == product.GetIdProduct().ToString())
                {

                    // Editamos la cantidad de producto y lo aumentamos
                    int cantidadEdit = int.Parse(fila.Cells[2].Value.ToString()) + cantidadProducto;
                    cantidadProducto += cantidadEdit;

                    fila.Cells[2].Value = cantidadEdit;

                    //editamos el subTotal 
                    decimal subTotalEdit = decimal.Parse(fila.Cells[4].Value.ToString()) + subTotal;

                    fila.Cells[4].Value = subTotalEdit;

                    encontrar = true; //si existe se le asiganara true para evitar q se meta al if donde metemos nueva columna por que lo que queremos es editar
                    break;
                }

            }

            if (!encontrar)
            {
                tablaVenta.Rows.Add(product.GetIdProduct(), product.GetNameProduct(), cantidadProducto, product.GetPrice(), subTotal);
            }

            // se reinicia tanto la cantidad para asi tomar una nueva y limpio el input 
            inputCantidadProducto.Text = "0";
            cantidadProducto = 0;
            //Agrego el subtotal al total de la venta en curso
            if (codigoAplicado == true)
            {
                totalVenta = cajeroController.aplicarDescuentoAlAgregar_QuitarProducto(totalVenta, codigoDescuento, subTotal, "agregando");

                //agregamos la suma al subTotal de todo sin ningun descuento ni nada
                subTotalVentaMostrar += subTotal;
                labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();
            }
            else
            {
                totalVenta += subTotal;
                //agregamos la suma al subTotal de todo sin ningun descuento ni nada
                subTotalVentaMostrar += subTotal;
                labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

            }

            labelMostrarTotal.Text = totalVenta.ToString();
            Alertas.AlertCorrect("Producto Ingresado", "¡Se ha ingresado el producto exitosamente!");

        }

        private void btnQuitarProductoLista_Click(object sender, EventArgs e)
        {
            const int ColumnaCantidad = 2;
            const int ColumnaPrecioUnitario = 3;
            const int ColumnaSubtotal = 4;

            if (tablaVenta.SelectedRows.Count == 1)
            {
                cajeroController cajeroController = new cajeroController();
                Discount discount = new Discount();

                DataGridViewRow filaProducto = tablaVenta.SelectedRows[0]; // se le pone 0 por que nos referimos a la primera fila q selecciono el usuario
                int cantidadActualVentaProducto = int.Parse(filaProducto.Cells[ColumnaCantidad].Value.ToString()); //recuperamos la variable de cantidad a retirar para restarlo con lo q nos de el usuario a restar
                int cantidadRetirar = int.Parse(inputCantidadRetirar.Text); // aqui obtengo la cantidad que el usuario desea retirar

                if (cantidadRetirar > cantidadActualVentaProducto || cantidadRetirar <= 0)
                {
                    Alertas.AlertError("Error al Retirar el Producto", "No se ha podido Retirar el producto por que la cantidad a retirar es mas de lo que existe en la venta o es menor o igual a 0");
                    return;
                }

                int cantidadNuevaVenta = cantidadActualVentaProducto - cantidadRetirar; // hacemos el calculo para ver si no es 0 la nueva cantidad y asi dar por finalizado todo

                if (cantidadNuevaVenta == 0)
                {
                    //Ahora vamos a calcular el total de la venta para actualizarlo
                    decimal totalVentaNuevoEliminacionTotal = 0;
                    if (codigoAplicado == true)
                    {
                        totalVentaNuevoEliminacionTotal = cajeroController.aplicarDescuentoAlAgregar_QuitarProducto(totalVenta, codigoDescuento, decimal.Parse(filaProducto.Cells[4].Value.ToString()), "retirando");

                        //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                        subTotalVentaMostrar -= decimal.Parse(filaProducto.Cells[4].Value.ToString());
                        labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                        //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                        totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                        labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();
                    }
                    else
                    {
                        totalVentaNuevoEliminacionTotal = totalVenta - decimal.Parse(filaProducto.Cells[4].Value.ToString());

                        //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                        subTotalVentaMostrar -= decimal.Parse(filaProducto.Cells[4].Value.ToString());
                        labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                    }
                    totalVenta = totalVentaNuevoEliminacionTotal;
                    labelMostrarTotal.Text = totalVentaNuevoEliminacionTotal.ToString();
                    tablaVenta.Rows.RemoveAt(tablaVenta.SelectedRows[0].Index);
                    Alertas.AlertCorrect("Producto Retirado","Se ha retirado por completo el producto");
                    return;
                }
                //Ahora vamos a calcular el subtotal de la venta para actualizarlo
                decimal subTotalActualVentaProducto = decimal.Parse(filaProducto.Cells[4].Value.ToString()); //aqui obtenemos el subtotalActual
                decimal dineroRetirarSubtotal = decimal.Parse(filaProducto.Cells[ColumnaPrecioUnitario].Value.ToString()) * cantidadRetirar;//aqui calculo la cantidad q se le restara
                decimal subTotalNuevoVentaProducto = subTotalActualVentaProducto - dineroRetirarSubtotal; // aqui calculamos el nuevo valor del subtotal
                //Ahora vamos a calcular el total de la venta para actualizarlo
                decimal totalVentaNuevo = 0;
                if (codigoAplicado == true) //verificamos si tiene descuento actualmente aplicado
                {
                    totalVentaNuevo = cajeroController.aplicarDescuentoAlAgregar_QuitarProducto(totalVenta, codigoDescuento, dineroRetirarSubtotal, "retirando"); //calculo el nuevo precio del total de la venta 

                    //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                    subTotalVentaMostrar -= dineroRetirarSubtotal;
                    labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                    //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                    totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                    labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();
                }
                else
                {
                    totalVentaNuevo = totalVenta - dineroRetirarSubtotal; //calculo el nuevo precio del total de la venta 

                    //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                    subTotalVentaMostrar -= dineroRetirarSubtotal;
                    labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                }

                //Ahora Actualizaremos los valores visualmente
                filaProducto.Cells[ColumnaCantidad].Value = cantidadNuevaVenta; //aqui actualizo la nueva cantidad de productos que quedaron
                filaProducto.Cells[ColumnaSubtotal].Value = subTotalNuevoVentaProducto; //Aqui actualizo e lcampo del nuevo subtotal
                labelMostrarTotal.Text = totalVentaNuevo.ToString(); //Aqui lo actualizamos el total de la venta pero solo visualmente
                totalVenta = totalVentaNuevo; //Aqui actualizamos la variable global del total de la venta

                Alertas.AlertCorrect("Producto Retirado", "Se ha retirado el producto"); // ahora damos una alerta para decir que ya finalizamos
            }
            else
            {
                Alertas.AlertError("Error al seleccionar", "Seleccione el producto que de sea retirar cierta cantidad");
            }
        }

        private void btnLimpiarTodaLista_Click(object sender, EventArgs e)
        {
            if (Alertas.Confirmacion("Producto ha retirar","¿Desea vaciar toda la lista?"))
            {
                tablaVenta.Rows.Clear();
                labelMostrarTotal.Text = "0";
                labelMostrarSubtotalCompra.Text = "0";
                labelDescuentoDinero.Text = "0";
                totalVenta = 0;
                subTotalVentaMostrar = 0;
                totalDescuentoMostrar = 0;
                

                Alertas.AlertCorrect("Productos Retirados", "¡Se han retirados los productos existosamente!");
            }
        }

        private void btnAplicarCodDesc_Click(object sender, EventArgs e)
        {
            Discount discount = new Discount(); //nos ayudara para almacenar toda la info
            cajeroController cajeroController = new cajeroController(); // nos permite ir al controlador

            if (codigoAplicado == true)
            {
                discount = cajeroController.encontrarDescuento(inputCodigoDescuento.Text); // se ocupara para poder usarlo mas adelante en los calculos

                //Diseño Boton
                btnAplicarCodDesc.BackColor = Color.FromArgb(0, 114, 223); //Cambiamos el color del boton a rojo para mejora visual
                btnAplicarCodDesc.Text = "Aplicar Codigo de Descuento";//cambiamos el texto para q se entienda el contexto de lo q es

                //Desabilitacion de botones y asignasiones
                inputCodigoDescuento.Enabled = true;//hacemos que el usuario vuelva a escribir un codigo descuento si asi lo desea
                codigoDescuento = ""; //vaciamos el codigo de descuento
                inputCodigoDescuento.Text = ""; //reiniciamos el input
                codigoAplicado = false; // habilitamos la posibilidad para poner otro codigo

                //Calculos y escondemos el descuento a la vista
                totalVenta = cajeroController.aplicar_revertirDescuentoTotalVenta(totalVenta, discount.DiscountAmount, "revertir");
                labelMostrarTotal.Text = totalVenta.ToString(); //aqui evidenciamos los cambios
                labelTextDescApli.Visible = false; // se desactiva para avisar que aplico un descuento
                labelDescuentoApli.Visible = false;//se desactiva para avisar visualmente la cantidad del descuento
                labelDescuentoApli.Text = "0"; // aqui se prepara el texto

                //Ahora aplicamos esto para saber el valor del descuento osea en dinero pero aqui se reiniciara todo ya q se retiro el descuento
                totalDescuentoMostrar = 0;
                labelDescuentoDinero.Text = "0";

                Alertas.AlertCorrect("Desaplicar codigo descuento", "El codigo descuento ha sido quitado");
                return;
            }

            if (Validar.validarDescuento(inputCodigoDescuento.Text))
            {
                if (tablaVenta.Rows.Count == 0)
                {
                    Alertas.AlertError("Error al aplicar el descuento", "¡Deben haber productos en la lista!");
                }
                else
                {
                    discount = cajeroController.encontrarDescuento(inputCodigoDescuento.Text);

                    if (discount != null)
                    {
                        //Diseño Boton
                        btnAplicarCodDesc.BackColor = Color.Red; //Cambiamos el color del boton a rojo para mejora visual
                        btnAplicarCodDesc.Text = "Desaplicar codigo de descuento"; //cambiamos el texto para q se entienda el contexto de lo q es

                        //Desabilitacion de botones y asignasiones
                        inputCodigoDescuento.Enabled = false;//evitamos que el usuario toque el codigo para mayor seguridad
                        codigoDescuento = discount.DiscountCode; //asignamos el codigo a una variable global para guardarla para mayor seguridad
                        codigoAplicado = true;// validamos que el codigo fue aplicado

                        //Calculos y muestras de descuento en vista
                        totalVenta = cajeroController.aplicar_revertirDescuentoTotalVenta(totalVenta, discount.DiscountAmount, "aplicar"); //aplicamos el descuento al total de la venta
                        labelMostrarTotal.Text = totalVenta.ToString(); //aqui evidenciamos los cambios
                        labelTextDescApli.Visible = true; // se activa para avisar que aplico un descuento
                        labelDescuentoApli.Visible = true;//se activa para avisar visualmente la cantidad del descuento
                        labelDescuentoApli.Text = discount.DiscountAmount.ToString() + " %"; // aqui se prepara el texto

                        //Ahora aplicamos esto para saber el valor del descuento osea en dinero
                        totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar,codigoDescuento);
                        labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();

                        Alertas.AlertCorrect("Aplicar codigo descuento", "El codigo ha sido aplicado con exito");
                        return;
                    }
                    else
                    {
                        Alertas.AlertError("Error al aplicar el descuento", "El codigo deseado a aplicar no existe o ya vencio");
                        return;
                    }
                }
            }
        }

        private void btnMostrarBeneficios_Click(object sender, EventArgs e)
        {
            cajeroController cajeroController = new cajeroController();

            if (!Validar.validarInputVacio(inputTargetaCliente.Text,"targeta cliente") && !Validar.validarTargeta(inputTargetaCliente.Text))
            {
                if (!Validar.validarInputVacio(inputDui.Text,"dui") && !Validar.validarDUI(inputDui.Text))
                {
                    if (!cajeroController.verificarExistenciaTargetaCliente(inputTargetaCliente.Text))
                    {
                        if (!cajeroController.verificarExistenciaDUI(inputDui.Text))
                        {

                            if (cajeroController.verificarAsociacionTargetaDui(inputTargetaCliente.Text, inputDui.Text))
                            {
                                List<Benefits> listBenefits = cajeroController.obtenerBeneficiosClientes(inputTargetaCliente.Text, inputDui.Text);

                                tablaBeneficiosAplicables.Rows.Clear();

                                foreach (Benefits b in listBenefits)
                                {
                                    tablaBeneficiosAplicables.Rows.Add(b.BenefitName,b.PointsRequierd,b.DiscountPercent);
                                }

                                btnAplicarBeneficios.Enabled = true;
                                labelPtsTargeta.Text = cajeroController.obtenerPtsCustomerCard(inputTargetaCliente.Text);
                                Alertas.AlertCorrect("Encontrar Beneficios", "Se han encontrado los beneficios asociados a la targeta");
                                return;
                            }
                            else
                            {
                                Alertas.AlertError("Error en credenciales", "Parece que esta Targeta no esta asociada a este DUI");
                            }

                        }
                        else
                        {
                            Alertas.AlertError("Error al encontrar Cliente", "No se ha encontrado un cliente con ese dui");
                        }

                    }
                    else
                    {
                        Alertas.AlertError("Error al encontrar Targeta", "No se ha encontrado una targeta con ese codigo");
                    }
                }
            }
        }

        private void btnAplicarBeneficios_Click(object sender, EventArgs e)
        {
            int columnaPoints = 1;
            int columnaPorcentajeDiscount = 2;
            cajeroController cajeroController = new cajeroController();
           

            if (tablaVenta.Rows.Count == 0)
            {
                Alertas.AlertError("Error al aplicar el beneficio", "¡Deben haber productos en la lista!");
            }
            else
            {

                if (tablaBeneficiosAplicables.SelectedRows.Count == 1)
                {
                    DataGridViewRow filaBeneficio = tablaBeneficiosAplicables.SelectedRows[0]; // se le pone 0 por que nos referimos a la primera fila q selecciono el usuario
                    
                    if (beneficioAplicado == true) { 

                        beneficioAplicado = false; //Cambiando el estado a true para decir que ya esta aplicado
                        /*Diseñaremos el nuevo boton luego de aplicar el beneficio*/
                        btnAplicarBeneficios.BackColor = Color.FromArgb(0, 114, 223);
                        btnAplicarBeneficios.Text = "Aplicar Beneficios de \r\nTargeta";
                        //Abilitamos de nuevo los inputs
                        inputDui.Enabled = true;
                        inputTargetaCliente.Enabled = true;
                        btnMostrarBeneficios.Enabled = true; //habilitamos el boton para q pueda filtrarlos otra vez
                        tablaBeneficiosAplicables.Enabled = true; //desbloqueamos la tabla para que pueda hacer seleccion de otro beneficio
                        return;
                    }

                    if (!cajeroController.verificarPuntosTargetaParaAplicarBeneficio(inputTargetaCliente.Text, int.Parse(filaBeneficio.Cells[columnaPoints].Value.ToString())))
                    {
                        if (!cajeroController.validarPorcentajeDescuentoCodigo_DescuentoBeneficio(codigoDescuento, decimal.Parse(filaBeneficio.Cells[columnaPorcentajeDiscount].Value.ToString())))
                        {
                            beneficioAplicado = true; //Cambiando el estado a true para decir que ya esta aplicado
                            /*Diseñaremos el nuevo boton luego de aplicar el beneficio*/
                            btnAplicarBeneficios.BackColor = Color.Red;
                            btnAplicarBeneficios.Text = "Desaplicar Beneficios de \r\nTargeta";
                            //Bloqueamos los inputs por cualquier cosa
                            inputDui.Enabled = false;
                            inputTargetaCliente.Enabled = false;
                            btnMostrarBeneficios.Enabled = false; //bloqueamos el boton para que no pueda filtrar de nuevo y q se quite su seleccion
                            tablaBeneficiosAplicables.Enabled = false; //y bloqueamos la tabla para que no seleccione por error otro beneficio

                            Alertas.AlertCorrect("Aplicando Beneficios", "Se ha aplicado el beneficio");
                            return;
                        }
                        else
                        {
                            Alertas.AlertError("Error al aplicar el codigo", "Existe un codigo de descuento que hace pasar el 100%");
                        }

                    }
                    else
                    {
                        Alertas.AlertError("Error al aplicar el beneficio", "¡No tienes la cantidad de puntos requerida para obtener este beneficio!");
                        return;
                    }
                }
                else
                {
                    Alertas.AlertError("Error al aplicar el beneficio","¡Debe seleccionar un beneficio!");
                }
            }
        }

        private void inputCantidadRetirar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void labelMostrarTotal_Click(object sender, EventArgs e)
        {

        }

        private void tablaVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void labelPtsTargeta_Click(object sender, EventArgs e)
        {

        }
    }
}
