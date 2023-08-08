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
using Ubiety.Dns.Core;

namespace ProyectoFinal23cv.Vistas_WPF
{
    /// <summary>
    /// Lógica de interacción para Carrera.xaml
    /// </summary>
    public partial class Carrera : Window
    {
        public Carrera()
        {
            InitializeComponent();
            GetCarreraTable();
        }
        CarreraServices serviceses = new CarreraServices();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }
        private void btnCarrera_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Carreras mojo = new Carreras();
            if (txtPKCarrera.Text == "")
            {
                mojo.NombreCarreras = txtNombreCarreras.Text;
                

                serviceses.AddCarrera(mojo);
                txtNombreCarreras.Clear();

                MessageBox.Show("Se Agrego Correctamente");
                GetCarreraTable();
            }
            else
            {    //tarea realalizar la funcion editar y eliminar
                // Editar usuario existente mediante su ID
                int carId = int.Parse(txtPKCarrera.Text);
                mojo = serviceses.GetCarreraById(carId);

                if (mojo != null)
                {
                    mojo.NombreCarreras = txtNombreCarreras.Text;

                    serviceses.EditCarrera(mojo);

                    MessageBox.Show("Se editó correctamente");
                    GetCarreraTable();
                }
                else
                {
                    MessageBox.Show("No se encontró la Carrera");
                }
            }
        }

        public void GetCarreraTable()
        {
            CarreraTable.ItemsSource = serviceses.GetCarreras();
        }

        private void EditItemCarrera_Click(object sender, RoutedEventArgs e)
        {
            Carreras carernose = new Carreras();
            carernose = (sender as FrameworkElement).DataContext as Carreras;  //Esta funcion trae la seccion de la fila

            txtPKCarrera.Text = carernose.PKCarreras.ToString();
            txtNombreCarreras.Text = carernose.NombreCarreras.ToString();
        }

        private void DeleteItemCarrera_Click(object sender, RoutedEventArgs e)
        {
            Carreras careps = (sender as FrameworkElement).DataContext as Carreras;
            MessageBoxResult rsul = MessageBox.Show("¿Estás seguro de que quieres eliminar esta Carrera?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (rsul == MessageBoxResult.Yes)
            {
                serviceses.DeleteCarrera(careps);

                txtNombreCarreras.Clear();
                MessageBox.Show("Carrera eliminada correctamente.");
                GetCarreraTable();
            }
        }
    }
}
