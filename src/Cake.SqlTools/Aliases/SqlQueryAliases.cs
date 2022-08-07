using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

namespace Cake.SqlTools
{
    /// <summary>
    /// Contains Cake aliases for executing sql queries.
    /// </summary>
    [CakeAliasCategory(nameof(SqlTools))]
    public static class SqlQueryAliases
    {
        /// <summary>
        /// Executes a sql query against a database.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="query">The sql query to execute.</param>
        /// <param name="settings">The <see cref="SqlQuerySettings"/> to use to connect with.</param>
        /// <returns>True if command succeeded.</returns>
        [CakeMethodAlias]
        public static bool ExecuteSqlQuery(this ICakeContext context, string query, SqlQuerySettings settings)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var log = settings.AllowLogs ? context.Log : new Logging.QuietLog();

            ISqlQueryRepository? repository;

            switch (settings.Provider)
            {
                case "MsSql":
                    repository = new MsSqlQueryRepository(log);
                    break;

                case "MySql":
                    repository = new MySqlQueryRepository(log);
                    break;
                case "Npgsql":
                    repository = new NpgsqlQueryRepository(log);
                    break;
                default:
                    log.Error("Unknown sql provider {0}", settings.Provider);
                    return false;
            }

            return repository.Execute(settings.ConnectionString, query);
        }

        /// <summary>
        /// Executes a sql file against a database.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="path">The path to the sql file to execute.</param>
        /// <param name="settings">The <see cref="SqlQuerySettings"/> to use to connect with.</param>
        /// <returns>True if command succeeded.</returns>
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

            var log = settings.AllowLogs ? context.Log : new Logging.QuietLog();

            var file = context.FileSystem.GetFile(path);

            if (file.Exists)
            {
                var query = file.ReadBytes().GetString();

                return context.ExecuteSqlQuery(query, settings);
            }

            log.Error("Missing sql file {0}", path.FullPath);
            return false;
        }
    }
}
