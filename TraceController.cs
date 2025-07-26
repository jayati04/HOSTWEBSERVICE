using Microsoft.AspNetCore.Mvc;

public class TraceController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitTrace(string traceId, string sampleTime, string totalSamples, string groupSize, string svids)
    {
        // You can access form values here and process them.
        // For demo, let's just pass them back to a confirmation view or do your logic.

        ViewData["Message"] = $"Received Trace ID: {traceId}, Sample Time: {sampleTime}, Total Samples: {totalSamples}, Group Size: {groupSize}, SVIDs: {svids}";
        return View("Index"); // or redirect or show a confirmation page
    }
}
