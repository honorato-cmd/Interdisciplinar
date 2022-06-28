using System.Data.SqlClient;
using Pato.Models;

namespace Pato.Repositories
{
    public class FornecedorSqlRepository : DBContext, IFornecedorRepository
    {
        public void Create(Fornecedor fornecedor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_add_fornecedor";

                cmd.Parameters.AddWithValue("@razaoSocial", fornecedor.razaoSocial);
                cmd.Parameters.AddWithValue("@nomeFantasia", fornecedor.nomeFantasia);
                cmd.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                cmd.Parameters.AddWithValue("@inscricaoEstadual", fornecedor.inscricaoEstadual);
                cmd.Parameters.AddWithValue("@atributo", fornecedor.Atributo);
                cmd.Parameters.AddWithValue("@rua", fornecedor.Rua);
                cmd.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                cmd.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                cmd.Parameters.AddWithValue("@uf", fornecedor.Uf);
                cmd.Parameters.AddWithValue("@cep", fornecedor.Cep);
                cmd.Parameters.AddWithValue("@telefone", fornecedor.Telefone);

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
                cmd.CommandText = "sp_delete_fornecedor";

                cmd.Parameters.AddWithValue("@fornecedorId", id);

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

        public List<Fornecedor> Read()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vFornecedor";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Fornecedor> lista = new List<Fornecedor>();

                while(reader.Read())
                {
                    lista.Add(
                        new Fornecedor {
                            IdFornecedor = (int)reader["IdFornecedor"],
                            razaoSocial = (string)reader["razaoSocial"],
                            nomeFantasia = (string)reader["nomeFantasia"],
                            Cnpj = (string)reader["Cnpj"],
                            inscricaoEstadual = (string)reader["inscricaoEstadual"],
                            Atributo = (string)reader["Atributo"],
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

        public Fornecedor Read(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vFornecedor WHERE IdFornecedor = @fornecedorId";

                cmd.Parameters.AddWithValue("@fornecedorId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Fornecedor {
                        IdFornecedor = (int)reader["IdFornecedor"],
                        razaoSocial = (string)reader["razaoSocial"],
                        nomeFantasia = (string)reader["nomeFantasia"],
                        Cnpj = (string)reader["Cnpj"],
                        inscricaoEstadual = (string)reader["inscricaoEstadual"],
                        Atributo = (string)reader["Atributo"],
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

        public void Update(int id, Fornecedor fornecedor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_update_fornecedor";

                cmd.Parameters.AddWithValue("@razaoSocial", fornecedor.razaoSocial);
                cmd.Parameters.AddWithValue("@nomeFantasia", fornecedor.nomeFantasia);
                cmd.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                cmd.Parameters.AddWithValue("@inscricaoEstadual", fornecedor.inscricaoEstadual);
                cmd.Parameters.AddWithValue("@atributo", fornecedor.Atributo);
                cmd.Parameters.AddWithValue("@rua", fornecedor.Rua);
                cmd.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                cmd.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                cmd.Parameters.AddWithValue("@uf", fornecedor.Uf);
                cmd.Parameters.AddWithValue("@cep", fornecedor.Cep);
                cmd.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                cmd.Parameters.AddWithValue("@fornecedorId", id);

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