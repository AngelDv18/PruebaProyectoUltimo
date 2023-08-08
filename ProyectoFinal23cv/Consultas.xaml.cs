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

namespace ProyectoFinal23cv
{
    /// <summary>
    /// Lógica de interacción para Consultas.xaml
    /// </summary>
    public partial class Consultas : Window
    {
        private readonly UsuarioServices usuarioServices;
        private readonly AlumnosServices alumnosServices;
        private readonly MaestrosServices maestrosServices;
        private readonly GrupoServices gruposServices;
        private readonly CarreraServices carreraServices;
        public Consultas()
        {
            InitializeComponent();
            // Instancia los servicios para acceder a los datos
            usuarioServices = new UsuarioServices();
            alumnosServices = new AlumnosServices();
            maestrosServices = new MaestrosServices();
            gruposServices = new GrupoServices();
            carreraServices = new CarreraServices();
        }
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
            string tablaSeleccionada = ((ComboBoxItem)cmbTabla.SelectedItem).Content.ToString();

            switch (tablaSeleccionada)
            {
                case "Usuarios":
                    dataGrid.ItemsSource = usuarioServices.BuscarUsuarios(filtro);
                    break;
                case "Alumnos":
                    dataGrid.ItemsSource = alumnosServices.BuscarAlumnos(filtro);
                    break;
                case "Maestros":
                    dataGrid.ItemsSource = maestrosServices.BuscarMaestros(filtro);
                    break;
                case "Grupos":
                    dataGrid.ItemsSource = gruposServices.BuscarGrupos(filtro);
                    break;
                case "Carreras":
                    dataGrid.ItemsSource = carreraServices.BuscarCarreras(filtro);
                    break;
            }
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow logim = new MainWindow();
            logim.Show();
            Close();
        }

        private void btnAdios_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            Close();
        }
    }
}