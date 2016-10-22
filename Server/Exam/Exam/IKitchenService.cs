﻿using Exam.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace Exam
{
    [ServiceContract]
    public interface IKitchenService
    {
        [OperationContract]
        List<Dish> GetAllDishes();

        [OperationContract]
        void AddDish(Dish newDish);

        [OperationContract]
        Dish GetDishByName(string name);
    }
}
