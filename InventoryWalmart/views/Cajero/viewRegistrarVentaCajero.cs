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
        decimal totalBeneficioMostrar = 0;
        Boolean codigoAplicado = false;
        Boolean beneficioAplicado = false;
        string codigoDescuento = "";
        int idBeneficio = 0;
        //metodos de pago
        bool metodoPagoEfectivo = false;
        bool metodoPagoTargeta = false;

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

        private void btnProductos_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            indexCajero indexCajero = new indexCajero();
            this.Hide();
            indexCajero.Show();
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
                beneficioAplicado = false;
            }
        }

        private void viewRegistrarVentaCajero_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Benefits benefit = new Benefits(); //se ocupara para buscar el id de beneficio
            Discount discount = new Discount();
            //variable que ocuparemos para saber el total de la venta mas adelante
            decimal subTotal = 0;
            int cantidadProducto = 0;
            //Se usara para la cantidad de productos en que desean agregar

            if (inputCodigoProducto.Text.Equals("") || !int.TryParse(inputCodigoProducto.Text, out cantidadProducto) || !int.TryParse(inputCantidadProducto.Text, out cantidadProducto) || cantidadProducto <= 0 )
            {
                Alertas.AlertError("Error al Buscar el producto", "El campo de codigo esta vacio o no es un numero o posiblemente la cantidad es igual a 0 o no es un numero");
                return;
            }

            //setteamos ya la cantidad de productos luego de hacer verificiones
            cantidadProducto = int.Parse(inputCantidadProducto.Text);

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
            if (codigoAplicado == true || beneficioAplicado == true)
            {
                if (codigoAplicado == true)
                {
    
                    //agregamos la suma al subTotal de todo sin ningun descuento ni nada
                    subTotalVentaMostrar += subTotal;
                    labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                    //Aqui aplicamos esto para saber el descuento en dinero q se le va a aplicar
                    totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                    labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();

                    if (beneficioAplicado == true) //aqui le aplicamos el descuento del beneficio si es q ya tiene codigo
                    {

                        discount = cajeroController.encontrarDescuento(codigoDescuento);
                        benefit = cajeroController.obtenerBeneficio(idBeneficio);
                        totalVenta = cajeroController.aplicarDobleDescuento(discount.DiscountAmount,benefit.DiscountPercent,subTotalVentaMostrar);

                        //esta variable se ocupa para saber el valor q despues se le aplicara luego de haber usado el porcentaje del cupon
                        decimal primerDescuentoAplicado = cajeroController.aplicar_revertirDescuentoTotalVenta(subTotalVentaMostrar, discount.DiscountAmount, "aplicar");

                        totalBeneficioMostrar = cajeroController.conocerBeneficioDescuento(primerDescuentoAplicado, benefit.DiscountPercent);
                        labelDescuentoBeneficio.Text = totalBeneficioMostrar.ToString();

                    }
                    else
                    {

                        //Aqui aplicamos el descuento de cupon o codigo
                        totalVenta = cajeroController.aplicarDescuentoAlAgregar_QuitarProducto(totalVenta, codigoDescuento, subTotal, "agregando");

                    }

                    labelMostrarTotal.Text = totalVenta.ToString();
                    Alertas.AlertCorrect("Producto Ingresado", "¡Se ha ingresado el producto exitosamente!");
                    return; //este return se coloca para q no vuelva a realizar el proceso del if anterior y solo haga doble cuando se meta aqui
                }

                if (beneficioAplicado == true)
                {
                    totalVenta = cajeroController.aplicarBeneficioAlAgregar_QuitarProducto(totalVenta, idBeneficio, subTotal, "agregando");

                    //agregamos la suma al subTotal de todo sin ningun descuento ni nada
                    subTotalVentaMostrar += subTotal;
                    labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                    //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                    Benefits benefits = new Benefits();
                    benefits = cajeroController.obtenerBeneficio(idBeneficio);

                    totalBeneficioMostrar = cajeroController.conocerBeneficioDescuento(subTotalVentaMostrar, benefits.DiscountPercent);
                    labelDescuentoBeneficio.Text = totalBeneficioMostrar.ToString();

                    labelMostrarTotal.Text = totalVenta.ToString();
                    Alertas.AlertCorrect("Producto Ingresado", "¡Se ha ingresado el producto exitosamente!");
                    return;

                }
            }
            else
            {
                totalVenta += subTotal;
                //agregamos la suma al subTotal de todo sin ningun descuento ni nada
                subTotalVentaMostrar += subTotal;
                labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                labelMostrarTotal.Text = totalVenta.ToString();
                Alertas.AlertCorrect("Producto Ingresado", "¡Se ha ingresado el producto exitosamente!");
            }

        }

        private void btnQuitarProductoLista_Click(object sender, EventArgs e)
        {
            const int ColumnaCantidad = 2;
            const int ColumnaPrecioUnitario = 3;
            const int ColumnaSubtotal = 4;
            Boolean existeDobleDescuento = false;

            if (tablaVenta.SelectedRows.Count == 1)
            {
                cajeroController cajeroController = new cajeroController();
                Discount discount = new Discount();
                Benefits benefit = new Benefits(); //se ocupara para buscar el id de beneficio

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
                    if (codigoAplicado == true || beneficioAplicado == true)
                    {

                        if (codigoAplicado == true) //la logica de este if es q si existe un codigo y tambien hay uno de beneficio se metera en el primer if, si no solo hara el de codigoaplicado q es el else
                        {
                            if (beneficioAplicado == true)
                            {
                                discount = cajeroController.encontrarDescuento(codigoDescuento);
                                benefit = cajeroController.obtenerBeneficio(idBeneficio);
                                totalVentaNuevoEliminacionTotal = cajeroController.revertirDobleDescuento(discount.DiscountAmount, benefit.DiscountPercent, totalVenta, decimal.Parse(filaProducto.Cells[ColumnaSubtotal].Value.ToString()));

                                //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                                subTotalVentaMostrar -= decimal.Parse(filaProducto.Cells[ColumnaSubtotal].Value.ToString());
                                labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                                //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                                totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                                labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();

                                //esta variable se ocupa para saber el valor q despues se le aplicara luego de haber usado el porcentaje del cupon
                                decimal primerDescuentoAplicado = cajeroController.aplicar_revertirDescuentoTotalVenta(subTotalVentaMostrar, discount.DiscountAmount, "aplicar");

                                //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                                totalBeneficioMostrar = cajeroController.conocerBeneficioDescuento(primerDescuentoAplicado, benefit.DiscountPercent);
                                labelDescuentoBeneficio.Text = totalBeneficioMostrar.ToString();

                                existeDobleDescuento = true;
                            }
                            else
                            {
                                totalVentaNuevoEliminacionTotal = cajeroController.aplicarDescuentoAlAgregar_QuitarProducto(totalVenta, codigoDescuento, decimal.Parse(filaProducto.Cells[ColumnaSubtotal].Value.ToString()), "retirando");

                                //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                                subTotalVentaMostrar -= decimal.Parse(filaProducto.Cells[4].Value.ToString());
                                labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                                //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                                totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                                labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();
                            }
                        }

                        if (beneficioAplicado == true && existeDobleDescuento == false)
                        {
                            benefit = cajeroController.obtenerBeneficio(idBeneficio);
                            totalVentaNuevoEliminacionTotal = cajeroController.aplicarBeneficioAlAgregar_QuitarProducto(totalVenta, idBeneficio,decimal.Parse(filaProducto.Cells[ColumnaSubtotal].Value.ToString()), "retirando");
                            //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                            subTotalVentaMostrar -= decimal.Parse(filaProducto.Cells[4].Value.ToString());
                            labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                            totalBeneficioMostrar = cajeroController.conocerBeneficioDescuento(subTotalVentaMostrar, benefit.DiscountPercent);
                            labelDescuentoBeneficio.Text = totalBeneficioMostrar.ToString();
                        }
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

                if (codigoAplicado == true || beneficioAplicado == true) //verificamos si tiene descuento actualmente aplicado
                {
                   
                    if (codigoAplicado == true) {  //la logica de este if es q si existe un codigo y tambien hay uno de beneficio se metera en el primer if, si no solo hara el de codigoaplicado q es el else

                        if (beneficioAplicado == true) {
                            discount = cajeroController.encontrarDescuento(codigoDescuento);
                            benefit = cajeroController.obtenerBeneficio(idBeneficio);
                            totalVentaNuevo = cajeroController.revertirDobleDescuento(discount.DiscountAmount,benefit.DiscountPercent,totalVenta,dineroRetirarSubtotal);

                            //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                            subTotalVentaMostrar -= dineroRetirarSubtotal;
                            labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                            //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                            totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                            labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();

                            //esta variable se ocupa para saber el valor q despues se le aplicara luego de haber usado el porcentaje del cupon
                            decimal primerDescuentoAplicado = cajeroController.aplicar_revertirDescuentoTotalVenta(subTotalVentaMostrar, discount.DiscountAmount, "aplicar");

                            //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                            totalBeneficioMostrar = cajeroController.conocerBeneficioDescuento(primerDescuentoAplicado, benefit.DiscountPercent);
                            labelDescuentoBeneficio.Text = totalBeneficioMostrar.ToString();

                            existeDobleDescuento = true; //aqui lo cambiamos a true para q evite pasar por el if de beneficio aplicado ya q ya se hizo eso aqui
                        }
                        else
                        {
                            totalVentaNuevo = cajeroController.aplicarDescuentoAlAgregar_QuitarProducto(totalVenta, codigoDescuento, dineroRetirarSubtotal, "retirando"); //calculo el nuevo precio del total de la venta 

                            //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                            subTotalVentaMostrar -= dineroRetirarSubtotal;
                            labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                            //Ahora aplicamos esto para saber el valor del descuento osea en dinero y mostrarlo al usuario
                            totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                            labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();
                        }

                    }

                    if (beneficioAplicado == true && existeDobleDescuento == false)
                    {
                        benefit = cajeroController.obtenerBeneficio(idBeneficio);
                        totalVentaNuevo = cajeroController.aplicarBeneficioAlAgregar_QuitarProducto(totalVenta, idBeneficio, dineroRetirarSubtotal, "retirando");
                        //agregamos la resta al subTotal de todo sin ningun descuento ni nada
                        subTotalVentaMostrar -= dineroRetirarSubtotal;
                        labelMostrarSubtotalCompra.Text = subTotalVentaMostrar.ToString();

                        totalBeneficioMostrar = cajeroController.conocerBeneficioDescuento(subTotalVentaMostrar, benefit.DiscountPercent);
                        labelDescuentoBeneficio.Text = totalBeneficioMostrar.ToString();

                    }
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
                labelDescuentoBeneficio.Text = "0";
                labelPtsTargeta.Text = "0";
                totalVenta = 0;
                subTotalVentaMostrar = 0;
                totalDescuentoMostrar = 0;
                totalBeneficioMostrar = 0; 



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
                        if (!cajeroController.validarPorcentajeDescuentoCodigo_DescuentoBeneficio(idBeneficio.ToString(),discount.DiscountAmount,"descuento codigo"))
                        {
                            //Diseño Boton
                            btnAplicarCodDesc.BackColor = Color.Red; //Cambiamos el color del boton a rojo para mejora visual
                            btnAplicarCodDesc.Text = "Desaplicar codigo de descuento"; //cambiamos el texto para q se entienda el contexto de lo q es

                            //Desabilitacion de botones y asignasiones
                            inputCodigoDescuento.Enabled = false;//evitamos que el usuario toque el codigo para mayor seguridad
                            codigoDescuento = discount.DiscountCode; //asignamos el codigo a una variable global para guardarla para mayor seguridad
                            codigoAplicado = true;// validamos que el codigo fue aplicado

                            //Aqui aplicamos esto para saber el descuento en dinero q se le va a aplicar (VERIFICARA SI PONERLE EL DESCUENTO AL TOTAL o al nuevo total con descuento)
                            if (beneficioAplicado == false)
                            {
                                totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(subTotalVentaMostrar, codigoDescuento);
                                labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();
                            }
                            else
                            {
                                totalDescuentoMostrar = cajeroController.conocerCantidadDescuento(totalVenta, codigoDescuento);
                                labelDescuentoDinero.Text = totalDescuentoMostrar.ToString();
                            }

                            //Calculos y muestras de descuento en vista
                            totalVenta = cajeroController.aplicar_revertirDescuentoTotalVenta(totalVenta, discount.DiscountAmount, "aplicar"); //aplicamos el descuento al total de la venta
                            labelMostrarTotal.Text = totalVenta.ToString(); //aqui evidenciamos los cambios
                            labelTextDescApli.Visible = true; // se activa para avisar que aplico un descuento
                            labelDescuentoApli.Visible = true;//se activa para avisar visualmente la cantidad del descuento
                            labelDescuentoApli.Text = discount.DiscountAmount.ToString() + " %"; // aqui se prepara el texto

                            
                            Alertas.AlertCorrect("Aplicar codigo descuento", "El codigo ha sido aplicado con exito");
                            return;
                        }
                        else
                        {
                            Alertas.AlertError("Error al aplicar el codigo", "Existe un beneficio de descuento que hace pasar el 100%");
                        }
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
                                List<Benefits> listBenefits = cajeroController.obtenerBeneficiosClientes(inputDui.Text);

                                tablaBeneficiosAplicables.Rows.Clear();

                                foreach (Benefits b in listBenefits)
                                {
                                    tablaBeneficiosAplicables.Rows.Add(b.IdBenefit,b.BenefitName,b.PointsRequierd,b.DiscountPercent);
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
            int columnaIdBeneficio = 0;
            int columnaPoints = 2;
            int columnaPorcentajeDiscount = 3;
            cajeroController cajeroController = new cajeroController();

            if (tablaBeneficiosAplicables.SelectedRows.Count == 1)
            {
                DataGridViewRow filaBeneficio = tablaBeneficiosAplicables.SelectedRows[0]; // se le pone 0 por que nos referimos a la primera fila q selecciono el usuario

                if (beneficioAplicado == true)
                {

                    beneficioAplicado = false; //Cambiando el estado a true para decir que ya esta aplicado
                    /*Diseñaremos el nuevo boton luego de aplicar el beneficio*/
                    btnAplicarBeneficios.BackColor = Color.FromArgb(0, 114, 223);
                    btnAplicarBeneficios.Text = "Aplicar Beneficios de \r\nTargeta";
                    //Abilitamos de nuevo los inputs
                    inputTargetaCliente.Enabled = true;
                    inputDui.Enabled = true;
                    btnMostrarBeneficios.Enabled = true; //habilitamos el boton para q pueda filtrarlos otra vez
                    tablaBeneficiosAplicables.Enabled = true; //desbloqueamos la tabla para que pueda hacer seleccion de otro beneficio

                    //Calculos y muestra del beneficio en la vista
                    totalVenta = cajeroController.aplicar_revertirDescuentoTotalVenta(totalVenta, decimal.Parse(filaBeneficio.Cells[columnaPorcentajeDiscount].Value.ToString()), "revertir");
                    labelMostrarTotal.Text = totalVenta.ToString();
                    labelPorcentajeBeneficio.Text = "0";

                    //Aqui se reinicia el total del beneficio a mostrar por q ya no va ser aplicado
                    totalBeneficioMostrar = 0;
                    idBeneficio = 0;
                    labelDescuentoBeneficio.Text = "0";

                    tablaBeneficiosAplicables.Rows.Clear();

                    Alertas.AlertCorrect("Desaplicar beneficio descuento", "El beneficio descuento ha sido quitado");
                    return;
                }


                if (tablaVenta.Rows.Count == 0)
                {
                    Alertas.AlertError("Error al aplicar el beneficio", "¡Deben haber productos en la lista!");
                }
                else
                {
                    if (!cajeroController.verificarPuntosTargetaParaAplicarBeneficio(inputTargetaCliente.Text, int.Parse(filaBeneficio.Cells[columnaPoints].Value.ToString())))
                    {
                        if (!cajeroController.validarPorcentajeDescuentoCodigo_DescuentoBeneficio(codigoDescuento, decimal.Parse(filaBeneficio.Cells[columnaPorcentajeDiscount].Value.ToString()), "beneficio"))
                        {
                            beneficioAplicado = true; //Cambiando el estado a true para decir que ya esta aplicado
                            /*Diseñaremos el nuevo boton luego de aplicar el beneficio*/
                            btnAplicarBeneficios.BackColor = Color.Red;
                            btnAplicarBeneficios.Text = "Desaplicar Beneficios de \r\nTargeta";
                            //Bloqueamos los inputs por cualquier cosa
                            inputTargetaCliente.Enabled = false;
                            inputDui.Enabled = false;
                            btnMostrarBeneficios.Enabled = false; //bloqueamos el boton para que no pueda filtrar de nuevo y q se quite su seleccion
                            tablaBeneficiosAplicables.Enabled = false; //y bloqueamos la tabla para que no seleccione por error otro beneficio

                            //Aqui aplicamos esto para saber el descuento en dinero q se le va a aplicar (VERIFICARA SI PONERLE EL DESCUENTO AL TOTAL o al nuevo total con descuento)
                            if (codigoAplicado == false)
                            {
                                totalBeneficioMostrar = cajeroController.conocerBeneficioDescuento(subTotalVentaMostrar, decimal.Parse(filaBeneficio.Cells[columnaPorcentajeDiscount].Value.ToString()));
                                labelDescuentoBeneficio.Text = totalBeneficioMostrar.ToString();
                            }
                            else
                            {
                                totalBeneficioMostrar = cajeroController.conocerBeneficioDescuento(totalVenta, decimal.Parse(filaBeneficio.Cells[columnaPorcentajeDiscount].Value.ToString()));
                                labelDescuentoBeneficio.Text = totalBeneficioMostrar.ToString();
                            }

                            //Calculos y muestra del beneficio en la vista
                            totalVenta = cajeroController.aplicar_revertirDescuentoTotalVenta(totalVenta, decimal.Parse(filaBeneficio.Cells[columnaPorcentajeDiscount].Value.ToString()), "aplicar");
                            labelMostrarTotal.Text = totalVenta.ToString();
                            labelPorcentajeBeneficio.Text = filaBeneficio.Cells[columnaPorcentajeDiscount].Value.ToString() + "%";

                            //Ahora le asignamos un id a la variable idBeneficio, si es q tiene
                            idBeneficio = int.Parse(filaBeneficio.Cells[columnaIdBeneficio].Value.ToString());

                            Alertas.AlertCorrect("Aplicando Beneficios", "Se ha aplicado el beneficio");
                            return;
                        }
                        else
                        {
                            Alertas.AlertError("Error al aplicar el codigo", "Existe un codigo de descuento que hace pasar el 100%");
                            return;
                        }

                    }
                    else
                    {
                        Alertas.AlertError("Error al aplicar el beneficio", "¡No tienes la cantidad de puntos requerida para obtener este beneficio!");
                        return;
                    }
                }
            }
            else
            {
                Alertas.AlertError("Error al aplicar el beneficio", "¡Debe seleccionar un beneficio!");
            }

        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            cajeroController cajeroController = new cajeroController();
            Customer customer = new Customer();
            Discount discount = new Discount();
            int columnaPtsUsar = 2;
            Customer_Card customer_Card = new Customer_Card();
            int puntosGanados = 0;
            DataGridViewRow filaBeneficio = null;

            if (beneficioAplicado == true)
            {
                filaBeneficio = tablaBeneficiosAplicables.SelectedRows[0];
            }

            if (tablaVenta.Rows.Count != 0)
            {
                if (Alertas.Confirmacion("Finalizando la compra", "¿Deseas finalizar la venta?"))
                {
                    if (metodoPagoEfectivo == true || metodoPagoTargeta == true)
                    {
                        if (cajeroController.revisarStockProductoSistema(tablaVenta.Rows))
                        {
                            

                            //settearemos el objeto de la venta para mandarlo a la bdd
                            Sale nuevaVenta = new Sale();

                            customer = cajeroController.obtenerCustomerWithDUI(inputDui.Text);
                            discount = cajeroController.encontrarDescuento(codigoDescuento);
                            customer_Card = cajeroController.obtenerCustomerCard(inputTargetaCliente.Text);

                            if (customer_Card != null && filaBeneficio != null) //aqui validamos para saber q enviarle al momento de estar llenando el objeto
                            { //aqui se valida para lo de los beneficios

                                //Calcularemos pts
                                if (codigoDescuento.Equals("") && idBeneficio == 0) // No ha usado pts
                                {
                                    puntosGanados = 2 * Convert.ToInt32(totalVenta);

                                }
                                else // Ha usado pts
                                {
                                    puntosGanados = 1 * Convert.ToInt32(totalVenta);

                                }

                                nuevaVenta.SetIdCustomer(customer.IdCustomer);
                                nuevaVenta.SetIdCard(customer_Card.IdCard);
                                nuevaVenta.SetPointUsed(int.Parse(filaBeneficio.Cells[columnaPtsUsar].Value.ToString()));
                                nuevaVenta.SetPointEarned(puntosGanados);
                            }
                            else
                            {
                                nuevaVenta.SetIdCustomer(null);
                                nuevaVenta.SetIdCard(null);
                                nuevaVenta.SetPointUsed(0);
                                nuevaVenta.SetPointEarned(0);
                            }

                            if (discount != null) //aqui validamos para saber q enviarle al momento de estar llenando el objeto
                            {
                                nuevaVenta.SetIdDiscount(discount.IdDiscount);

                            }
                            else
                            {
                                nuevaVenta.SetIdDiscount(null);
                            }

                            if (metodoPagoEfectivo == true)
                            {
                                nuevaVenta.SetIdPaymentMethod(2);
                            }
                            else
                            {
                                nuevaVenta.SetIdPaymentMethod(1);
                            }

                            
                            nuevaVenta.SetSaleDate(DateTime.Today);
                            nuevaVenta.SetTotalAmount(totalVenta);
                            nuevaVenta.SetIdUser(SessionManager.UserId);
                            

                            int idGenerado = cajeroController.registrarVenta(nuevaVenta);

                            if (idGenerado > 0)
                            {

                                List<Sale_Details> listProductosBDD = new List<Sale_Details>(); //se ocupara para el proceso de meter la lista a la bdd

                                foreach (DataGridViewRow filaProductoListaVenta in tablaVenta.Rows)
                                {
                                    Sale_Details producto = new Sale_Details();

                                    //asignando valores
                                    producto.IdSale = Convert.ToInt32(idGenerado);
                                    producto.IdProduct = Convert.ToInt32(filaProductoListaVenta.Cells["colIdProducto"].Value);
                                    producto.Quantity = Convert.ToInt32(filaProductoListaVenta.Cells["colCantidad"].Value.ToString());
                                    producto.Price = Convert.ToDecimal(filaProductoListaVenta.Cells["colPrecio"].Value);

                                    listProductosBDD.Add(producto);
                                }

                                if (cajeroController.registrarListaVenta(listProductosBDD))
                                {
                                    if (beneficioAplicado == true)
                                    {
                                        cajeroController.OperacionPuntosTargeta(inputTargetaCliente.Text, int.Parse(filaBeneficio.Cells[columnaPtsUsar].Value.ToString()), "restar");
                                        cajeroController.OperacionPuntosTargeta(inputDui.Text, puntosGanados, "sumar");
                                    }

                                    //if (cajeroController.reducirStockProductoSistema(tablaVenta.Rows))
                                    //{
                                        Alertas.AlertCorrect("Proceso de venta", "¡Se ha realizado la venta!");

                                        tablaBeneficiosAplicables.Rows.Clear();
                                        tablaBeneficiosAplicables.Enabled = true;
                                        tablaVenta.Rows.Clear();
                                        totalVenta = 0;
                                        subTotalVentaMostrar = 0;
                                        totalDescuentoMostrar = 0;
                                        totalBeneficioMostrar = 0;
                                        idBeneficio = 0;
                                        codigoDescuento = "";

                                        inputTargetaCliente.Text = "";
                                        inputDui.Text = "";
                                        inputCodigoProducto.Text = "";
                                        inputDui.Text = "";
                                        inputCodigoDescuento.Text = "";

                                        labelPtsTargeta.Text = "0";
                                        labelDescuentoBeneficio.Text = "0";
                                        labelMostrarSubtotalCompra.Text = "0";
                                        labelMostrarTotal.Text = "0";
                                        labelDescuentoDinero.Text = "0";

                                        codigoAplicado = false;
                                        beneficioAplicado = false;
                                        metodoPagoEfectivo = false;
                                        metodoPagoTargeta = false;
                                        btnAplicarBeneficios.Enabled = false;
                                        btnMostrarBeneficios.Enabled = true;
                                        btnEfectivo.Enabled = true;
                                        btnTargeta.Enabled = true;
                                        inputTargetaCliente.Enabled = false;
                                        inputDui.Enabled = false;
                                        inputCodigoDescuento.Enabled = true;


                                        //Diseño Boton
                                        btnAplicarCodDesc.BackColor = Color.FromArgb(0, 114, 223); //Cambiamos el color del boton a rojo para mejora visual
                                        btnAplicarCodDesc.Text = "Aplicar Codigo de Descuento";//cambiamos el texto para q se entienda el contexto de lo q es

                                        btnAplicarBeneficios.BackColor = Color.FromArgb(0, 114, 223);
                                        btnAplicarBeneficios.Text = "Aplicar Beneficios de \r\nTargeta";

                                        btnEfectivo.BackColor = Color.FromArgb(0, 114, 223);
                                        btnTargeta.BackColor = Color.FromArgb(0, 114, 223);

                                        checkTieneTargeta.Checked = false;

                                        return;
                                    //}

                                }
                                else
                                {
                                    Alertas.AlertError("Error en el proceso de venta", "¡ Surgio un error en el proceso de venta al momento de insertar la lista de productos :( ! ");
                                    return;
                                }


                            }
                            else
                            {
                                Alertas.AlertError("Error en el proceso de venta", "¡ Surgio un error en el proceso de venta :( ! ");
                            }
                        }
                    }
                    else
                    {
                        Alertas.AlertError("Error en el proceso de venta", "¡ Debe seleccionar un metodo de pago para progresar con la venta!");
                    }
                }
            }
            else
            {
                Alertas.AlertError("Error finalizar venta", "¡No has agregado ningun producto a la venta! ");
            }
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (metodoPagoEfectivo == true)
            {
                btnEfectivo.BackColor = Color.FromArgb(0, 114, 223);
                metodoPagoEfectivo = false;
            }
            else
            {
                btnEfectivo.BackColor = Color.LightGreen;
                metodoPagoEfectivo = true;
                btnTargeta.BackColor = Color.FromArgb(0, 114, 223);
                metodoPagoTargeta = false;
            }
        }

        private void btnTargeta_Click(object sender, EventArgs e)
        {
            if (metodoPagoEfectivo == true)
            {
                btnTargeta.BackColor = Color.FromArgb(0, 114, 223);
                metodoPagoTargeta =  false;
            }
            else
            {
                btnTargeta.BackColor = Color.LightGreen;
                metodoPagoTargeta = true;
                btnEfectivo.BackColor = Color.FromArgb(0, 114, 223);
                metodoPagoEfectivo = false;
            }
        }

        private void inputCantidadRetirar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
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
