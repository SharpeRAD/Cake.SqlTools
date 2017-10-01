#region Using Statements
using System;
using System.Data;

using Cake.Core.Diagnostics;
#endregion



namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execture sql queries against a database
    /// </summary>
    public abstract class BaseSqlQueryRepository : ISqlQueryRepository
    {
        #region Fields
        private ICakeLog _Logger;
        #endregion





        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public BaseSqlQueryRepository(ICakeLog log)
        {
            _Logger = log;
        }
        #endregion





        #region Methods
        /// <summary>
        /// Opens a connection to the database
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        protected virtual IDbConnection OpenConnection(string connectionString)
        {
            return null;
        }



        /// <summary>
        /// Executes a sql query against a database
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        /// <param name="query">The sql query to execute.</param>
        public bool Execute(string connectionString, string query)
        {
            try
            {
                using (IDbConnection conn = this.OpenConnection(connectionString))
                {
                    //Call Command
                    conn.CreateTextCommand(query)
                        .SetTimeout(0)
                        .ExecuteNonQuery();

                    _Logger.Information("Sql query executed successfully.");

                    return true;
                }
            }
            catch (Exception e)
            {
                //Error
                _Logger.Error(e.Message);
                return false;
            }
        }
        #endregion
    }
}