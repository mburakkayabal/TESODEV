using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TESODEV.DataAccessLayer.Abstract;
using TESODEV.Entity;
using TESODEV.Repository.Concrete;

namespace TESODEV.DataAccessLayer.Concrete
{
    public class CustomerDal : BaseRepository<Customer>, ICustomerDal
    {
        public CustomerDal(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
