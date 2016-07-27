


namespace Cake.SqlTools
{
    /// <summary>
    /// The settings to use when executing sql queries
    /// </summary>
    public class SqlQuerySettings
    {
        #region Constructors (1) 
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlQuerySettings" /> class.
        /// </summary>
        public SqlQuerySettings()
        {
            this.Provider = "MsSql";
            this.ConnectionString = "";
        }
		#endregion





		#region Properties (2) 
        /// <summary>
        /// Gets or sets the name of the provider to connect with
        /// </summary>
        public string Provider { get; set; }
        
        /// <summary>
        /// Gets or sets the sql connection string to connect with
        /// </summary>
        public string ConnectionString { get; set; }
		#endregion
    }
}