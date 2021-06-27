using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarsRover.Models
{
    public class RoverModel
    {

        public string GridBounds { get; set; }

        public List<RoverLocationModel> RoverLocations { get; set; }

        public RoverModel()
        {
            RoverLocations = new List<RoverLocationModel>();
        }
    }

    public class RoverLocationModel
    {
        public string RoverBounds { get; set; }

        public string RoverMovement { get; set; }
    }
}
