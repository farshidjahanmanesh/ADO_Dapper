using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperAndADO.ADOReposities;
using DapperAndADO.Entities;

namespace DapperAndADO
{
    class Program
    {
        static void Main(string[] args)
        {
            ADOPersonRepository repo = new ADOPersonRepository();
            try
            {
                //for insert data 
                Person person = new Person("farshid", "jahanmanesh", new DateTime(1998, 10, 10));
                person.Id=repo.Insert(person);

                // for update 
                person.Name = "faraz";
                repo.Update(person);

                //for removing
                //vol 1
                repo.DeleteBy(1);//delete by id
                //vol 2
                repo.DeleteBy(person);//delete by entity

                //for get a data
                Person personValues = repo.GetBy(1);

                //for get all data
                IEnumerable<Person> persons= repo.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("you get this exception:");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
