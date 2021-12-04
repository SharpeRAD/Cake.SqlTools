using System;
using System.Data;

using Cake.Core.Diagnostics;

namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execute sql queries against a database.
    /// </summary>
    public abstract class BaseSqlQueryRepository : ISqlQueryRepository
    {
        private readonly ICakeLog _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        protected BaseSqlQueryRepository(ICakeLog log)
        {
            _logger = log;
        }

        /// <summary>
        /// Executes a sql query against a database.
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        /// <param name="query">The sql query to execute.</param>
        /// <returns>True if command execution was successful.</returns>
        public bool Execute(string connectionString, string query)
        {
            try
            {
                using var conn = OpenConnection(connectionString);
                if (conn is null)
                {
                    throw new ConnectionNullException();
                }

                // Call Command
                using var cmd = conn.CreateTextCommand(query);
                cmd.SetTimeout(0)
                    .ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Error
                _logger.Error(e.Message);
                throw;
            }

            _logger.Information("Sql query executed successfully.");
            return true;
        }

        /// <summary>
        /// Opens a connection to the database.
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        /// <returns><see cref="IDbConnection"/> instance or null.</returns>
        protected virtual IDbConnection? OpenConnection(string connectionString)
        {
            return null;
        }
    }
}
