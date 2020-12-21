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
using System.Collections;

namespace WpfAppPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=CRUD-ASP.NET-APP;Integrated Security=True;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Students_Details", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lbDisplay1.Items.Add(dr["name"]);
            }

            dr.Close();
            con.Close();
        }

        private void btnForwardOne_Click(object sender, RoutedEventArgs e)
        {
            lbDisplay2.Items.Add(lbDisplay1.SelectedItem);
            lbDisplay1.Items.Remove(lbDisplay1.SelectedItem);
        }

        private void btnBackwardMultiple_Click(object sender, RoutedEventArgs e)
        {
            lbDisplay1.Items.Add(lbDisplay2.SelectedItem);
            lbDisplay2.Items.Remove(lbDisplay2.SelectedItem);
        }

        private void btnForwardMultiple_Click(object sender, RoutedEventArgs e)
        {
            ArrayList ls = new ArrayList();

            foreach (var obj in lbDisplay1.SelectedItems)
            {
                lbDisplay2.Items.Add(obj);
                ls.Add(obj);
            }

            foreach (var obj in ls)
            {
                lbDisplay1.Items.Remove(obj);
            }
        }

        private void btnBackwardOne_Click(object sender, RoutedEventArgs e)
        {
            ArrayList ls = new ArrayList();

            foreach (var obj in lbDisplay2.SelectedItems)
            {
                lbDisplay1.Items.Add(obj);
                ls.Add(obj);
            }

            foreach (var obj in ls)
            {
                lbDisplay2.Items.Remove(obj);
            }
        }
    }
}
