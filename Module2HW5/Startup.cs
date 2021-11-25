using System;
using Module2HW5.Models.Enumerations;
using Module2HW5.Services.Abstractions;

namespace Module2HW5
{
    public class Startup
    {
        private readonly ILoggerService _loggerService;
        private readonly IActionsService _actionsService;

        public Startup(ILoggerService loggerService, IActionsService actionsService)
        {
            _loggerService = loggerService;
            _actionsService = actionsService;
        }

        public void Run()
        {
            var random = new Random();

            for (var i = 1; i <= 100; i++)
            {
                try
                {
                    switch (random.Next(1, 4))
                    {
                        case 1:
                            _actionsService.FirstMethod();
                            break;
                        case 2:
                            _actionsService.SecondMethod();
                            break;
                        case 3:
                            _actionsService.ThirdMethod();
                            break;
                    }
                }
                catch (BusinessException e)
                {
                    _loggerService.Log(EventLevel.Warning, $"Action got this custom Exception: {e.Message}");
                }
                catch (Exception e)
                {
                    _loggerService.Log(EventLevel.Error, $"Action failed by reason: {e}");
                }
            }
        }
    }
}
