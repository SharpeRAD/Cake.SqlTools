using System.Data;
using Cake.Core.Diagnostics;
using MySql.Data.MySqlClient;

namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execute sql queries against a MySql database
    /// </summary>
    public class MySqlQueryRepository : BaseSqlQueryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public MySqlQueryRepository(ICakeLog log)
            : base(log)
        {

        }

        /// <inheritdoc/>
        protected override IDbConnection? OpenConnection(string connectionString)
        {
            var connection = MySqlClientFactory.Instance.CreateConnection();

            if (connection is not null)
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }

            return connection;
        }
    }
}
