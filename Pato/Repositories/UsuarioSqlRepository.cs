using System.Data.SqlClient;
using Pato.Models;

namespace Pato.Repositories
{
    public class UsuarioSqlRepository : DBContext, IUsuarioRepository
    {
        public void Create(Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "usuario_add_pessoa";
                cmd.Parameters.AddWithValue("@Login", usuario.Login);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                cmd.Parameters.AddWithValue("@Rua", usuario.Rua);
                cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", usuario.Cidade);
                cmd.Parameters.AddWithValue("@Uf", usuario.Uf);
                cmd.Parameters.AddWithValue("@Cep", usuario.Cep);
                cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                

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
                cmd.CommandText = "usuario_delete_pessoa";

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

        public List<Usuario> Read()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vUsuario";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Usuario> lista = new List<Usuario>();

                while(reader.Read())
                {
                    lista.Add(
                        new Usuario {
                            Login = (string)reader["Login"],
                            Senha = (string)reader["Senha"],
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

        public Usuario Read(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vUsuario WHERE IdPessoa = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Usuario {
                        Login = (string)reader["Login"],
                        Senha = (string)reader["Senha"],
                        Nome = (string)reader["Nome"],
                        Cpf = (string)reader["Cpf"],
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

        public void Update(int id, Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "usuario_update_pessoa";
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@cpf", usuario.Cpf);
                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@pessoaId", id);
                cmd.Parameters.AddWithValue("@rua", usuario.Rua);
                cmd.Parameters.AddWithValue("@bairro", usuario.Bairro);
                cmd.Parameters.AddWithValue("@cidade", usuario.Cidade);
                cmd.Parameters.AddWithValue("@uf", usuario.Uf);
                cmd.Parameters.AddWithValue("@cep", usuario.Cep);
                cmd.Parameters.AddWithValue("@telefone", usuario.Telefone);
                

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }
        public Usuario Read(string Login, string Senha)
        {
            try
            {                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vUsuario WHERE Login = @login and Senha = @senha";

                cmd.Parameters.AddWithValue("@login", Login);
                cmd.Parameters.AddWithValue("@senha", Senha);

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    return new Usuario {
                        IdPessoa = (int)reader["IdPessoa"],
                        Nome = (string)reader["Nome"],
                        Login = (string)reader["Login"],
                        Senha = (string)reader["Senha"]
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