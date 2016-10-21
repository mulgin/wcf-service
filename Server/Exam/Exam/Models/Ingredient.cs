using System.Runtime.Serialization;

namespace Exam.Models
{
    [DataContract]
    public class Ingredient
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Amount { get; private set; }

        public Ingredient() { }

        public Ingredient(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
