using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Fall2015.Models;

namespace Fall2015.Repositories
{
    public class CompetencyHeaderReposatory
    {
        ApplicationDbContext context =
            new ApplicationDbContext();

        public IQueryable<CompetencyHeader> All
        {
            get { return context.CompetencyHeaders; }
        }

        public IQueryable<CompetencyHeader> AllIncluding(
            params Expression<Func<CompetencyHeader, object>>[] includeProperties)
        {
            IQueryable<CompetencyHeader> query = context.CompetencyHeaders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public CompetencyHeader Find(int id)
        {
            return context.CompetencyHeaders.Find(id);
        }

        public void InsertOrUpdate(CompetencyHeader compedencyHeader)
        {
            if (compedencyHeader.CompetencyHeaderId == 0) //new
            {
                context.CompetencyHeaders.Add(compedencyHeader);
            }
            else //edit
            {
                context.Entry(compedencyHeader).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            CompetencyHeader c = Find(id);
            context.CompetencyHeaders.Remove(c);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
