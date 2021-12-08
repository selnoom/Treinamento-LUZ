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
using System.Data.SqlClient;
using System.Data;

namespace PokemonTeste
{
    /// <summary>
    /// Interaction logic for DataBaseWindow.xaml
    /// </summary>
    public partial class DataBaseWindow : Window
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrador\Documents\C#_Learning\Treinamento-LUZ\WPF\PokemonTeste\dbPokemon.mdf;Integrated Security=True";
        public DataBaseWindow()
        {
            InitializeComponent();
        }

        private void conectar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tbl_Pokemon", sqlCon); //data reach
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dgv.ItemsSource = dtbl.AsEnumerable();
            }
        }
    }
}
