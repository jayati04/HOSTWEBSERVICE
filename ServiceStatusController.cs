using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Host_Web_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceStatusController : ControllerBase
    {
        private static ServiceStatus currentStatus = new ServiceStatus();
        private static string lastFetchedData = "";
        private static CancellationTokenSource? cancellationTokenSource;
        private static Task? pollingTask;

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new
            {
                status = currentStatus.Status,
                data = lastFetchedData
            });
        }

        [HttpPost("start")]
        public IActionResult StartService()
        {
            currentStatus.Status = "Started";

            cancellationTokenSource?.Cancel(); // Stop previous if any
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            pollingTask = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    await FetchDataFromWpfApp();
                    await Task.Delay(2000, token); // every 2s
                }
            }, token);

            return Ok(new { message = "Service started successfully!" });
        }

        [HttpPost("stop")]
        public IActionResult StopService()
        {
            currentStatus.Status = "Stopped";

            cancellationTokenSource?.Cancel();
            cancellationTokenSource = null;
            pollingTask = null;

            return Ok(new { message = "Service stopped successfully!" });
        }

        [HttpPost("data")]
        public async Task<IActionResult> ReceiveData([FromBody] DataPayload payload)
        {
            if (currentStatus.Status == "Stopped")
            {
                return BadRequest(new { message = "Service has stopped. Data not accepted." });
            }

            lastFetchedData = payload?.Message ?? "No data";
            return Ok(new { message = "Data received successfully" });
        }


        private async Task FetchDataFromWpfApp()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync("http://localhost:8085/status");
                if (response.IsSuccessStatusCode)
                {
                    lastFetchedData = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    lastFetchedData = "WPF not responding";
                }
            }
            catch
            {
                lastFetchedData = "Error connecting to WPF app";
            }
        }

        public class DataPayload
        {
            public string Message { get; set; }
        }

        public class ServiceStatus
        {
            public string Status { get; set; } = "Stopped";
        }
    }
}
