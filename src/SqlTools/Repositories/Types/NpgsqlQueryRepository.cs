using Npgsql;
using System.Data;
using Cake.Core.Diagnostics;

namespace Cake.SqlTools
{
    public class NpgsqlQueryRepository : BaseSqlQueryRepository
    {
        #region Constructors (1)
        /// <summary>
        /// Initializes a new instance of the <see cref="NpgsqlQueryRepository" /> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public NpgsqlQueryRepository(ICakeLog log)
            : base(log)
        {

        }
        #endregion





        #region Methods (1) 
        /// <summary>
        /// Opens a connection to the database
        /// </summary>
        /// <param name="connectionString">The connectionString to connect with.</param>
        protected override IDbConnection OpenConnection(string connectionString)
        {
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();

            return con;
        }
        #endregion
    }
}
