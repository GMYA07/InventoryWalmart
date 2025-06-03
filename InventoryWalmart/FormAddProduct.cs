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
using InventoryWalmart.Controllers;
using InventoryWalmart.Model;

namespace InventoryWalmart
{
    public partial class FormAddProduct : Form
    {

        private CategoriaController categoriaController = new CategoriaController();
        private SupplierController proveedorController = new SupplierController();
        private ProductoController productoController = new ProductoController();


        public FormAddProduct()
        {
            InitializeComponent();
            CargarCategorias();
            CargarProveedores();
        }

        private void CargarCategorias()
        {
            try
            {
                var categorias = categoriaController.ObtenerCategorias();
                cb_categoria.DataSource = categorias;
                cb_categoria.DisplayMember = "category_name";
                cb_categoria.ValueMember = "id_category";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        private void CargarProveedores()
        {
            var proveedores = proveedorController.ObtenerProveedores();
            cb_proveedor.DataSource = proveedores;
            cb_proveedor.DisplayMember = "company_name"; 
            cb_proveedor.ValueMember = "id_supplier"; 
        }


        private Product productoActual; 
        private bool isEditing = false; 

        internal void CargarProducto(Product producto)
        {
            try
            {
                if (producto != null)
                {
                    productoActual = producto; // Almacena el producto actual para la edición
                    TxtNombreProduc.Text = producto.GetNameProduct();
                    txtPrecio.Text = producto.GetPrice().ToString();
                    txtPrecioSub.Text = producto.GetPriceSup().ToString();
                    txtStock.Text = producto.GetStock().ToString();
                    cb_categoria.SelectedValue = producto.GetIdCategory();
                    cb_proveedor.SelectedValue = producto.GetIdSupplier();
                    isEditing = true; // Indica que estamos en modo de edición
                }
                else
                {
                    MessageBox.Show("El producto no se pudo cargar. Verifica que el producto sea válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message);
            }
        }

        //Codigo q nos ayuda con la administrasion de la barra de arriba y mover la ventana.
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

        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }
        //conexiones

        private void barAcciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void LblIngresaDUI_Click(object sender, EventArgs e)
        {

        }

        private void LblDevolucion_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeView<viewInventary>();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombreProduc.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioSub.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            try
            {
                if (isEditing) // Si estamos en modo de edición
                {
                    // Actualizar el producto existente
                    productoActual.SetNameProduct(TxtNombreProduc.Text);
                    productoActual.SetPrice(decimal.Parse(txtPrecio.Text));
                    productoActual.SetPriceSup(decimal.Parse(txtPrecioSub.Text));
                    productoActual.SetStock(int.Parse(txtStock.Text));
                    productoActual.SetIdCategory((int)cb_categoria.SelectedValue);
                    productoActual.SetIdSupplier((int)cb_proveedor.SelectedValue);

                    productoController.ActualizarProducto(productoActual); // Asegúrate de tener este método en tu controlador
                    MessageBox.Show("Producto actualizado exitosamente.");
                }
                else
                {
                    // Agregar un nuevo producto
                    var nuevoProducto = new Product();
                    nuevoProducto.SetNameProduct(TxtNombreProduc.Text);
                    nuevoProducto.SetPrice(decimal.Parse(txtPrecio.Text));
                    nuevoProducto.SetPriceSup(decimal.Parse(txtPrecioSub.Text));
                    nuevoProducto.SetStock(int.Parse(txtStock.Text));
                    nuevoProducto.SetIdCategory((int)cb_categoria.SelectedValue);
                    nuevoProducto.SetIdSupplier((int)cb_proveedor.SelectedValue);

                    productoController.AgregarProducto(nuevoProducto);
                    MessageBox.Show("Producto agregado exitosamente.");
                }

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void LimpiarCampos()
        {
            TxtNombreProduc.Clear();
            txtPrecio.Clear();
            txtPrecioSub.Clear();
            txtStock.Clear();
            cb_categoria.SelectedIndex = 0;
            cb_proveedor.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecioSub_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
