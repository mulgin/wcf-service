using System.Runtime.Serialization;

namespace Exam.Models
{
    [DataContract]
    public class Ingredient
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Name { get; private set; }

        public Ingredient() { }

        public Ingredient(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
