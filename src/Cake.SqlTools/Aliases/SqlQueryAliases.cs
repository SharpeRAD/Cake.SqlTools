#region Using Statements
using System;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;
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
                throw new ArgumentNullException("query");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }



            ISqlQueryRepository repository = null;

            switch (settings.Provider)
            {
                case "MsSql":
                    repository = new MsSqlQueryRepository(context.Log);
                    break;

                case "MySql":
                    repository = new MySqlQueryRepository(context.Log);
                    break;

                case "Npgsql":
                    repository = new NpgsqlQueryRepository(context.Log);
                    break;
            }



            if (repository != null)
            {
                return repository.Execute(settings.ConnectionString, query);
            }
            else
            {
                context.Log.Error("Unknown sql provider {0}", settings.Provider);
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
                throw new ArgumentNullException("path");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }



            IFile file = context.FileSystem.GetFile(path);

            if (file.Exists)
            {
                string query = file.ReadBytes().GetString();

                return context.ExecuteSqlQuery(query, settings);
            }
            else
            {
                context.Log.Error("Missing sql file {0}", path.FullPath);
                return false;
            }
        }
        #endregion
    }
}