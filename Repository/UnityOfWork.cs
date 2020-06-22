
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Transactions;

namespace RepositoryLayer
{


    public class UnityOfWork : IDisposable
    {
        private DbContext _context;
        /// <summary>
        /// List of properties for each type that will be logged by the application
        /// </summary>
       // private Dictionary<Type, List<LogProperty>> AuditInfo { get; set; }

        /// <summary>
        /// List of types that will be logged by the application
        /// </summary>
        //private List<LogType> TypesToLog { get; set; }
        public UnityOfWork(DbContext context)
        {
            _context = context;
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IEfRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IEfRepository<T>;
            }
            IEfRepository<T> repo = new EfRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        
        public void SaveChanges()
        {

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                List<string> errorMessages = new List<string>();
                foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
                {
                    string entityName = validationResult.Entry.Entity.GetType().Name;
                    foreach (DbValidationError error in validationResult.ValidationErrors)
                    {
                        errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
                    }
                }
            }

        }


        /// <summary>
        ///	We are useing reflection to figure out what fields we need to worry about
        ///   We are caching the results of the reflection so that we only need to do this
        ///   one time per entity type
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

