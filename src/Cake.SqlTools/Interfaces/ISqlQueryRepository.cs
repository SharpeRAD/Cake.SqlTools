namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execute sql queries against a database.
    /// </summary>
    public interface ISqlQueryRepository
    {
        /// <summary>
        /// Executes a sql query against a database.
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        /// <param name="query">The sql query to execute.</param>
        /// <returns>True if executions succeeded.</returns>
        bool Execute(string connectionString, string query);
    }
}
