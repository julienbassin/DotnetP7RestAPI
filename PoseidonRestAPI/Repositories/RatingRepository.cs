using Microsoft.EntityFrameworkCore;
using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(LocalDbContext context) : base(context) { }

        public void Update(int Id, Rating entity)
        {
            var updatedRating = _context.Ratings.Find(Id);
            if (updatedRating != null && entity != null)
            {
                updatedRating.MoodysRating = entity.MoodysRating;
                updatedRating.SandPRating = entity.SandPRating;
                updatedRating.FitchRating = entity.FitchRating;
                updatedRating.OrderNumber = entity.OrderNumber;
                _context.Ratings.Update(entity);
                _context.SaveChanges();
            }
        }
    }
}
