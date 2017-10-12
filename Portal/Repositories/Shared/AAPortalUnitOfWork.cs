using AtomicArcade.DataModels;
using AtomicArcade.Repositories;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.Repositories
{
    public class AAPortalUnitOfWork : IAAPortalUnitOfWork
    {
        private readonly AADbContext _aaDbContext;
        public AAPortalUnitOfWork() : this(new AADbContext()) { }

        public AAPortalUnitOfWork(AADbContext context)
        {
            _aaDbContext = context;
        }

        public T GetRepository<T>() where T : class
        {
            using (var kernel = new StandardKernel())
            {
                //inspired by https://www.danylkoweb.com/Blog/a-better-entity-framework-unit-of-work-pattern-DD
                kernel.Load(Assembly.GetExecutingAssembly());
                var result = kernel.Get<T>(new ConstructorArgument("context", _aaDbContext));
                if (result != null && result.GetType().GetInterfaces().Contains(typeof(IBaseRepository)))
                {
                    return result;
                }
            }
            // Optional: return an error instead of a null?
            return null;
        }

        protected void Dispose()
        {
            if (_aaDbContext != null)
            {
                _aaDbContext.Dispose();
            }
        }
    }
}
