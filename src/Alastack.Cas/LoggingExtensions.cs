using Microsoft.Extensions.Logging;

namespace Alastack.Cas;

internal static class LoggingExtensions
{
    private static Action<ILogger, string, string, Exception?> _handleChallenge;

    static LoggingExtensions()
    {
        _handleChallenge = LoggerMessage.Define<string, string>(
            eventId: new EventId(1, "HandleChallenge"),
            logLevel: LogLevel.Debug,
            formatString: "HandleChallenge with Location: {Location}; and Set-Cookie: {Cookie}.");
    }

    public static void HandleChallenge(this ILogger logger, string location, string cookie, Exception? exception = default)
        => _handleChallenge(logger, location, cookie, exception);
}
