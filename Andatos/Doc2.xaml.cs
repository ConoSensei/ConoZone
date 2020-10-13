using MySql.Data.MySqlClient;
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

namespace Andatos
{
    /// <summary>
    /// Lógica de interacción para Doc2.xaml
    /// </summary>
    public partial class Doc2 : Page
    {
        public Doc2()
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
        //Boton generar
        private void btn_generar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = "";
            String dni = "";
            String fcont = "";
            String apellido = "";
            DateTime thisDay = DateTime.Today;
            String fecha = thisDay.ToString("D");
            String Area = "";
            string secuenciaSQL = $"select * from profesor where Apellidos='{nom.Text}';";

            MySqlCommand Comando = new MySqlCommand(secuenciaSQL, Conex);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);


            Comando.Parameters.AddWithValue("Apellidos", nom.Text);
            Doc2 f1 = new Doc2();

            f1.Conectar();


            MySqlDataReader leer = Comando.ExecuteReader();
            if (leer.Read())
            {
                dni = leer["DNI"].ToString();
                Area= leer["Area"].ToString();
                nombre = leer["Nombre"].ToString();
                apellido = leer["Apellidos"].ToString();
                //  Despacho.Text = leer["Despacho"].ToString();
                //Telf_Despacho.Text = leer["TelefonoDespacho"].ToString();
                //Telf_Movil.Text = leer["TelefonoMovil"].ToString();
                //Correo.Text = leer["Correo"].ToString();
                //Ordenador.Text = leer["Ordenador"].ToString();
                //Tutorias.Text = leer["Tutorias"].ToString();
                //Alta_Baja.Text = leer["AltaBaja"].ToString();
                //Titulacion.Text = leer["Titulacion"].ToString();
                fcont = leer["FigContractual"].ToString();


            }
            f1.Desconectar();
            //Contenido de documento autogenerado
            lb.Content = "Informa que: " + nombre + " " + apellido + ", con D.N.I. " + dni + ", " + fcont + ", \r\n presta sus servicios en el Campus ubicado en la Carretera \r\n de Utrera Km. 1, de Sevilla,  \r\n  perteneciendo al Área académica de: " +Area+ "\r\n \r\n Documento validado a " + fecha + "\r\n \r\n \r\n \r\n Fdo.: " + nom2.Text;
            sublb.Content = nom2.Text;
        }
        private void btn_imprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();

            MessageBoxResult respuesta = MessageBox.Show("Desea imprimir el texto?, si no, se imprimira la aplicación", "Impresión", MessageBoxButton.YesNoCancel);

            if (respuesta == MessageBoxResult.Yes)

            {

                // Imprimir el texto

                if (dialog.ShowDialog() == true)

                {

                    String texto = sublb.ContentStringFormat + lb.ContentStringFormat;

                    Run r = new Run(texto);

                    Paragraph parrafo = new Paragraph();

                    parrafo.Inlines.Add(r);

                    FlowDocument doc = new FlowDocument(parrafo);

                    doc.PagePadding = new Thickness(100);

                    dialog.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, texto);

                }

            }



        }
    }
}
