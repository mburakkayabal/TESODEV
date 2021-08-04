using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TESODEV.DataAccessLayer.Abstract;
using TESODEV.Entity;
using TESODEV.Repository.Concrete;

namespace TESODEV.DataAccessLayer.Concrete
{
    public class OrderDal : BaseRepository<Order>, IOrderDal
    {
        public OrderDal(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
