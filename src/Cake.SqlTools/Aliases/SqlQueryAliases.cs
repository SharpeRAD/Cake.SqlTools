#region Using Statements
using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
#endregion



namespace Cake.SqlTools
{
    /// <summary>
    /// Contains Cake aliases for executing sql queries
    /// </summary>
    [CakeAliasCategory("SqlTools")]
    public static class SqlQueryAliases
    {
        #region Methods
        /// <summary>
        /// Executes a sql query against a database
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="query">The sql query to execute.</param>
        /// <param name="settings">The <see cref="SqlQuerySettings"/> to use to connect with.</param>
        [CakeMethodAlias]
        public static bool ExecuteSqlQuery(this ICakeContext context, string query, SqlQuerySettings settings)
        {
            if (String.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query));
            }
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            ICakeLog log = settings.AllowLogs ? context.Log : new Logging.QuietLog();

            ISqlQueryRepository repository = null;

            switch (settings.Provider)
            {
                case "MsSql":
                    Initializer.InitializeNativeSearchPath();
                    repository = new MsSqlQueryRepository(log);
                    break;

                case "MySql":
                    repository = new MySqlQueryRepository(log);
                    break;

                case "Npgsql":
                    repository = new NpgsqlQueryRepository(log);
                    break;
            }



            if (repository != null)
            {
                return repository.Execute(settings.ConnectionString, query);
            }
            else
            {
                log.Error("Unknown sql provider {0}", settings.Provider);
                return false;
            }
        }



        /// <summary>
        /// Executes a sql file against a database
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="path">The path to the sql file to execute.</param>
        /// <param name="settings">The <see cref="SqlQuerySettings"/> to use to connect with.</param>
        [CakeMethodAlias]
        public static bool ExecuteSqlFile(this ICakeContext context, FilePath path, SqlQuerySettings settings)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            ICakeLog log = settings.AllowLogs ? context.Log : new Logging.QuietLog();

            IFile file = context.FileSystem.GetFile(path);

            if (file.Exists)
            {
                string query = file.ReadBytes().GetString();

                return context.ExecuteSqlQuery(query, settings);
            }
            else
            {
                log.Error("Missing sql file {0}", path.FullPath);
                return false;
            }
        }
        #endregion
    }
}