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
    /// Lógica de interacción para Maestros.xaml
    /// </summary>
    public partial class Maestros : Window
    {
        public Maestros()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            Close();
        }

        private void btnAddMaestro_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
