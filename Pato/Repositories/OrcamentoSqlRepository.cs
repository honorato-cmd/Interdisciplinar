using System.Data.SqlClient;
using Pato.Models;

namespace Pato.Repositories
{
    public class OrcamentoSqlRepository : DBContext, IOrcamentoRepository
    {
        public void Create(Orcamento orcamento)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO Orcamento
                    VALUES (@clienteId, @data, @valorLiquido, @valorBruto, @desconto)";
                cmd.Parameters.AddWithValue("@clienteId", orcamento.IdPessoa);
                cmd.Parameters.AddWithValue("@data", orcamento.Data);
                cmd.Parameters.AddWithValue("@valorLiquido", orcamento.valorLiquido);
                cmd.Parameters.AddWithValue("@valorBruto", orcamento.valorBruto);
                cmd.Parameters.AddWithValue("@desconto", orcamento.Desconto);

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
                cmd.CommandText = @"DELETE FROM Orcamento WHERE IdOrcamento = @id";

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

        public List<Orcamento> Read()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Orcamento JOIN Pessoa ON Orcamento.clienteId = Pessoa.IdPessoa";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Orcamento> lista = new List<Orcamento>();

                while(reader.Read())
                {
                    lista.Add(
                        new Orcamento {
                            IdOrcamento = (int)reader["IdOrcamento"],
                            IdPessoa = (int)reader["clienteId"],
                            Cliente = (string)reader["Nome"],
                            Data = (DateTime)reader["Data"],
                            valorLiquido = (decimal)reader["valorLiquido"],
                            valorBruto = (decimal)reader["valorBruto"],
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

        public Orcamento Read(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT Orcamento.*, Produto.Nome as Produto, Produto.Valor, ProdutoOrcamento.produtoId, ProdutoOrcamento.qtd, Pessoa.* FROM Orcamento JOIN ProdutoOrcamento ON ProdutoOrcamento.orcamentoId = Orcamento.IdOrcamento JOIN Produto ON Produto.IdProduto = ProdutoOrcamento.produtoId JOIN Pessoa ON Orcamento.clienteId = Pessoa.IdPessoa WHERE IdOrcamento = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Orcamento {
                            IdOrcamento = (int)reader["IdOrcamento"],
                            Data = (DateTime)reader["Data"],
                            IdPessoa = (int)reader["clienteId"],
                            Cliente = (string)reader["Nome"],
                            valorLiquido = (decimal)reader["valorLiquido"],
                            valorBruto = (decimal)reader["valorBruto"],
                            Desconto = (decimal)reader["Desconto"],
                            Produto = (string)reader["Produto"],
                            ValorUnit = (decimal)reader["Valor"],
                            qtd = (int)reader["qtd"]
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

        public void Update(int id, Orcamento orcamento)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"UPDATE Orcamento 
                    SET clienteId = @idPessoa, Data = @data, valorLiquido = @valorLiquido, valorBruto = @valorBruto, Desconto = @desconto
                    WHERE IdOrcamento = @id";

                cmd.Parameters.AddWithValue("@idPessoa", orcamento.IdPessoa);
                cmd.Parameters.AddWithValue("@data", orcamento.Data);
                cmd.Parameters.AddWithValue("@valorLiquido", orcamento.valorLiquido);
                cmd.Parameters.AddWithValue("@valorBruto", orcamento.valorBruto);
                cmd.Parameters.AddWithValue("@desconto", orcamento.Desconto);
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
        public List<Orcamento> ReadByCliente(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Orcamento WHERE clienteId = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Orcamento> lista = new List<Orcamento>();

                while(reader.Read())
                {
                    lista.Add(
                        new Orcamento {
                            IdPessoa = (int)reader["clienteId"],
                            Data = (DateTime)reader["Data"],
                            valorLiquido = (decimal)reader["valorLiquido"],
                            valorBruto = (decimal)reader["valorBruto"],
                            Desconto = (decimal)reader["Desconto"],
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