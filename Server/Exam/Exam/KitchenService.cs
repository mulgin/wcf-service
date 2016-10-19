using Exam.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            //_sqlConnection.Close();
        }


        public List<Dish> getAllDishes()
        {
            return Dish.getAllDishes(_sqlConnection, CONNSTR);
        }
    }
}
