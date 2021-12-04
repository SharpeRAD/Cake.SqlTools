using System.Data;

using Cake.Core.Diagnostics;

using Npgsql;

namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execture sql queries against a PostgresSql database.
    /// </summary>
    public class NpgsqlQueryRepository : BaseSqlQueryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpgsqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public NpgsqlQueryRepository(ICakeLog log)
            : base(log)
        {
        }

        /// <summary>
        /// Opens a connection to the database.
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        /// <returns><see cref="IDbConnection"/> instance.</returns>
        protected override IDbConnection? OpenConnection(string connectionString)
        {
            var con = new NpgsqlConnection(connectionString);
            con.Open();

            return con;
        }
    }
}
