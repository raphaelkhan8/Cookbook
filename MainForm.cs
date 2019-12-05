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
            // methods in here are called when the form first loads
            PopulateRecipes();
            PopulateAllIngredients();
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

        private void PopulateAllIngredients()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ingredient", connection))
            {
                DataTable ingredientTable = new DataTable();
                adapter.Fill(ingredientTable);

                listAllIngredients.DisplayMember = "Name";
                listAllIngredients.ValueMember = "Id";
                listAllIngredients.DataSource = ingredientTable;
            }
        }

        private void PopulateIngredients()
        {
            string query = "SELECT a.Name FROM ingredient a " +
                "INNER JOIN RecipeIngredient b ON a.Id = b.IngredientId " +
                "WHERE b.RecipeId = @RecipeId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@RecipeId", listRecipes.SelectedValue);

                DataTable ingredientTable = new DataTable();
                adapter.Fill(ingredientTable);

                listIngredients.DisplayMember = "Name";
                listIngredients.ValueMember = "Id";
                listIngredients.DataSource = ingredientTable;
            }
        }

        private void listRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // methods here are called when a different recipe in the Recipes list-box is selected
            PopulateIngredients();

            /*
            // Show Recipe's Id when recipe is cicked
            MessageBox.Show(listRecipes.SelectedValue.ToString());
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {
         
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // methods here are called when a different ingredient in the Recipe Ingredeints list-box is selected
        }

        private void txtRecipeName_TextChanged(object sender, EventArgs e)
        {
            // methods here are called when something in the input Recipe Name text-box changes
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO recipe VALUES (@RecipeName, 9000, 'JUST DO IT')";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RecipeName", txtRecipeName.Text);
                command.ExecuteNonQuery();
            }
            // repopulate recipes with the newly added recipe:
            PopulateRecipes();
        }

        private void btnUpdateRecipeName_Click(object sender, EventArgs e)
        {
            // set the name of the selected recipe to whatever is typed in the text box
            string query = "UPDATE recipe SET Name = @RecipeName WHERE id = @RecipeId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RecipeName", txtRecipeName.Text);
                command.Parameters.AddWithValue("@RecipeId", listRecipes.SelectedValue);
                command.ExecuteNonQuery();
            }
            PopulateRecipes();
        }

        private void listAllIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            // methods here are called when an ingredient in the All Ingredients list-box is selected 
        }

        private void btnAddToRecipe_Click(object sender, EventArgs e)
        {
            // insert the selected ingredient into the join table
            string query = "INSERT INTO RecipeIngredient VALUES (@RecipeId, @IngredientId)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RecipeId", listRecipes.SelectedValue);
                command.Parameters.AddWithValue("@IngredientId", listAllIngredients.SelectedValue);
                command.ExecuteNonQuery();
            }
            // repopulate recipes with the newly added recipe:
            PopulateRecipes();
        }
    }
}
