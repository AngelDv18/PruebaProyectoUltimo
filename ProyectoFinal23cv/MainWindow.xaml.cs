using ProyectoFinal23cv.Context;
using ProyectoFinal23cv.Entities;
using ProyectoFinal23cv.Services;
using ProyectoFinal23cv.Vistas_WPF;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinal23cv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();
        }
        UsuarioServices services = new UsuarioServices();
        private void Iniciar_Click(object sender, RoutedEventArgs e)
        {
            // //
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            #region---login---
            //string username = User.Text;
            //string password = Password.Text;
            //using (var dbContext = new ApplicationDbContext())
            //{                // Buscar al usuario en la base de datos por nombre de usuario y contraseña
            //    var user = dbContext.Usuarios.FirstOrDefault(u => u.UserName == username && u.Password == password);
            //    if (user != null)
            //    {                    // Inicio de sesión exitoso
            //        MessageBox.Show("Inicio de sesión exitoso", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
            //        // Aquí puedes realizar las acciones necesarias después del inicio de sesión exitoso
            //        // Por ejemplo, abrir la ventana principal de la aplicación
            //        Sistemas sistemas = new Sistemas();
            //        sistemas.Show();
            //        // Cerrar la ventana de inicio de sesión
            //        Close();
            //    }
            //    else
            //    {                    // Credenciales inválidas
            //        MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Inicio de sesión fallido", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            #endregion         
            {
                string user = txtUserName.Text;
                string password = txtPassword.Text;

                var response = services.Login(user, password);

                if (response.Papel.Nombre == "sa")
                {
                    Sistemas sistema = new Sistemas();
                    Close();
                    sistema.Show();
                }
                else
                {
                    SistemaCopia sistemaCopia = new SistemaCopia();
                    Close();
                    sistemaCopia.Show();
                }

            }
        }
    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {

            //string username = User.Text;
            //string password = Password.Text;
            //// Obtener los valores de las propiedades adicionales          
            //using (var dbContext = new ApplicationDbContext())
            //{
            //    bool userExists = dbContext.Usuarios.Any(u => u.UserName == username);

            //    if (userExists)
            //    {
            //        MessageBox.Show("El usuario ya existe. Por favor, elija un nombre de usuario diferente.", "Registro Fallido", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    else
            //    {
            //        var registerUser = new Usuario
            //        {
            //            Nombre = username,
            //            UserName = username,
            //            Password = password,
            //        };
            //        dbContext.Usuarios.Add(registerUser);
            //        dbContext.SaveChanges();
            //        MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.", "Registro Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            //        btnLogin_Click(sender, e);
            //    }
            //}
        }
    }
}
