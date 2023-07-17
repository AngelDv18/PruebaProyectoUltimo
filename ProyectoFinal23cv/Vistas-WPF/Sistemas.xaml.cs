using Microsoft.EntityFrameworkCore;
using ProyectoFinal23cv.Entities;
using ProyectoFinal23cv.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal23cv.Vistas_WPF
{
    /// <summary>
    /// Lógica de interacción para Sistemas.xaml
    /// </summary>
    public partial class Sistemas : Window
    {
        public Sistemas()
        {
            InitializeComponent();
            GetUserTable();
            GetPapels();
        }
        UsuarioServices services = new UsuarioServices();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            if (txtPkUser.Text == "")
            {
                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;
                usuario.FkPapel = int.Parse(SelectPapel.SelectedValue.ToString());

                services.AddUser(usuario);
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();

                MessageBox.Show("Se Agrego Correctamente");
                GetUserTable();
            }
            else
            {    //tarea realalizar la funcion editar y eliminar
                // Editar usuario existente mediante su ID7
                int userId = int.Parse(txtPkUser.Text);
                usuario = services.GetUserById(userId);

                if (usuario != null)
                {
                    usuario.Nombre = txtNombre.Text;
                    usuario.UserName = txtUserName.Text;
                    usuario.Password = txtPassword.Text;
                    usuario.FkPapel = int.Parse(SelectPapel.SelectedValue.ToString());

                    txtNombre.Clear();
                    txtUserName.Clear();
                    txtPassword.Clear();

                    services.EditUser(usuario);

                    MessageBox.Show("Se editó correctamente");
                    GetUserTable();
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario");
                }
            }           
        }
       public void GetUserTable()
       {
           UserTable.ItemsSource = services.GetUsers();
       }
        public void GetPapels()
        {
            SelectPapel.ItemsSource = services.GetPapels();
            /* SelectPapel.DisplayMenberPath = "Nombre"; */     /*esto sirve para no mandarlo a llamar desde el diseño*/
            /* SelectPapel.SelectedValuePath = "PKPapel"; */
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario = (sender as FrameworkElement).DataContext as Usuario;  //Esta funcion trae la seccion de la fila
            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();
            SelectPapel.SelectedValue = usuario.FkPapel;
        }
        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = (sender as FrameworkElement).DataContext as Usuario;
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este usuario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                services.DeleteUser(usuario);
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                MessageBox.Show("Usuario eliminado correctamente.");
                GetUserTable();
            }
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            Close();
        }
    }
}