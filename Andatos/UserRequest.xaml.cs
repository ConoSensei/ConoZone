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
    /// Lógica de interacción para UserRequest.xaml
    /// </summary>
    public partial class UserRequest : Page
    {
        public UserRequest()
        {
            InitializeComponent();
        }
        //Botones documentos
        private void btn_doc1_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Doc1.xaml", UriKind.Relative);

            this.NavigationService.Navigate(uri);
        }

        private void btn_doc2_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Doc2.xaml", UriKind.Relative);

            this.NavigationService.Navigate(uri);
        }

        private void btn_doc3_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Doc3.xaml", UriKind.Relative);

            this.NavigationService.Navigate(uri);
        }
    }
}
