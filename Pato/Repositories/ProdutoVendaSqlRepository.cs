using System.Data.SqlClient;
using Pato.Models;

namespace Pato.Repositories
{
    public class ProdutoVendaSqlRepository : DBContext, IProdutoVendaRepository
    {
        public void Create(ProdutoVenda produtoVenda)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_add_produtoVenda";

                cmd.Parameters.AddWithValue("@idVenda", produtoVenda.IdVenda);
                cmd.Parameters.AddWithValue("@idProduto", produtoVenda.IdProduto);
                cmd.Parameters.AddWithValue("@qtd", produtoVenda.qtd);

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
                cmd.CommandText = @"DELETE FROM ProdutoVenda WHERE IdPv = @id";

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

        public List<ProdutoVenda> Read()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT ProdutoVenda.*, Produto.Nome as Produto FROM ProdutoVenda JOIN Produto ON ProdutoVenda.produtoId = Produto.IdProduto";

                SqlDataReader reader = cmd.ExecuteReader();

                List<ProdutoVenda> lista = new List<ProdutoVenda>();

                while(reader.Read())
                {
                    lista.Add(
                        new ProdutoVenda {
                            IdPv = (int)reader["IdPv"],
                            IdVenda = (int)reader["vendaId"],
                            IdProduto = (int)reader["produtoId"],
                            qtd = (int)reader["qtd"],
                            Produto = (string)reader["Produto"]
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

        public ProdutoVenda Read(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM ProdutoVenda WHERE IdPv = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new ProdutoVenda {
                            IdPv = (int)reader["IdPv"],
                            IdVenda = (int)reader["vendaId"],
                            qtd = (int)reader["qtd"],
                            IdProduto = (int)reader["produtoId"]
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

        public void Update(int id, ProdutoVenda produtoVenda)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_update_produtoVenda";

                cmd.Parameters.AddWithValue("@idVenda", produtoVenda.IdVenda);
                cmd.Parameters.AddWithValue("@idProduto", produtoVenda.IdProduto);
                cmd.Parameters.AddWithValue("@qtd", produtoVenda.qtd);
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
        public List<ProdutoVenda> ReadByVenda(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT ProdutoVenda.*, Produto.Nome as Produto, Produto.Valor FROM ProdutoVenda JOIN Produto ON ProdutoVenda.produtoId = Produto.IdProduto WHERE vendaId = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                List<ProdutoVenda> lista = new List<ProdutoVenda>();

                while(reader.Read())
                {
                    lista.Add(
                        new ProdutoVenda {
                            IdPv = (int)reader["IdPv"],
                            IdVenda = (int)reader["vendaId"],
                            qtd = (int)reader["qtd"],
                            IdProduto = (int)reader["produtoId"],
                            Produto = (string)reader["Produto"],
                            Valor = (decimal)reader["Valor"]
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