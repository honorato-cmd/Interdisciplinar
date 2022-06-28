using System.Data.SqlClient;
using Pato.Models;

namespace Pato.Repositories
{
    public class ClienteSqlRepository : DBContext, IClienteRepository
    {
        public void Create(Cliente cliente)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "cliente_add_pessoa";
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@Status", cliente.Status);
                cmd.Parameters.AddWithValue("@Rua", cliente.Rua);
                cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
                cmd.Parameters.AddWithValue("@Uf", cliente.Uf);
                cmd.Parameters.AddWithValue("@Cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

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
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "cliente_delete_pessoa";

                cmd.Parameters.AddWithValue("@pessoaId", id);

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

        public List<Cliente> Read()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vCliente";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Cliente> lista = new List<Cliente>();

                while(reader.Read())
                {
                    lista.Add(
                        new Cliente {
                            Status = (string)reader["Status"],
                            Nome = (string)reader["Nome"],
                            Cpf = (string)reader["Cpf"],
                            IdPessoa = (int)reader["IdPessoa"],
                            Rua = (string)reader["Rua"],
                            Bairro = (string)reader["Bairro"],
                            Cidade = (string)reader["Cidade"],
                            Uf = (string)reader["Uf"],
                            Cep = (string)reader["Cep"],
                            Telefone = (string)reader["Telefone"]
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

        public Cliente Read(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vCliente WHERE IdPessoa = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Cliente {
                        Nome = (string)reader["Nome"],
                        Cpf = (string)reader["Cpf"],
                        Status = (string)reader["Status"],
                        IdPessoa = (int)reader["IdPessoa"],
                        Rua = (string)reader["Rua"],
                        Bairro = (string)reader["Bairro"],
                        Cidade = (string)reader["Cidade"],
                        Uf = (string)reader["Uf"],
                        Cep = (string)reader["Cep"],
                        Telefone = (string)reader["Telefone"]
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

        public void Update(int id, Cliente cliente)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "cliente_update_pessoa";

                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@status", cliente.Status);
                cmd.Parameters.AddWithValue("@pessoaId", id);
                cmd.Parameters.AddWithValue("@rua", cliente.Rua);
                cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                cmd.Parameters.AddWithValue("@uf", cliente.Uf);
                cmd.Parameters.AddWithValue("@cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);

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