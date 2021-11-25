using Module2HW5.Models.Enumerations;

namespace Module2HW5.Services.Abstractions
{
    public interface ILoggerService
    {
        void Log(EventLevel eventLevel, string message);
    }
}
