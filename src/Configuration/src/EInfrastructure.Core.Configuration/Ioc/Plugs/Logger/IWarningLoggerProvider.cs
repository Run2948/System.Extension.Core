﻿namespace EInfrastructure.Core.Configuration.Ioc.Plugs.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWarningLoggerProvider
    {
        /// <summary>Formats and writes a warning log message.</summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logger.LogWarning(exception, "Error while processing request from {Address}", address)</example>
        void LogWarning(System.Exception exception, string message, params object[] args);

        /// <summary>Formats and writes a warning log message.</summary>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logger.LogWarning("Processing request from {Address}", address)</example>
        void LogWarning(string message, params object[] args);
    }
}