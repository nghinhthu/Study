using LiveSport.Data;
using LiveSport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveSport.Services
{
    public class FootballService : IFootballService
    {
        private readonly FootballDbContext _context;
        public FootballService(FootballDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchViewModel>> GetMatchesAsync()
        {
            var query = from m in _context.Matches
                        join t1 in _context.Teams on m.Team1 equals t1.Id
                        join t2 in _context.Teams on m.Team2 equals t2.Id
                        select new MatchViewModel()
                        {
                            Id = m.Id,
                            Team1Id = t1.Id,
                            Team2Id = t2.Id,
                            Team1Name = t1.Name,
                            Team2Name = t2.Name,
                            Team1Logo = t1.Logo,
                            Team2Logo = t2.Logo,
                            Team1Goals = m.Team1Goals ?? 0,
                            Team2Goals = m.Team2Goals ?? 0
                        };
            return await query.ToListAsync();
        }

        public async Task UpdateMatchAsync(MatchUpdateModel model)
        {
            var match = _context.Matches.FirstOrDefault(x => x.Id == model.MatchId);
            if (match != null)
            {
                if (model.TeamId == match.Team1)
                {
                    match.Team1Goals = (match.Team1Goals ?? 0) + 1;
                }
                if (model.TeamId == match.Team2)
                {
                    match.Team2Goals = (match.Team2Goals ?? 0) + 1;
                }

                _context.Matches.Update(match);
                await _context.SaveChangesAsync();
            }
        }
    }
}
