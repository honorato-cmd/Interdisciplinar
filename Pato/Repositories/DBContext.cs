using System.Data.SqlClient;

namespace Pato.Repositories
{
    public abstract class DBContext
    {
        private readonly string strConn = @"Data Source=localhost\sqlexpress;
        Initial Catalog=Pato;
        Integrated Security=True;";
         // User Id=sa; Password=F4tecSQL!

         protected SqlConnection connection;

         public DBContext()
         {
             connection = new SqlConnection(strConn);
             connection.Open();
         }

         public void Dispose()
         {
             connection.Close();
         }
    }
}