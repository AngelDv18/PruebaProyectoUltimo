using MaterialDesignThemes.Wpf;
using ProyectoFinal23cv.Context;
using ProyectoFinal23cv.Entities;
using ProyectoFinal23cv.Services;
using ProyectoFinal23cv.Vistas_WPF;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        // <StackPanel Orientation = "Horizontal" Margin="565,331,159,331" AutomationProperties.Name="Text" Background="#FFE2E2E2">
        //  <materialDesign:PackIcon Kind = "Lock" Width="33" Height="33" Foreground="Black"/>
        //   <PasswordBox x:Name="txtPassword" materialDesign:HintAssist.Hint=" " Foreground="Black" Width="244" BorderBrush="Black" CaretBrush="#FFD94448" SelectionBrush="#FFD94448" Height="36" />
        //    </StackPanel>


        //  < TextBox x: Name = "txtPasword"  Margin = "423,372,383,0" TextWrapping = "Wrap" VerticalAlignment = "Top" Height = "32" /> 
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
                string password = txtPassword.Password.ToString();

                var response = services.Login(user, password);

                if (response.Papel.Nombre == "SA")
                {
                    Menu menu = new Menu();
                    menu.Show();
                    Close();
                }
                else
                {
                    Sistemas sistema = new Sistemas();
                    Close();
                    sistema.Show();
                }
            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private string passwordTemp;
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Mostrar contraseña
            passwordTemp = txtPassword.Password;
            txtPassword.Visibility = Visibility.Collapsed;

            txtTempPassword.Text = passwordTemp;
            txtTempPassword.Visibility = Visibility.Visible;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Ocultar contraseña
            passwordTemp = txtTempPassword.Text;
            txtTempPassword.Visibility = Visibility.Collapsed;

            txtPassword.Password = passwordTemp;
            txtPassword.Visibility = Visibility.Visible;
        }
    } 
}

#region
//private void btnRegister_Click(object sender, RoutedEventArgs e)
//{

//        //string username = User.Text;
//        //string password = Password.Text;
//        //// Obtener los valores de las propiedades adicionales          
//        //using (var dbContext = new ApplicationDbContext())
//        //{
//        //    bool userExists = dbContext.Usuarios.Any(u => u.UserName == username);

//        //    if (userExists)
//        //    {
//        //        MessageBox.Show("El usuario ya existe. Por favor, elija un nombre de usuario diferente.", "Registro Fallido", MessageBoxButton.OK, MessageBoxImage.Error);
//        //    }
//        //    else
//        //    {
//        //        var registerUser = new Usuario
//        //        {
//        //            Nombre = username,
//        //            UserName = username,
//        //            Password = password,
//        //        };
//        //        dbContext.Usuarios.Add(registerUser);
//        //        dbContext.SaveChanges();
//        //        MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.", "Registro Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
//        //        btnLogin_Click(sender, e);
//        //    }
//        //}
//    }
#endregion