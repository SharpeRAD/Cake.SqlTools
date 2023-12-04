using Cake.Core.Diagnostics;

namespace Cake.SqlTools.Logging
{
    /// <summary>
    /// A logger implementation which does not log. Can be used to prevent null checking all the way.
    /// </summary>
    internal class QuietLog : ICakeLog
    {
        /// <summary>
        /// Provides the method to write logs like defined in the ICakeLog interface but does not log anything.
        /// </summary>
        /// <param name="verbosity">The ignored verbosity of the log message.</param>
        /// <param name="level">The ignored level of the log message</param>
        /// <param name="format">The ignored format string for the log message</param>
        /// <param name="args">The ignored string format arguments for the log message</param>
        /// <remarks>
        /// Can be used as logger to prevent the Cake tool from logging at all.
        /// This way, the caller does not have to check for nulls.
        /// </remarks>
        public void Write(Verbosity verbosity, LogLevel level, string format, params object[] args)
        {
            // log nothing
        }

        /// <summary>
        /// Gets or sets the verbosity of the logger.
        /// </summary>
        public Verbosity Verbosity
        {
            get => Verbosity.Quiet;
            set => throw new NotSupportedException();
        }
    }
}
