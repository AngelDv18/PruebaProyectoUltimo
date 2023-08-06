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
    /// Lógica de interacción para Alumno.xaml
    /// </summary>
    public partial class Alumno : Window
    {
        public Alumno()
        {
            InitializeComponent();
            GetUserTableAlu();
            GetPapeles();
        }
        AlumnosServices servis = new AlumnosServices();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }
        private void btnAddAlumno_Click(object sender, RoutedEventArgs e)
        {
            Alumnos alu = new Alumnos();
            if (txtPkAlumno.Text == "")
            {

                alu.NombreAlumno = txtNombreAlumno.Text;
                alu.ApellidoP = txtApellidoP.Text;
                alu.ApellidoM = txtApellidoM.Text;
                alu.Fechaqueregistro = DateTime.Now;
                alu.FkPapel = int.Parse(SelectPapel.SelectedValue.ToString());

                servis.AddAlumn(alu);
                txtNombreAlumno.Clear();
                txtApellidoP.Clear();
                txtApellidoM.Clear();
                txtFechaqueRegistro.Clear();

                MessageBox.Show("Se Agrego Correctamente");
                GetUserTableAlu();
            }
            else
            {    //tarea realalizar la funcion editar y eliminar
                // Editar usuario existente mediante su ID7
                int alutId = int.Parse(txtPkAlumno.Text);
                alu = servis.GetUserByIdAlu(alutId);

                if (alu != null)
                {

                    alu.NombreAlumno = txtNombreAlumno.Text;
                    alu.ApellidoP = txtApellidoP.Text;
                    alu.ApellidoM = txtApellidoM.Text;
                    alu.Fechaqueregistro = DateTime.Now;
                    alu.FkPapel = int.Parse(SelectPapel.SelectedValue.ToString());

                    txtNombreAlumno.Clear();
                    txtApellidoP.Clear();
                    txtApellidoM.Clear();
                    txtFechaqueRegistro.Clear();

                    servis.EditAlumn(alu);

                    MessageBox.Show("Se editó correctamente");
                    GetUserTableAlu();
                }
                else
                {
                    MessageBox.Show("No se encontró el alumno");
                }
            }
        }
        public void GetUserTableAlu()
        {
            UserTableAlu.ItemsSource = servis.GetAlumn();
        }
        public void GetPapeles()
        {
            SelectPapel.ItemsSource = servis.GetPapeles();
            /* SelectPapel.DisplayMenberPath = "Nombre"; */     /*esto sirve para no mandarlo a llamar desde el diseño*/
            /* SelectPapel.SelectedValuePath = "PKPapel"; */
        }
        private void EditItemAlu_Click(object sender, RoutedEventArgs e)
        {
            Alumnos alumnose = new Alumnos();
            
            alumnose = (sender as FrameworkElement).DataContext as Alumnos;  //Esta funcion trae la seccion de la fila

            txtPkAlumno.Text = alumnose.PkAlumno.ToString();
            txtNombreAlumno.Text = alumnose.NombreAlumno.ToString();
            txtApellidoP.Text = alumnose.ApellidoP.ToString();
            txtApellidoM.Text = alumnose.ApellidoM.ToString();
            txtFechaqueRegistro.Text = alumnose.Fechaqueregistro.ToString();
            SelectPapel.SelectedValue = alumnose.FkPapel;
        }
        private void DeleteItemAlus_Click(object sender, RoutedEventArgs e)
        {
            //esto sirve para eliminar los datos tanto en la base de datos como en la tabla
            Alumnos alumnos = (sender as FrameworkElement).DataContext as Alumnos;
            MessageBoxResult resulta = MessageBox.Show("¿Estás seguro de que quieres eliminar este Alumno?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resulta == MessageBoxResult.Yes)
            {
                servis.DeletAlus(alumnos);

                txtNombreAlumno.Clear();
                txtApellidoP.Clear();
                txtApellidoM.Clear();
                txtFechaqueRegistro.Clear();
                MessageBox.Show("Alumno eliminado correctamente.");
                GetUserTableAlu();
            }
        }

        private void Cerrarcesion_Click(object sender, RoutedEventArgs e)
        {
            {
                MessageBox.Show("Sesión Cerrada");
            }
            MainWindow CS = new MainWindow();
            CS.Show();
            Close();
        }
    }
}