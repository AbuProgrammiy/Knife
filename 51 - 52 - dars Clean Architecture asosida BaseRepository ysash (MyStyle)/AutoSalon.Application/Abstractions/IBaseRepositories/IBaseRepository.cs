using System.Linq.Expressions;          // Expression |ishlashi uchun

namespace AutoSalon.Application.Abstractions.IBaseRepositories
{
    public interface IBaseRepository<T> where T : class     // IBaseRepositoryni Application Layerda chaqirilishiga sabab, uni Application Layerda chaqirib ishlatiladi
    {
        public string Create(T model);
        public IEnumerable<T> GetAll();
        public T GetByAny(Expression<Func<T, bool>> expression);
        public string Update(T model);
        public string Delete(Expression<Func<T, bool>> expression);     // Expression aynan int tipda id yoki string tipida name kirib kelishini oldini oladi
    }
}
