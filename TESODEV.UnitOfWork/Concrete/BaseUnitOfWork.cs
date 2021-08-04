using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TESODEV.DataAccessLayer.Abstract;
using TESODEV.DataAccessLayer.Concrete;
using TESODEV.Entity;
using TESODEV.UnitOfWork.Abstract;

namespace TESODEV.UnitOfWork.Concrete
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private static readonly object locker = new object();

        private static DbContext _dbContext;
        private static DbContext dbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    lock (locker)
                    {
                        if (_dbContext == null) _dbContext = new TESODEVContext();
                    }
                }
                return _dbContext;
            }
        }

        public ICustomerDal Customer => new CustomerDal(dbContext);

        public IOrderDal Order => new OrderDal(dbContext);

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
