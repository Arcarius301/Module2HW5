using System;
using Module2HW5.Services.Abstractions;
using Module2HW5.Models.Enumerations;

namespace Module2HW5.Services
{
    public class ActionsService : IActionsService
    {
        private readonly ILoggerService _loggerService;

        public ActionsService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public bool FirstMethod()
        {
            _loggerService.Log(EventLevel.Info, $"Start method: {nameof(FirstMethod)}");
            return true;
        }

        public bool SecondMethod()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public bool ThirdMethod()
        {
            throw new Exception("I broke a logic");
        }
    }
}
