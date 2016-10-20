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
        /// </summary>
        private const string CONNSTR = "Data Source=server2;Initial Catalog=Restaurant;User ID=sa;Password=ghbvf";

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
