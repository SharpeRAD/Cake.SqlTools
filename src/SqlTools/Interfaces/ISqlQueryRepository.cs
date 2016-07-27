


namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execture sql queries against a database
    /// </summary>
    public interface ISqlQueryRepository
    {
        #region Methods (1) 
        /// <summary>
        /// Executes a sql query against a database
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        /// <param name="query">The sql query to execute.</param>
        bool Execute(string connectionString, string query);
        #endregion
    }
}