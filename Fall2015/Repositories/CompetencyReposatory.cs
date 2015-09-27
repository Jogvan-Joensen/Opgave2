using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Fall2015.Models;

namespace Fall2015.Repositories
{
    public class CompedencyReposatory
    {
        ApplicationDbContext context =
            new ApplicationDbContext();

        public IQueryable<Competency> All
        {
            get { return context.Competency; }
        }

        public IQueryable<Competency> AllIncluding(
            params Expression<Func<Competency, object>>[] includeProperties)
        {
            IQueryable<Competency> query = context.Competency;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Competency Find(int id)
        {
            return context.Competency.Find(id);
        }

        public void InsertOrUpdate(Competency competency)
        {
            if (competency.CompetencyHeaderId == 0) //new
            {
                context.Competency.Add(competency);
            }
            else //edit
            {
                context.Entry(competency).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Competency c = Find(id);
            context.Competency.Remove(c);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}