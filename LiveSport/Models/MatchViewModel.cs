using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveSport.Models
{
    public class MatchViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }

        public int Team1Id { get; set; }
        public int Team2Id { get; set; }

        public string Team1Name { get; set; }
        public string Team2Name { get; set; }

        public string Team1Logo { get; set; }
        public string Team2Logo { get; set; }

        public int? Team1Goals { get; set; }
        public int? Team2Goals { get; set; }
    }
}
