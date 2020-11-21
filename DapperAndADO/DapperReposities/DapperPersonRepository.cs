using Dapper;
using DapperAndADO.Contracts;
using DapperAndADO.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAndADO.DapperReposities
{
    public class DapperPersonRepository : IPersonRepository
    {
        string _connectionString;
        //you can get this from user in ctor
        public DapperPersonRepository()
        {
            this._connectionString = "Server=.;Database=ADOAndDapper;Trusted_Connection=True;";
        }
        public void DeleteBy(Person state)
        {
            DeleteBy(state.Id);
        }

        public void DeleteBy(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "delete from person where id=@id";
                conn.Execute(command, new { id = id });
            }
        }

        public IEnumerable<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "select * from person";
                persons.AddRange(conn.Query<Person>(command).ToList());
            }
            return persons;

        }

        public Person GetBy(int id)
        {
            Person person = null;
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "select * from person where id = @id";
                person = conn.Query<Person>(command,new { id=id}).FirstOrDefault();
            }
            return person;
        }

        public Person GetBy(string name)
        {
            Person person = null;
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "select * from person where name = @name ";
                person = conn.Query<Person>(command,new {name=name }).FirstOrDefault();
            }
            return person;
        }

        public int Insert(Person state)
        {
            int result = 1;
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "insert into Person values(@name,@familyname,@age) SELECT SCOPE_IDENTITY()";
                result = conn.Query<int>(command, new { name = state.Name, familyname = state.FamilyName, age = state.Age }).First();
            }
            return result;
        }

        public Person Update(Person state)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "update Person " +
                    "set name=@name , familyname= @familyname , age=@age " +
                    "where id =@id";
                conn.Execute(command, new
                {
                    name = state.Name,
                    familyname = state.FamilyName,
                    age = state.Age,
                    id = state.Id
                });

            }
            return state;
        }

    }
}
