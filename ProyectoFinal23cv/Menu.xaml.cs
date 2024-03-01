using ProyectoFinal23cv.Entities;
using ProyectoFinal23cv.Services;
using ProyectoFinal23cv.Vistas_WPF;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ubiety.Dns.Core;

namespace ProyectoFinal23cv
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        //public string UserRole { get; set; }
        public Menu()
        {
            InitializeComponent();                
        }
        private void btnAlumno_Click(object sender, RoutedEventArgs e)
        {
            //if (UserRole == "Alumnos" || UserRole == "SA" || UserRole == "Admin")
            {
                Alumno alumn = new Alumno();
                alumn.Show();
                    Close();
            }
            //else
            //{
            //    MessageBox.Show("Acceso Denegado");
            //}
        }
        private void btnMaestro_Click(object sender, RoutedEventArgs e)
        {
            //if (UserRole == "Maestros" || UserRole == "SA" || UserRole == "Admin")
            {
                Master mast = new Master();
                mast.Show();
                Close();
            }
            //else
            //{
            //    MessageBox.Show("Acceso Denegado");
            //}       
        }
        private void btnCarrera_Click(object sender, RoutedEventArgs e)
        {
            //if (UserRole == "SA" || UserRole == "Admin")
            {
                Carrera car = new Carrera();
                car.Show();
                Close();
            }
            //else
            //{
            //    MessageBox.Show("Acceso Denegado");
            //}        
        }
        private void btnGrupo_Click(object sender, RoutedEventArgs e)
        {
            //if (UserRole == "SA" || UserRole == "Admin")
            {
                Grupo gru = new Grupo();
                gru.Show();
                Close();
            }
            //else
            //{
            //    MessageBox.Show("Acceso Denegado");
            //}        
        }
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            //if (UserRole == "SA" || UserRole == "Admin")
            {
                Sistemas sa = new Sistemas();
                sa.Show();
                Close();
            }
            //else
            //{
            //    MessageBox.Show("Acceso Denegado");
            //}        
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                MessageBox.Show("Sesión Cerrada");
            }
            MainWindow login = new MainWindow();
            login.Show();
            Close();            
        }
    }
}