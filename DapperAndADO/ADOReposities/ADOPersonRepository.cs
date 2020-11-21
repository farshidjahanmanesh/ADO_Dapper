using DapperAndADO.Contracts;
using DapperAndADO.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAndADO.ADOReposities
{
    public class ADOPersonRepository : IPersonRepository
    {
        string _connectionString;
        //you can get this from user in ctor
        public ADOPersonRepository()
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
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                sqlCommand.Parameters.AddWithValue("@id", id);
                conn.Open();
                sqlCommand.ExecuteNonQuery();

            }
        }

        public IEnumerable<Person> GetAll()
        {
            IList<Person> persons = new List<Person>();
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "select * from person";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                conn.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    persons.Add(
                    new Person((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (DateTime)dataReader[3]));
                }
            }
            return persons;

        }

        public Person GetBy(int id)
        {
            Person person = null;
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "select * from person where id = @id";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                sqlCommand.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    person = new Person((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (DateTime)dataReader[3]);
                }
            }
            return person;
        }

        public Person GetBy(string name)
        {
            Person person = null;
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "select * from person where name = @name ";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                sqlCommand.Parameters.AddWithValue("@name", name);
                conn.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    person = new Person((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (DateTime)dataReader[3]);
                }
            }
            return person;
        }

        public int Insert(Person state)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                string command = "insert into Person values(@name,@familyname,@age) SELECT SCOPE_IDENTITY()";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                sqlCommand.Parameters.AddWithValue("@name", state.Name);
                sqlCommand.Parameters.AddWithValue("@familyname", state.FamilyName);
                sqlCommand.Parameters.AddWithValue("@age", state.Age);
                conn.Open();
                result = (int)(decimal) sqlCommand.ExecuteScalar();
                
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
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                sqlCommand.Parameters.AddWithValue("@name", state.Name);
                sqlCommand.Parameters.AddWithValue("@familyname", state.FamilyName);
                sqlCommand.Parameters.AddWithValue("@age", state.Age);
                sqlCommand.Parameters.AddWithValue("@id", state.Id);
                conn.Open();
                sqlCommand.ExecuteNonQuery();

            }
            return state;
        }

    }
}
