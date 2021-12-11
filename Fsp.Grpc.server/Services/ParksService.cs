using Grpc.Core;

namespace Fsp.Grpc.Api.Services
{
    public class ParksService : Parks.ParksBase
    {
        private readonly ILogger<ParksService> _logger;

        public ParksService(ILogger<ParksService> logger)
        {
            _logger = logger;
        }

        public override Task<ParksResponse> GetParks(ParksRequest request, ServerCallContext context)
        {
            ParksResponse result = new ParksResponse();
            result.MyParks.Add(new Park { Id = 1, Name = "Addison Blockhouse Historic State Park", County = "Volusia", Size = "134.51 acres (54.43 ha)", Year = "1939", Water = "Tomoka River", Remarks = "Ruins of a 19th-century plantation owned by John Addison" });
            result.MyParks.Add(new Park { Id = 2, Name = "South Point", County = "Hillsborough", Size = "6,312 acres (2,556 ha)", Year = "1996", Water = "Alafia River", Remarks = "Former phosphorus strip mine unremediated" });

            return Task.FromResult(result);
        }
    }
}