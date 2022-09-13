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
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace lab04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //String server = @"Server = ROBERTO\SQLEXPRESS;DataBase=db_lab04;User Id=sa;Password=BIG_mama_4lov3;";
        SqlConnection conn = new SqlConnection(@"Server = ROBERTO\SQLEXPRESS;DataBase=db_lab04;User Id=sa;Password=BIG_mama_4lov3;");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<PersonModel> personList = new List<PersonModel>();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Person", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                personList.Add(new PersonModel
                {
                    PersonID = reader["PersonID"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                });
            }

            conn.Close();
            dgvPerson.ItemsSource = personList;
        }
    }
}
