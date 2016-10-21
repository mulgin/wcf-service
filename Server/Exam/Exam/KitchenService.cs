using Exam.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Exam
{
    public class KitchenService : IKitchenService
    {
        /// <summary>
        /// Connection string to database.
        /// Here is have to be 'MultipleActiveResultSets=true' in the connection string.
        /// </summary>
        private const string CONNSTR = "Data Source=localhost;Initial Catalog=Restaurant;Integrated Security=True; MultipleActiveResultSets=true";

        private SqlConnection _sqlConnection;

        public KitchenService()
        {
            _sqlConnection = new SqlConnection(CONNSTR);
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

        public List<Dish> GetAllDishes()
        {
            return Dish.getAllDishes(_sqlConnection, CONNSTR);
        }
    }
}
