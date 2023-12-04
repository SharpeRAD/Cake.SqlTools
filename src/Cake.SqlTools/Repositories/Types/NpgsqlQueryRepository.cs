using System.Data;
using Cake.Core.Diagnostics;
using Npgsql;

namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execute sql queries against a PostgresSql database
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

        /// <inheritdoc/>
        protected override IDbConnection? OpenConnection(string connectionString)
        {
            var connection = new NpgsqlConnection(connectionString);

            connection.Open();

            return connection;
        }
    }
}
