using System.Data.SqlClient;
using Pato.Models;

namespace Pato.Repositories
{
    public class LoginSqlRepository : DBContext, ILoginRepository
    {
        public Login Read(Login login)
        {
            try
            {                
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Usuario WHERE Login = @Login and Senha = @Senha";

                cmd.Parameters.AddWithValue("@Login", login.Login);
                cmd.Parameters.AddWithValue("@Senha", login.Senha);

                Console.WriteLine("login1");
                Console.WriteLine(login.Login);
                Console.WriteLine(login.Senha);
                SqlDataReader reader = cmd.ExecuteReader();
                
                
                if(reader.Read())
                {
                    return new Login {
                        IdPessoa = (int)reader["IdPessoa"],
                        Login = (string)reader["Login"],
                        Senha = (string)reader["Senha"],
                        Nome = (string)reader["Nome"]
                    };                    
                }
                 

                return null;
            }
            catch(Exception ex) 
            {
                // Logar os erros (Sentry, App Insights, etc)...
                return null;
            }
            finally
            {
                Dispose();
            }            
        }
    }
}