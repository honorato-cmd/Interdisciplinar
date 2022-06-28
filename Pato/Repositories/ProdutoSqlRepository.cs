using System.Data.SqlClient;
using Pato.Models;

namespace Pato.Repositories
{
    public class ProdutoSqlRepository : DBContext, IProdutoRepository
    {
        public void Create(Produto produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO Produto 
                    VALUES (@nome, @valor, @estoque, @idFornecedor)";

                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@valor", produto.Valor);
                cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                cmd.Parameters.AddWithValue("@idFornecedor", produto.IdFornecedor);

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
                cmd.CommandText = @"DELETE FROM Produto WHERE IdProduto = @id";

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

        public List<Produto> Read()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vProduto";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Produto> lista = new List<Produto>();

                while(reader.Read())
                {
                    lista.Add(
                        new Produto {
                            IdProduto = (int)reader["IdProduto"],
                            Nome = (string)reader["Nome"],
                            Valor = (decimal)reader["Valor"],
                            Estoque = (int)reader["Estoque"],
                            Fornecedor = (string)reader["Fornecedor"],
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

        public Produto Read(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vProduto WHERE IdProduto = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Produto {
                        IdProduto = (int)reader["IdProduto"],
                        Nome = (string)reader["Nome"],
                        Valor = (decimal)reader["Valor"],
                        Fornecedor = (string)reader["Fornecedor"],
                        IdFornecedor =(int)reader["fornecedorId"],
                        Estoque = (int)reader["Estoque"]
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

        public void Update(int id, Produto produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"UPDATE Produto 
                    SET Nome = @nome, Valor = @valor, Estoque = @estoque, fornecedorId = @idFornecedor
                    WHERE IdProduto = @id";

                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@valor", produto.Valor);
                cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                cmd.Parameters.AddWithValue("@idFornecedor", produto.IdFornecedor);
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
        public List<Produto> ReadByFornecedor(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM vProduto WHERE IdFornecedor = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Produto> lista = new List<Produto>();

                while(reader.Read())
                {
                    lista.Add(
                        new Produto {
                            Nome = (string)reader["Nome"],
                            Valor = (decimal)reader["Valor"],
                            Estoque = (int)reader["Estoque"],
                            Fornecedor = (string)reader["Fornecedor"],
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
    }
}