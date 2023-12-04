#region Using Statements
using System.Data;
using Cake.Core.Diagnostics;
using MySql.Data.MySqlClient;
#endregion



namespace Cake.SqlTools
{
    /// <summary>
    /// Provides a method to execture sql queries against a MySql database
    /// </summary>
    public class MySqlQueryRepository : BaseSqlQueryRepository
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public MySqlQueryRepository(ICakeLog log)
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
            var con = MySqlClientFactory.Instance.CreateConnection();

            con.ConnectionString = connectionString;
            con.Open();

            return con;
        }
        #endregion
    }
}