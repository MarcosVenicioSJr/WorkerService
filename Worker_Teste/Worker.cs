using Microsoft.Extensions.Hosting;

namespace Worker_Teste
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public Worker(
                IHostApplicationLifetime hostApplicationLifetime, ILogger<Worker> logger) =>
                (_hostApplicationLifetime, _logger) = (hostApplicationLifetime, logger);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);

                // Caso queira usar o Stop, descomentar linha abaixo.
                //_hostApplicationLifetime.StopApplication();
            }
        }
    }
}