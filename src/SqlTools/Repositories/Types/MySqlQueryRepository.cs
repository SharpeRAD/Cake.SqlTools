#region Using Statements
using System.Data;

using MySql.Data.MySqlClient;

using Cake.Core.Diagnostics;
#endregion



namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execture sql queries against a MySql database
    /// </summary>
    public class MySqlQueryRepository : BaseSqlQueryRepository
    {
        #region Constructors (1)
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public MySqlQueryRepository(ICakeLog log)
            : base(log)
        {

        }
        #endregion





        #region Methods (1) 
        /// <summary>
        /// Opens a connection to the database
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        protected override  IDbConnection OpenConnection(string connectionString)
        {
            IDbConnection con = MySqlClientFactory.Instance.CreateConnection();

            con.ConnectionString = connectionString;
            con.Open();

            return con;
        }
        #endregion
    }
}