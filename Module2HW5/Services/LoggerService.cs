using System;
using Module2HW5.Services.Abstractions;
using Module2HW5.Models.Enumerations;

namespace Module2HW5.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;

        public LoggerService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Log(EventLevel eventLevel, string message)
        {
            string buffer = $"{DateTime.UtcNow}: {eventLevel}: {message}";
            _fileService.WriteLine(buffer);
            Console.WriteLine(buffer);
        }
    }
}
