#region Using Statements
using System.Data;
using System.Data.Common;
#endregion



namespace Cake.SqlTools
{
    internal static class CommandExtensions
    {
		#region Methods
        //Command
        internal static IDbCommand CreateCommand(this IDbConnection connection, CommandType type, string text)
        {
            return connection.CreateCommand(type, text, null);
        }

        internal static IDbCommand CreateCommand(this IDbConnection connection, CommandType type, string text, DbTransaction transaction)
        {
            DbCommand command = (DbCommand)connection.CreateCommand();

            command.CommandText = text;
            command.CommandType = type;

            command.Transaction = transaction;

            return command;
        }

        internal static IDbCommand CreateTextCommand(this IDbConnection connection, string text)
        {
            return connection.CreateCommand(CommandType.Text, text, null);
        }

        internal static IDbCommand CreateTextCommand(this IDbConnection connection, string text, DbTransaction transaction)
        {
            return connection.CreateCommand(CommandType.Text, text, transaction);
        }



        //Timeout
        internal static IDbCommand SetTimeout(this IDbCommand command, int timeout)
        {
            command.CommandTimeout = timeout;

            return command;
        }
        #endregion 
    }
}