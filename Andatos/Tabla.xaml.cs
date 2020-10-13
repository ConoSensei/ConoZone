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
    /// Lógica de interacción para Tabla.xaml
    /// </summary>
    public partial class Tabla : Page
    {
        public Tabla()
        {
            InitializeComponent();
        }
        
        static MySqlConnection Conex = new MySqlConnection();
        static string serv = "Server=localhost;";
        static string db = "Database=profesorado;";
        static string usuario = "UID=root;";
        static string pwd = "Password = root;";
        string CadenaDeConexion = serv + db + usuario + pwd;
        static MySqlCommand Comando = new MySqlCommand();
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

        private void MostrarDatos_Click(object sender, RoutedEventArgs e)
        {
            string secuenciaSQL = "select * from profesor order by Apellidos";
            MySqlCommand Comando = new MySqlCommand(secuenciaSQL, Conex);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);

            Tabla dbSQL = new Tabla();
            dbSQL.Conectar();
            Comando.ExecuteNonQuery();
            dbSQL.Desconectar();
            DataTable dt = new DataTable("id");
            Adaptador.Fill(dt);
            Data.ItemsSource = dt.DefaultView;
            Adaptador.Update(dt);

            
        }
        //Esto es el buscador
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string p = txt_search.Text + "%";
           
           string secuenciaSQL = $"select * from profesor where Apellidos like '{p}';";
           MySqlCommand Comando = new MySqlCommand(secuenciaSQL, Conex);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);

            Tabla dbSQL = new Tabla();
            dbSQL.Conectar();
            Comando.ExecuteNonQuery();
            dbSQL.Desconectar();
            DataTable dt = new DataTable("id");
            Adaptador.Fill(dt);
            Data.ItemsSource = dt.DefaultView;
            Adaptador.Update(dt);

        }
    }
    }

