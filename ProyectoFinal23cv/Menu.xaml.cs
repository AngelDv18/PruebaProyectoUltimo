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
using System.Windows.Shapes;

namespace ProyectoFinal23cv
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void txtAlumnno_Click(object sender, RoutedEventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.Show();
            Close();
        }

        private void txtMaestro_Click(object sender, RoutedEventArgs e)
        {
            Maestros maestros = new Maestros();
            maestros.Show();
            Close();
        }
        private void txtCarrera_Click(object sender, RoutedEventArgs e)
        {
            Carrera carrera = new Carrera();
            carrera.Show();
            Close();
        }

        private void txtGrupo_Click(object sender, RoutedEventArgs e)
        {
            Grupo grupo = new Grupo();
            grupo.Show();
            Close();
        }

        private void txtAdmin_Click(object sender, RoutedEventArgs e)
        {
            Sistemas sistemas = new Sistemas();
            sistemas.Show();
            Close();
        }
    }
}
