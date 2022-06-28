using System.Data.SqlClient;
using Pato.Models;

namespace Pato.Repositories
{
    public class PessoaSqlRepository : DBContext, IPessoaRepository
    {
        public void Create(Pessoa pessoa)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO Pessoa 
                    VALUES (@nome, @cpf)";

                cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                // Logar os erros (Sentry, App Insights, etc)...
            }
            finally
            {
                Dispose();
            }
        }

        public void Delete(int id)
        {
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"DELETE FROM Pessoa WHERE IdPessoa = @id";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                // Logar os erros (Sentry, App Insights, etc)...
            }
            finally
            {
                Dispose();
            }
        }

        public List<Pessoa> Read()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Pessoa";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Pessoa> lista = new List<Pessoa>();

                while(reader.Read())
                {
                    lista.Add(
                        new Pessoa {
                            IdPessoa = (int)reader["IdPessoa"],
                            Nome = (string)reader["Nome"],
                            Cpf = (string)reader["Cpf"]
                        }
                    );
                }

                return lista;
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

        public Pessoa Read(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Pessoa WHERE IdPessoa = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Pessoa {
                        IdPessoa = (int)reader["IdPessoa"],
                        Nome = (string)reader["Nome"],
                        Cpf = (string)reader["Cpf"]
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

        public void Update(int id, Pessoa pessoa)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"UPDATE Pessoa 
                    SET Nome = @nome, Cpf = @cpf
                    WHERE IdPessoa = @id";

                cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                // Logar os erros (Sentry, App Insights, etc)...
            }
            finally
            {
                Dispose();
            }
        }
    }
}