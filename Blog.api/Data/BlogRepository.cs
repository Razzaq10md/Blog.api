using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Blog.api.Models;  // Ensure this using directive is correct

namespace Blog.api.Data
{
    public class BlogRepository
    {
        private readonly string _connectionString;

        public BlogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Models.Blog>> GetBlogsAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Id, Title, Content, DateCreated FROM Blogs";
                return await db.QueryAsync<Models.Blog>(sql);
            }
        }
    }
}
