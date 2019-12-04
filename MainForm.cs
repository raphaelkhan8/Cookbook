using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CookBook
{
    public partial class MainForm : Form
    {
        SqlConnection connection;
        string connectionString;
        public MainForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["CookBook.Properties.Settings.CookBookConnectionString"].ConnectionString;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateRecipes();
        }

        private void PopulateRecipes()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM recipe", connection))
            {
                DataTable recipeTable = new DataTable();
                adapter.Fill(recipeTable);

                listRecipes.DisplayMember = "Name";
                listRecipes.ValueMember = "Id";
                listRecipes.DataSource = recipeTable;
            }
        }
    }
}
