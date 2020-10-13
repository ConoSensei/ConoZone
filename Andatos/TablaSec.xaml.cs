using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para TablaSec.xaml
    /// </summary>
    public partial class TablaSec : Page
    {
        public TablaSec()
        {
            InitializeComponent();
        }
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

       

        private void btnmostrar_Click(object sender, RoutedEventArgs e)
        {
            String seleccion = "Nombre, Apellidos";
            if (DNIc.IsChecked == true)
            {
                seleccion = seleccion + ", DNI";
            }
            if (Areac.IsChecked == true)
            {
                seleccion = seleccion + ", Area";
            }
            if (Despachoc.IsChecked == true)
            {
                seleccion = seleccion + ", Despacho";
            }
            if (TelefonoDespachoc.IsChecked == true)
            {
                seleccion = seleccion + ", TelefonoDespacho";
            }
            if (TelefonoMovilc.IsChecked == true)
            {
                seleccion = seleccion + ", TelefonoMovil";
            }
            if (Correoc.IsChecked == true)
            {
                seleccion = seleccion + ", Correo";
            }
            if (Ordenadorc.IsChecked == true)
            {
                seleccion = seleccion + ", Ordenador";
            }
            if (Tutoriasc.IsChecked == true)
            {
                seleccion = seleccion + ", Tutorias";
            }
            if (AltaBajac.IsChecked == true)
            {
                seleccion = seleccion + ", AltaBaja";
            }
            if (Titulacionc.IsChecked == true)
            {
                seleccion = seleccion + ", Titulacion";
            }
            if (FigContractualc.IsChecked == true)
            {
                seleccion = seleccion + ", FigContractual";
            }
            if (Observacionesc.IsChecked == true)
            {
                seleccion = seleccion + ", Observaciones";
            }
            string secuenciaSQL = $"select {seleccion} from profesor order by Apellidos";
            MySqlCommand Comando = new MySqlCommand(secuenciaSQL, Conex);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);

            TablaSec dbSQL = new TablaSec();
            dbSQL.Conectar();
            Comando.ExecuteNonQuery();
            dbSQL.Desconectar();
            DataTable dt = new DataTable("id");
            Adaptador.Fill(dt);
            Data2.ItemsSource = dt.DefaultView;
            Adaptador.Update(dt);
        }
    }
}
