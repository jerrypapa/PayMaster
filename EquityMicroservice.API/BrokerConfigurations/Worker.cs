
using EasyNetQ.AutoSubscribe;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EquityMicroservice.API.BrokerConfigurations
{
    public class Worker : BackgroundService
    {
        private readonly AutoSubscriber _autoSubscriber;
        public Worker(AutoSubscriber autoSubscriber)
        {
            _autoSubscriber=autoSubscriber;
        }     
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _autoSubscriber
                .SubscribeAsync(new Assembly[] { Assembly
                .GetExecutingAssembly() }, stoppingToken);
        }
    }
}
