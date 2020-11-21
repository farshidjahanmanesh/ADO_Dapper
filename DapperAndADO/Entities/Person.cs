using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAndADO.Entities
{
    public class Person
    {
        public Person()
        {

        }
        public Person(int id,string name,string familyName,DateTime age)
        {
            this.Id = id;
            this.Age = age;
            this.FamilyName = familyName;
            this.Name = name;
        }
        public Person( string name, string familyName, DateTime age)
        {
            this.Age = age;
            this.FamilyName = familyName;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public DateTime Age { get; set; }
    }
}
