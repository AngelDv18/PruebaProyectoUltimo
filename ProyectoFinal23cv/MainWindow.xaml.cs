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
        private string userRole;
        public MainWindow()
        {
            InitializeComponent();
        }
        UsuarioServices services = new UsuarioServices();

        //  < TextBox x: Name = "txtPasword"  Margin = "423,372,383,0" TextWrapping = "Wrap" VerticalAlignment = "Top" Height = "32" /> 
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            {
                string user = txtUserName.Text;
                string password = txtPassword.Password.ToString();

                var response = services.Login(user, password);

                if (response != null)
                {
                    userRole = response.Papel.Nombre;

                    if (userRole == "SA")
                    {
                        {
                            MessageBox.Show("Sesión Iniciada Como Super Administrador");
                            //userRole = "SA";
                        Menu menu = new Menu();
                        //menu.UserRole = userRole; // Establecer el rol del SA en la ventana Menu
                        menu.Show();
                        Close();
                        //Menu menu = new Menu();
                        //menu.Show();
                        //Close();                      
                        }
                    }
                    else if (userRole == "Admin")
                    {
                        {
                            MessageBox.Show("Sesión Iniciada Como Administrador");
                            //userRole = "Admin";
                        Sistemas admi = new Sistemas();
                        admi.Show();
                        Close();                                                    
                        }
                    }
                    else if (userRole == "Alumnos")
                    {
                        {
                            MessageBox.Show("Sesión Iniciada Como Alumno");
                            //userRole = "Alumnos";
                        Menu alumnos = new Menu();
                      /*  alumnos.UserRole = userRole;*/ // Establecer el rol del Alumno en la ventana Menu
                        alumnos.Show();
                        Close();
                        //Menu alumnos = new Menu();
                        //alumnos.Show();
                        //Close(); 
                        }
                    }
                    else if (userRole == "Maestros")
                    {
                        {
                            MessageBox.Show("Sesión Iniciada Como Maestro");

                            //userRole = "Maestros";
                            Menu mas = new Menu();
                           /* mas.UserRole = userRole; */// Establecer el rol del Maestro en la ventana Menu
                            mas.Show();
                            Close();
                            //Menu maestos = new Menu();
                            //maestos.Show();
                            //Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rol Desconocido o Acceso no Autorizado.");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrectos");
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
        {            // Mostrar contraseña
            passwordTemp = txtPassword.Password;
            txtPassword.Visibility = Visibility.Collapsed;

            txtTempPassword.Text = passwordTemp;
            txtTempPassword.Visibility = Visibility.Visible;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {            // Ocultar contraseña
            passwordTemp = txtTempPassword.Text;
            txtTempPassword.Visibility = Visibility.Collapsed;

            txtPassword.Password = passwordTemp;
            txtPassword.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Si esta normal lo maximiza, si esta maximizado lo regresa normal.
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;            
        }
    }
}