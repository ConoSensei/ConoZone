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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace Andatos
{
    /// <summary>
    /// Lógica de interacción para Formulario.xaml
    /// </summary>
    public partial class Formulario : Page
    {
        public Formulario()
        {
            InitializeComponent();
        }
        // Variables de conexion con base de datos
        static MySqlConnection Conex = new MySqlConnection();
        static string serv = "Server=localhost;";
        static string db = "Database=profesorado;";
        static string usuario = "UID=root;";
        static string pwd = "Password = root;";
        string CadenaDeConexion = serv + db + usuario + pwd;

        static MySqlDataAdapter Adaptador = new MySqlDataAdapter();
      

        public void Conectar()
        {
            try
            {
                Conex.ConnectionString = CadenaDeConexion;
                Conex.Open();

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al conectar a la BD");
                throw;
            }
        }
        public void Desconectar()
        {
            Conex.Close();
        }
        //Boton tabla general
        private void btnenseniar_Click(object sender, RoutedEventArgs e)
        {

            Uri uri = new Uri("Tabla.xaml", UriKind.Relative);

            this.NavigationService.Navigate(uri);

        }
        //Boton tabla insertar
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            
            
            string secuenciaSQL = $"insert into profesor(DNI, Area, Apellidos, Nombre, Despacho, TelefonoDespacho, TelefonoMovil, Correo, Ordenador, Tutorias, AltaBaja, Titulacion, FigContractual, Observaciones) values ('{DNI.Text}','{Area.Text}','{Apellidos.Text}','{Nombre.Text}','{Despacho.Text}','{Telf_Despacho.Text}','{Telf_Movil.Text}','{Correo.Text}','{Ordenador.Text}','{Tutorias.Text}','{Alta_Baja.Text}','{Titulacion.Text}','{Figura_Contractual.Text}','{Observaciones.Text}');";
            MySqlCommand Comando = new MySqlCommand(secuenciaSQL, Conex);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);

            Formulario f1 = new Formulario();
            
            f1.Conectar();
            try
            {
                int i = Comando.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Registro insertado");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.ToString());

            }
            f1.Desconectar();
            DNI.Clear();
            Area.Clear();
            Apellidos.Clear();
            Nombre.Clear();
            Despacho.Clear();
            Telf_Despacho.Clear();
            Telf_Movil.Clear();
            Correo.Clear();
            Ordenador.Clear();
            Tutorias.Clear();
            Alta_Baja.Clear();
            Titulacion.Clear();
            Figura_Contractual.Clear();
            Observaciones.Clear();


        }
        //Boton tabla borrar
        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            string secuenciaSQL = $"delete from profesor where Apellidos='{Apellidos.Text}';";

            MySqlCommand Comando = new MySqlCommand(secuenciaSQL, Conex);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);

            Formulario f1 = new Formulario();

            f1.Conectar();
            try
            {
                int i = Comando.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Registro borrado");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.ToString());

                
            }
            f1.Desconectar();
            Apellidos.Clear();
        }
        //Boton tabla Buscar
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

            string secuenciaSQL = $"select * from profesor where Apellidos='{Apellidos.Text}';";
           
            MySqlCommand Comando = new MySqlCommand(secuenciaSQL, Conex);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);
           
            
            Comando.Parameters.AddWithValue("Apellidos", Apellidos.Text);
            Formulario f1 = new Formulario();

            f1.Conectar();
            
            MySqlDataReader leer = Comando.ExecuteReader();
            if (leer.Read())
            {
                DNI.Text = leer["DNI"].ToString();
                Area.Text = leer["Area"].ToString();
                Nombre.Text = leer["Nombre"].ToString();
                Despacho.Text = leer["Despacho"].ToString();
                Telf_Despacho.Text = leer["TelefonoDespacho"].ToString();
                Telf_Movil.Text = leer["TelefonoMovil"].ToString();
                Correo.Text = leer["Correo"].ToString();
                Ordenador.Text = leer["Ordenador"].ToString();
                Tutorias.Text = leer["Tutorias"].ToString();
                Alta_Baja.Text = leer["AltaBaja"].ToString();
                Titulacion.Text = leer["Titulacion"].ToString();
                Figura_Contractual.Text = leer["FigContractual"].ToString();
                Observaciones.Text = leer["Observaciones"].ToString();
               
            }
            f1.Desconectar();
        }
        //Boton tabla modificar
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            string secuenciaSQL = $"delete from profesor where Apellidos='{Apellidos.Text}';";
            string secuenciaSQL2 = $"insert into profesor(DNI, Area, Apellidos, Nombre, Despacho, TelefonoDespacho, TelefonoMovil, Correo, Ordenador, Tutorias, AltaBaja, Titulacion, FigContractual, Observaciones) values ('{DNI.Text}','{Area.Text}','{Apellidos.Text}','{Nombre.Text}','{Despacho.Text}','{Telf_Despacho.Text}','{Telf_Movil.Text}','{Correo.Text}','{Ordenador.Text}','{Tutorias.Text}','{Alta_Baja.Text}','{Titulacion.Text}','{Figura_Contractual.Text}','{Observaciones.Text}');";
            
            MySqlCommand Comando = new MySqlCommand(secuenciaSQL, Conex);
            MySqlCommand Comando2 = new MySqlCommand(secuenciaSQL2, Conex);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);
            MySqlDataAdapter Adaptador2 = new MySqlDataAdapter(Comando2);
            Formulario f1 = new Formulario();

            f1.Conectar();
            try
            {
                int i = Comando.ExecuteNonQuery();
                int h = Comando2.ExecuteNonQuery();
                if (i == 1 && h == 1)
                {
                    MessageBox.Show("Registro modificado");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.ToString());


            }
            f1.Desconectar();
        
        }
        //Boton tabla auxiliar
        private void btnenseniar2_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TablaSec.xaml", UriKind.Relative);

            this.NavigationService.Navigate(uri);
        }
        //Boton limpiar
        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            DNI.Clear();
            Area.Clear();
            Apellidos.Clear();
            Nombre.Clear();
            Despacho.Clear();
            Telf_Despacho.Clear();
            Telf_Movil.Clear();
            Correo.Clear();
            Ordenador.Clear();
            Tutorias.Clear();
            Alta_Baja.Clear();
            Titulacion.Clear();
            Figura_Contractual.Clear();
            Observaciones.Clear();
        }
        //Boton documentos
        private void btndoc_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UserRequest.xaml", UriKind.Relative);

            this.NavigationService.Navigate(uri);
        }
    }
}










