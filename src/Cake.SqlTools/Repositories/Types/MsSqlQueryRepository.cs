#region Using Statements

using System.Data;
using Cake.Core.Diagnostics;
using Microsoft.Data.SqlClient;
#endregion



namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execture sql queries against a MsSql database
    /// </summary>
    public class MsSqlQueryRepository : BaseSqlQueryRepository
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MsSqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public MsSqlQueryRepository(ICakeLog log)
            : base(log)
        {

        }
        #endregion





        #region Methods
        /// <summary>
        /// Opens a connection to the database
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        protected override IDbConnection OpenConnection(string connectionString)
        {
            var con = SqlClientFactory.Instance.CreateConnection();

            con.ConnectionString = connectionString;
            con.Open();

            return con;
        }
        #endregion
    }
}