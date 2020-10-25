using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.DTOs.LiftingStats
{
    public class LiftingStatDetailedDTO
    {
        public IEnumerable<LiftingStatDTO> LiftingStats { get; set; }
        public IEnumerable<LiftFeedDTO> LiftFeed { get; set; }
    }
}
