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
    public partial class viewInventary : Form
    {

        private ProductoController productoController;


        private CategoriaController categoriaController = new CategoriaController();

        public viewInventary()
        {
            InitializeComponent();
            productoController = new ProductoController();
            categoriaController = new CategoriaController();
            CargarCategorias();
            CargarProductos();
            inputBuscar.TextChanged += inputBuscar_TextChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void CargarCategorias()
        {
            var categorias = categoriaController.ObtenerCategorias();
            comboBox1.DataSource = categorias;
            comboBox1.DisplayMember = "category_name"; // Ajusta esto según tu modelo
            comboBox1.ValueMember = "id_category"; // Ajusta esto según tu modelo
        }

        // Método para cargar productos en el DataGridView
        private void CargarProductos()
        {
            List<Product> productos = productoController.ObtenerProductos();
            Table_Customers.Rows.Clear();

            foreach (var producto in productos)
            {
                Table_Customers.Rows.Add(
                    producto.GetIdProduct(),
                    producto.GetNameProduct(),
                    producto.GetPrice(),
                    producto.GetPriceSup(),
                    producto.GetStock(),
                    producto.GetIdCategory(),
                    producto.GetIdSupplier()
                );
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


        private void btnAplicarBene_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botón de editar presionado."); // Mensaje de depuración
            if (Table_Customers.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Por favor, selecciona un producto para editar.");
            }
            else
            {
                var selectedRow = Table_Customers.SelectedRows[0];
                var productoId = (int)selectedRow.Cells["Id"].Value; // Asegúrate de que "Id" sea el nombre correcto
                var producto = productoController.ObtenerProductoPorId(productoId); // Llama al método

                if (producto != null)
                {
                    FormAddProduct formAddProduct = new FormAddProduct();
                    formAddProduct.CargarProducto(producto); // Carga el producto seleccionado
                    formAddProduct.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto seleccionado.");
                }

                CargarProductos(); // Recarga la lista de productos después de editar
            }
        }

  
        private void Lbl_Title_Click(object sender, EventArgs e)
        {

        }

        private void btnDevoluciones_Click_1(object sender, EventArgs e)
        {
            ChangeView<ViewReturns>();
        }

        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            ChangeView<dashboard>();
        }

        private void btnPromociones_Click_1(object sender, EventArgs e)
        {
            ChangeView<viewBenefitsRewards>();
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            ChangeView<viewInventary>();
        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            ChangeView<FormGenerarReporte>();
        }

        private void btnEmpleado_Click_1(object sender, EventArgs e)
        {
            ChangeView<ViewUser>();
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            ChangeView<ViewCustomers>();
        }

        private void BtnPuntos_Click_1(object sender, EventArgs e)
        {
            ChangeView<ViewPoints>();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            ChangeView<viewGestionVentas>();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ChangeView<FormAddProduct>();
        }

        private void btnAplicarBene_Click_1(object sender, EventArgs e)
        {
            if (Table_Customers.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Por favor, selecciona un producto para editar.");
            }
            else
            {
                var selectedRow = Table_Customers.SelectedRows[0];
                var productoId = (int)selectedRow.Cells["columnID"].Value;
                var producto = productoController.ObtenerProductoPorId(productoId);

                if (producto != null)
                {
                    this.Hide();
                    FormAddProduct formAddProduct = new FormAddProduct();
                    formAddProduct.CargarProducto(producto); // Carga el producto seleccionado
                    formAddProduct.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto seleccionado.");
                }

                CargarProductos(); // Recarga la lista de productos después de editar
            }
        }

        private void inputBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos(inputBuscar.Text);
        }

        private void FiltrarProductos(string searchTerm)
        {
            // Obtiene la lista de productos desde el controlador
            List<Product> productos = productoController.ObtenerProductos();

            // Filtra los productos que contengan el término de búsqueda
            var productosFiltrados = productos
                .Where(p => p.GetNameProduct().ToLower().Contains(searchTerm.ToLower()))
                .ToList();

            // Actualiza el DataGridView con los productos filtrados
            Table_Customers.Rows.Clear(); // Limpia el DataGridView antes de llenarlo

            foreach (var producto in productosFiltrados)
            {
                Table_Customers.Rows.Add(
                    producto.GetIdProduct(),
                    producto.GetNameProduct(),
                    producto.GetPrice(),
                    producto.GetPriceSup(),
                    producto.GetStock(),
                    producto.GetIdCategory(),
                    producto.GetIdSupplier()
                );
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductosPorCategoria((int)comboBox1.SelectedValue);
        }

        private void FiltrarProductosPorCategoria(int categoriaId)
        {
            List<Product> productos = productoController.ObtenerProductos(); // Obtén todos los productos
            var productosFiltrados = productos.Where(p => p.GetIdCategory() == categoriaId).ToList(); // Filtra por categoría

            // Actualiza el DataGridView
            Table_Customers.Rows.Clear(); // Limpia el DataGridView antes de llenarlo
            foreach (var producto in productosFiltrados)
            {
                Table_Customers.Rows.Add(
                    producto.GetIdProduct(),
                    producto.GetNameProduct(),
                    producto.GetPrice(),
                    producto.GetPriceSup(),
                    producto.GetStock(),
                    producto.GetIdCategory(),
                    producto.GetIdSupplier()
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Table_Customers.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
                return;
            }

            var selectedRow = Table_Customers.SelectedRows[0];
            var productoId = (int)selectedRow.Cells["columnID"].Value;

            // Confirmar eliminación
            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                 "Confirmar eliminación",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Llama al método en el controlador para eliminar el producto
                productoController.EliminarProducto(productoId);

                // Recargar productos
                CargarProductos();
                MessageBox.Show("Producto eliminado exitosamente.");

                // Desactivar la selección automática
                Table_Customers.ClearSelection();
            }
        }



        //fin conexiones
    }
}
