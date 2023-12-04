using System.Data;
using System.Data.Common;

namespace Cake.SqlTools
{
    internal static class CommandExtensions
    {
        internal static IDbCommand CreateCommand(this IDbConnection connection, CommandType type, string text)
        {
            return connection.CreateCommand(type, text, transaction: null);
        }

        internal static IDbCommand CreateCommand(this IDbConnection connection, CommandType type, string text, DbTransaction? transaction)
        {
            var command = (DbCommand)connection.CreateCommand();

            command.CommandText = text;
            command.CommandType = type;

            if (transaction is not null)
                command.Transaction = transaction;

            return command;
        }

        internal static IDbCommand CreateTextCommand(this IDbConnection connection, string text)
        {
            return connection.CreateCommand(CommandType.Text, text, transaction: null);
        }

        internal static IDbCommand CreateTextCommand(this IDbConnection connection, string text, DbTransaction transaction)
        {
            return connection.CreateCommand(CommandType.Text, text, transaction);
        }

        internal static IDbCommand SetTimeout(this IDbCommand command, int timeout)
        {
            command.CommandTimeout = timeout;

            return command;
        }
    }
}
