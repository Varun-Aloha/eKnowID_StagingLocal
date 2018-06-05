using System;

namespace eknowID.Repositories
{
    public class BaseRepository : IDisposable
    {
        #region Private Member
        public readonly eknowIDContext _dbContext;
        public bool _disposed = false;
        #endregion

        #region Constructor
        public BaseRepository()
        {
            _dbContext = new eknowIDContext();

            _dbContext.Configuration.LazyLoadingEnabled = true;
        }
        #endregion

        #region IDisposable Implementation
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
