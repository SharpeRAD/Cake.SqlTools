using System.Data;
using Cake.Core.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execute sql queries against a MsSql database
    /// </summary>
    public class MsSqlQueryRepository : BaseSqlQueryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MsSqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public MsSqlQueryRepository(ICakeLog log)
            : base(log)
        {

        }

        /// <inheritdoc />
        protected override IDbConnection? OpenConnection(string connectionString)
        {
            var connection = SqlClientFactory.Instance.CreateConnection();

            if (connection is not null)
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }

            return connection;
        }
    }
}
