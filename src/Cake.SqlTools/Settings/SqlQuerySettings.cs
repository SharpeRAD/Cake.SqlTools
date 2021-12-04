namespace Cake.SqlTools
{
    /// <summary>
    /// The settings to use when executing sql queries.
    /// </summary>
    public class SqlQuerySettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlQuerySettings" /> class.
        /// </summary>
        public SqlQuerySettings()
        {
            Provider = "MsSql";
            ConnectionString = string.Empty;
            AllowLogs = true;
        }

        /// <summary>
        /// Gets or sets the name of the provider to connect with.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the sql connection string to connect with.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether logs can be written or not.
        /// </summary>
        public bool AllowLogs { get; set; }
    }
}
