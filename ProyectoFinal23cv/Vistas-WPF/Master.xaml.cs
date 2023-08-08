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
    /// Lógica de interacción para Master.xaml
    /// </summary>
    public partial class Master : Window
    {
        public Master()
        {
            InitializeComponent();
            GetMasterTable();
            GetPapels();
        }
        MaestrosServices servics = new MaestrosServices();
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Menu meus = new Menu();
            meus.Show();
            Close();
        }
        private void btnAddMaestro_Click(object sender, RoutedEventArgs e)
        {
            Maestros ma = new Maestros();
            if (txtPkMaestros.Text == "")
            {
                ma.NombreMaestros = txtNombreMaestros.Text;
                ma.Especialidad = txtEspecialidad.Text;
                ma.FechasRegistrada = DateTime.Now;
                ma.FkPapel = int.Parse(SelectPapel.SelectedValue.ToString());
                ma.FkCarreras = int.Parse(txtFkCarreras.Text);
                ma.FkGrupos = int.Parse(txtFkGrupos.Text);


                servics.AddMaster(ma);
                txtNombreMaestros.Clear();
                txtEspecialidad.Clear();
                txtFkCarreras.Clear();
                txtFkGrupos.Clear();

                MessageBox.Show("Se Agrego Correctamente");
                GetMasterTable();
            }
            else
            {    //tarea realalizar la funcion editar y eliminar     // Editar usuario existente mediante su ID
                int mateId = int.Parse(txtPkMaestros.Text);
                ma = servics.GetMastersById(mateId);

                if (ma != null)
                {
                    ma.NombreMaestros = txtNombreMaestros.Text;
                    ma.Especialidad = txtEspecialidad.Text;
                    ma.FechasRegistrada = DateTime.Now;
                    ma.FkPapel = int.Parse(SelectPapel.SelectedValue.ToString());
                    ma.FkCarreras = int.Parse(txtFkCarreras.Text);
                    ma.FkGrupos = int.Parse(txtFkGrupos.Text);

                    txtNombreMaestros.Clear();
                    txtEspecialidad.Clear();
                    txtFechasRegistrada.Clear();
                    txtPkMaestros.Clear();
                    txtFkCarreras.Clear();
                    txtFkGrupos.Clear();

                    servics.EditMaster(ma);

                    MessageBox.Show("Se editó correctamente");
                    GetMasterTable();
                }
                else
                {
                    MessageBox.Show("No se encontró el maestro");
                }
            }
        }
        public void GetMasterTable()
        {
            MasterTable.ItemsSource = servics.GetMaster();
        }
        public void GetPapels()
        {
            SelectPapel.ItemsSource = servics.GetPapels();
            /* SelectPapel.DisplayMenberPath = "Nombre"; */     /*esto sirve para no mandarlo a llamar desde el diseño*/
            /* SelectPapel.SelectedValuePath = "PKPapel"; */
        }
        private void EditItemsMaster_Click(object sender, RoutedEventArgs e)
        {
            Maestros mase = new Maestros();
            mase = (sender as FrameworkElement).DataContext as Maestros;  //Esta funcion trae la seccion de la fila
            txtPkMaestros.Text = mase.PkMaestros.ToString();
            txtNombreMaestros.Text = mase.NombreMaestros.ToString();
            txtEspecialidad.Text = mase.Especialidad.ToString();
            txtFechasRegistrada.Text = mase.FechasRegistrada.ToString();
            SelectPapel.SelectedValue = mase.FkPapel;
            txtFkCarreras.Text = mase.FkCarreras.ToString();
            txtFkGrupos.Text = mase.FkGrupos.ToString();
        }
        private void DeleteItemsMaster_Click(object sender, RoutedEventArgs e)
        {
            Maestros mats = (sender as FrameworkElement).DataContext as Maestros;
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar este Maestro?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes)
            {
                servics.DeleteMaster(mats);
                txtNombreMaestros.Clear();
                txtEspecialidad.Clear();
                txtPkMaestros.Clear();
                txtFechasRegistrada.Clear();
                txtFkCarreras.Clear();
                txtFkGrupos.Clear();
                MessageBox.Show("Maestro eliminado correctamente.");
                GetMasterTable();
            }
        }
        private void Apagado_Click(object sender, RoutedEventArgs e)
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