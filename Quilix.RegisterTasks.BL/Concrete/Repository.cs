using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Quilix.RegisterTasks.BL.Concrete
{
    public interface GetAllRep<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
    }
    public abstract class Repository<TEntity, TKey>
where TEntity : class
    {
        protected string StringConnection { get; } = ConfigurationManager.ConnectionStrings["ContextRegisterTasks"].ConnectionString;
        public abstract TEntity GetById(TKey id);

        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TKey id);
    }
}
