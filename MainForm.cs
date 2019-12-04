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
                listRecipes.ValueMember = "Instructions";
                listRecipes.DataSource = recipeTable;
            }
        }
        private void PopulateIngredients()
        {
            string query = "SELECT a.Name FROM ingredient a " +
                "INNER JOIN RecipeIngredient b ON a.Id = b.IngredientId " +
                "WHERE b.recipeId = @RecipeId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable ingredientTable = new DataTable();
                adapter.Fill(ingredientTable);

                listRecipes.DisplayMember = "Name";
                listRecipes.ValueMember = "Id";
                listRecipes.DataSource = ingredientTable;
            }
        }

        private void listRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            // Show Recipe's Instuctions when recipe is cicked
            MessageBox.Show(listRecipes.SelectedValue.ToString());
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
