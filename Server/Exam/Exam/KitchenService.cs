using Exam.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Exam
{
    public class KitchenService : IKitchenService
    {
        /// <summary>
        /// Connection string to database.
        /// Here is have to be 'MultipleActiveResultSets=true' in the connection string.
        /// </summary>
        private const string Connstr = "Data Source=localhost;Initial Catalog=Restaurant;Integrated Security=True; MultipleActiveResultSets=true";

        private readonly SqlConnection _sqlConnection;

        public KitchenService()
        {
            _sqlConnection = new SqlConnection(Connstr);
            _sqlConnection.Open();
        }

        ~KitchenService()
        {
            // TODO: find out why it isn't work.
            //_sqlConnection.Close();
        }

        public void AddDish(Dish newDish)
        {
            Dish.AddDish(newDish, _sqlConnection);
        }

        /// <summary>
        /// Find Dish by name.
        /// </summary>
        /// <param name="name">A name</param>
        /// <returns>Finded Dish</returns>
        public Dish GetDishByName(string name)
        {
            return Dish.GetDishByName(name, _sqlConnection);
        }

        /// <summary>
        /// Get all dishes form database.
        /// </summary>
        /// <returns></returns>
        public List<Dish> GetAllDishes()
        {
            return Dish.GetAllDishes(_sqlConnection);
        }
    }
}
