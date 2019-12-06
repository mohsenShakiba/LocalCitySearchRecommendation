using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using LCSR.Domain.Aggregates.Cities;
using Microsoft.EntityFrameworkCore;

namespace LCSR.Infrastructure.Repositories
{
    public class CityRepository: EntityRepository<City>, ICityRepository
    {
        
        public CityRepository(LCSRContext context) : base(context)
        {
        }

        public Task AddHistoryAsync(CitySearchHistory history)
        {
            _context.CitySearchHistories.Add(history);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CityRecommendation>> RecommendationsAsync(long cityId)
        {
            var sql = $@"
                SELECT TOP 1000
                COUNT(C.Id) Frequency, 
                C.Id, 
                C.Name  
                FROM  dbo.[history] H
                RIGHT JOIN dbo.[cities] C ON H.DestinationCityId = C.Id
                WHERE H.SourceCityId = {cityId} OR H.SourceCityId IS NULL
                GROUP BY C.Id, C.Name
                ORDER BY COUNT(C.Id) DESC
            ";
            await using var conn = _context.Database.GetDbConnection();
            conn.Open();
            var result = await conn.QueryAsync<CityRecommendation>(sql);
            return result;
        }
        
    }
}