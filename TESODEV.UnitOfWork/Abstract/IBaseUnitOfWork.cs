using System;
using System.Collections.Generic;
using System.Text;
using TESODEV.DataAccessLayer.Abstract;

namespace TESODEV.UnitOfWork.Abstract
{
    public interface IBaseUnitOfWork
    {
        public ICustomerDal Customer { get; }
        public IOrderDal Order { get; }
        public int SaveChanges();
    }
}
