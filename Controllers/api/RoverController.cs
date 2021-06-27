using MarsRover.Helpers;
using MarsRover.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarsRover.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private readonly ILogger<RoverController> _logger;
        private readonly SqliteDbContext _dbcontext;

        public RoverController(ILogger<RoverController> logger, SqliteDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: api/<RoverController>
        [HttpGet]
        public ActionResult Get()
        {
            var roverLocation = new RoverLocationModel();
            var rover = new RoverModel();
            rover.RoverLocations.Add(roverLocation);

            return Ok(rover);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RoverModel model)
        {
            var roverOutputList = new List<String>();
            try
            {
                if (ModelState.IsValid)
                {
                    var gridBoundsAry = model.GridBounds.Split(' ');

                    foreach (var roverLocation in model.RoverLocations)
                    {
                        // Send information to Rover as code follows
                        var roverCurrentPosition = roverLocation.RoverBounds.Split(' ');
                        var roverPoint = new Point();
                        roverPoint.North = Convert.ToInt32(roverCurrentPosition[0]);
                        roverPoint.East = Convert.ToInt32(roverCurrentPosition[1]);
                        int roverDegree = Coordinates.GetDegreeFromHeading(roverCurrentPosition[2]);

                        var roverMovement = new Movement();
                        roverMovement.value = roverLocation.RoverMovement;
                        roverMovement.Created = DateTime.UtcNow;
                        char[] movements = roverLocation.RoverMovement.ToCharArray();
                        foreach (var movement in movements)
                        {
                            if (movement.ToString().ToLower() == "m")
                            {
                                roverPoint = Coordinates.GetPointFromMovement(roverPoint, roverDegree);
                            }
                            else
                            {
                                roverDegree = Coordinates.GetNewDegreeFromDirection(roverDegree, movement.ToString());
                            }
                        }
                       
                        if(roverPoint.North > Convert.ToInt32(gridBoundsAry[0]) ||
                           roverPoint.North < 0 ||
                           roverPoint.East > Convert.ToInt32(gridBoundsAry[1]) ||
                           roverPoint.East < 0)
                        {
                            roverOutputList.Add("null" + " " + "null" + " " + Coordinates.GetHeadingFromDegree(roverDegree));
                        } 
                        else
                        {
                            roverOutputList.Add(roverPoint.North + " " + roverPoint.East + " " + Coordinates.GetHeadingFromDegree(roverDegree));
                        }
                    }

                    // Could save to database or send to interface for saving
                }
            }
            catch { 
                // log
            }

            return Ok(new { data = roverOutputList });

        }

    }
}
