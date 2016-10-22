using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Exam.Models
{
    [DataContract]
    public class Dish
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public decimal Price { get; private set; }
        [DataMember]
        public string TotalAmount { get; private set; }
        [DataMember]
        public List<Ingredient> Ingredients { get; private set; }

        private readonly SqlConnection _sqlConnection;

        public Dish() { }

        public Dish(string name, decimal price, string totalAmount, SqlConnection connection)
        {
            Name = name;
            Price = price;
            TotalAmount = totalAmount;

            Ingredients = new List<Ingredient>();
            _sqlConnection = connection;

            InitIngredients();
        }

        /// <summary>
        /// Get all dishes form database.
        /// </summary>
        /// <param name="connection">Connection to the restaurant database</param>
        /// <returns></returns>
        public static List<Dish> GetAllDishes(SqlConnection connection)
        {
            List<Dish> result = new List<Dish>();

            SqlCommand sqlCommandAllDeshes = new SqlCommand("SELECT * FROM Dishes", connection);
            SqlDataReader reader = sqlCommandAllDeshes.ExecuteReader();

            while (reader.Read())
            {
                string name = (string)reader.GetValue(0);
                string totalAmount = (string)reader.GetValue(1);
                decimal price = (decimal)reader.GetValue(2);

                result.Add(new Dish(name, price, totalAmount, connection));
            }

            reader.Close();

            return result;
        }

        /// <summary>
        /// Add a new Dish.
        /// </summary>
        /// <param name="newDish">A new Dish</param>
        /// <param name="connection">Connection to the restaurant database.</param>
        public static void AddDish(Dish newDish, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(
                $"INSERT INTO Dishes VALUES ('{newDish.Name}', '{newDish.TotalAmount}', '{newDish.Price}')",
                connection);
            sqlCommand.ExecuteReader();

            foreach (Ingredient ingredient in newDish.Ingredients)
            {
                sqlCommand = new SqlCommand(
                $"INSERT INTO Ingredients VALUES ('{ingredient.Name}')",
                connection);
                sqlCommand.ExecuteReader();

                sqlCommand = new SqlCommand(
                $"INSERT INTO Recipes VALUES ('{newDish.Name}', '{ingredient.Name}', '{ingredient.Amount}')",
                connection);
                sqlCommand.ExecuteReader();
            }
        }

        /// <summary>
        /// Find Dish by name.
        /// </summary>
        /// <param name="dishName">A name</param>
        /// <param name="connection">Connection to the restaurant database</param>
        /// <returns>Finded Dish</returns>
        public static Dish GetDishByName(string dishName, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(
                $"SELECT Dishes.Name, Dishes.Price, Dishes.TotalAmount FROM Dishes JOIN Recipes ON Dishes.Name = Dish_name JOIN Ingredients ON Ingredients.Name = Ingredient_name WHERE Dishes.Name = '{dishName}'",
                connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();

            string name = (string)reader.GetValue(0);
            decimal price = (decimal) reader.GetValue(1);
            string amount = (string)reader.GetValue(2);

            return new Dish(name, price, amount, connection);
        }

        /// <summary>
        /// Get all ingredients for current dish.
        /// </summary>
        private void InitIngredients()
        {
            SqlCommand sqlCommand = new SqlCommand(
                $"SELECT Ingredients.Name, Recipes.Amount FROM Dishes JOIN Recipes ON Dishes.Name = Dish_name JOIN Ingredients ON Ingredients.Name = Ingredient_name WHERE Dishes.Name = '{Name}'",
                _sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = (string)reader.GetValue(0);
                string amount = (string)reader.GetValue(1);

                Ingredients.Add(new Ingredient(name, amount));
            }
        }
    }
}
