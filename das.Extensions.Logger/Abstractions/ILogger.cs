namespace das.Extensions.Logger.Abstractions
{
    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);

        void InfoIf(bool condition, string message);
        void WarnIf(bool condition, string message);
        void DebugIf(bool condition, string message);
        void ErrorIf(bool condition, string message);

        ILogScope BeginScope(string scope);
    }
}