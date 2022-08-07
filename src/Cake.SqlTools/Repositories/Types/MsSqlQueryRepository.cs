using System.Data;
using Cake.Core.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execute sql queries against a MsSql database.
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

        /// <summary>
        /// Opens a connection to the database.
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        /// <returns><see cref="IDbConnection"/> implementation.</returns>
        protected override IDbConnection OpenConnection(string connectionString)
        {
            IDbConnection con = SqlClientFactory.Instance.CreateConnection();

            con.ConnectionString = connectionString;
            con.Open();

            return con;
        }
    }
}
