using Grpc.Core;

namespace Fsp.Grpc.Api.Services
{
    public class ParksService : Visitor.VisitorBase
    {
        private readonly ILogger<ParksService> _logger;

        public ParksService(ILogger<ParksService> logger)
        {
            _logger = logger;
        }

        public override Task<ParksResponse> GetParks(ParksRequest request, ServerCallContext context)
        {
            ParksResponse result = new ParksResponse();
            result.Parks.Add(new Park { Id = 1, Name = "Addison Blockhouse Historic State Park", County = "Volusia", Size = "134.51 acres (54.43 ha)", Year = "1939", Water = "Tomoka River", Remarks = "Ruins of a 19th-century plantation owned by John Addison" });
            result.Parks.Add(new Park { Id = 2, Name = "Alafia River State Park", County = "Hillsborough", Size = "6,312 acres (2,556 ha)", Year = "1996", Water = "Alafia River", Remarks = "Former phosphorus strip mine unremediated" });
            result.Parks.Add(new Park { Id = 3, Name = "Alfred B. Maclay Gardens State Park", County = "Leon", Size = "1,180 acres (478 ha)", Year = "1954", Water = "Lake Hall", Remarks = "Originally named Killearn Gardens State Park" });
            result.Parks.Add(new Park { Id = 4, Name = "Allen David Broussard Catfish Creek Preserve State Park", County ="Polk", Size = "8,065 acres (3,266 ha)", Year ="1991", Water ="unnamed ponds", Remarks = "Home to rare scrub habitat for wildlife" });
            result.Parks.Add(new Park { Id = 5, Name = "Amelia Island State Park", County ="Nassau", Size = "230 acres (93 ha)", Year ="1983", Water ="Nassau Sound Atlantic Ocean", Remarks = "Horseback riding is permitted on the beach" });
            result.Parks.Add(new Park { Id = 6, Name = "Anastasia State Park", County ="St. Johns", Size ="1,600 acres (648 ha)", Year ="1949", Water = "Atlantic Ocean", Remarks = "Hurricane Dora connected Anastasia Island and Conch Island in 1964" });
            result.Parks.Add(new Park { Id = 7, Name = "Anclote Key Preserve State Park", County ="Pasco", Size = "403 acres (163 ha)", Year = "1997", Water = "Gulf of Mexico", Remarks = "Accessible only by ferry or boat" });
            result.Parks.Add(new Park { Id = 8, Name = "Avalon State Park", County = "St. Lucie", Size = "650 acres (263 ha)", Year = "1987", Water = "Atlantic Ocean", Remarks = "Used for frogman training during World War II" });
            return Task.FromResult(result);
        }
    }
}