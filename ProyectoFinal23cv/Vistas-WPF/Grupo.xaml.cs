using ProyectoFinal23cv.Entities;
using ProyectoFinal23cv.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    /// Lógica de interacción para Grupo.xaml
    /// </summary>
    public partial class Grupo : Window
    {
        public Grupo()
        {
            InitializeComponent();
            GetGrupoTable();
        }
        GrupoServices servic = new GrupoServices();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Grupos gru = new Grupos();
            if (txtPKGrupos.Text == "")
            {
                gru.NombreGrupos = txtNombreGrupos.Text;

                servic.AddGrupos(gru);
                txtNombreGrupos.Clear();

                MessageBox.Show("Se Agrego Correctamente");
                GetGrupoTable();
            }
            else
            {    //tarea realalizar la funcion editar y eliminar
                // Editar usuario existente mediante su ID
                int grupId = int.Parse(txtPKGrupos.Text);
                gru = servic.GetGroupById(grupId);

                if (gru != null)
                {
                    gru.NombreGrupos = txtNombreGrupos.Text;

                    servic.EditGrupo(gru);

                    MessageBox.Show("Se editó correctamente");
                    GetGrupoTable();
                }
                else
                {
                    MessageBox.Show("No se encontró el grupo");
                }
            }
        }

        public void GetGrupoTable()
        {
            GrupoTable.ItemsSource = servic.GetGrupos();
        }

        private void EditItemGrupo_Click(object sender, RoutedEventArgs e)
        {
            Grupos grunose = new Grupos();
            grunose = (sender as FrameworkElement).DataContext as Grupos;  //Esta funcion trae la seccion de la fila

            txtPKGrupos.Text = grunose.PKGrupos.ToString();
            txtNombreGrupos.Text = grunose.NombreGrupos.ToString();
        }

        private void DeleteItemGrupo_Click(object sender, RoutedEventArgs e)
        {
            Grupos grups = (sender as FrameworkElement).DataContext as Grupos;
            MessageBoxResult rsulta = MessageBox.Show("¿Estás seguro de que quieres eliminar este Grupo?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (rsulta == MessageBoxResult.Yes)
            {
                servic.DeleteGrupo(grups);

                txtNombreGrupos.Clear();
                MessageBox.Show("Grupo eliminado correctamente.");
                GetGrupoTable();
            }
        }
    }
}