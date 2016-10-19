using Exam.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace Exam
{
    [ServiceContract]
    public interface IKitchenService
    {
        [OperationContract]
        List<Dish> getAllDishes();

        
    }
}
