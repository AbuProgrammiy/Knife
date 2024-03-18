using AutoSalon.Application.Abstractions.IBaseRepositories;     // IBaseRepository |ishalshi uchun
using AutoSalon.Infrastructure.Persistance;                     // AutoSalonDbContext |ishalshi uchun
using Microsoft.EntityFrameworkCore;                            // DbSet |ishlashu uchun
using System.Linq.Expressions;                                  // Expression |ishlashi uchun

namespace AutoSalon.Infrastructure.BaseRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AutoSalonDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AutoSalonDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public string Create(T model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
            return "Create amalga oshdi!";
        }

        public string Delete(Expression<Func<T, bool>> expression)
        {
            T model=_dbSet.FirstOrDefault(expression)!;
            if (model == null)
                return "O'chirish uchun m'alumot topilmadi";
            _dbSet.Remove(model);
            _context.SaveChanges();
            return "Ma'lumot o'chirildi!";
        }

        public IEnumerable<T> GetAll()
        { 
            return _dbSet.ToList();
        }

        public T GetByAny(Expression<Func<T, bool>> expression)
        {
            T model = _dbSet.FirstOrDefault(expression)!;
            if (model == null)
                throw new Exception("Ma'lumot topilmadi!");
            return model;
        }

        public string Update(T model)
        {
            _dbSet.Update(model);
            _context.SaveChanges();
            return "Update amalga oshdi";
        }
    }
}
