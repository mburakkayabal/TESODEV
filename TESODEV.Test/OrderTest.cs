using System;
using TESODEV.BusinessLayer.Abstract;
using TESODEV.BusinessLayer.Concrete;
using TESODEV.UnitOfWork.Abstract;
using TESODEV.UnitOfWork.Concrete;
using Xunit;

namespace TESODEV.Test
{
    public class OrderTest
    {
        private readonly IBaseUnitOfWork unitOfWork;
        private readonly IOrderBl orderBl;

        public OrderTest()
        {
            unitOfWork = new BaseUnitOfWork();
            orderBl = new OrderBl(unitOfWork);
        }

        [Fact]
        public void CreateTest()
        {

        }

        [Fact]
        public void UpdateTest()
        {

        }

        [Fact]
        public void DeleteTest()
        {

        }

        [Fact]
        public void GetTest()
        {

        }

        [Fact]
        public void GetArrayByIdTest()
        {

        }

        [Fact]
        public void GetByIdTest()
        {

        }

        [Fact]
        public void ChangeStatusTest()
        {

        }
    }
}
