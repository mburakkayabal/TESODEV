using System;
using TESODEV.BusinessLayer.Abstract;
using TESODEV.BusinessLayer.Concrete;
using TESODEV.DataTransferObject;
using TESODEV.UnitOfWork.Abstract;
using TESODEV.UnitOfWork.Concrete;
using Xunit;

namespace TESODEV.Test
{
    public class CustomerTest
    {
        private readonly IBaseUnitOfWork unitOfWork;
        private readonly ICustomerBl customerBl;

        public CustomerTest()
        {
            unitOfWork = new BaseUnitOfWork();
            customerBl = new CustomerBl(unitOfWork);
        }

        [Theory]
        [InlineData(null)]
        public void CreateTest(CustomerDto model)
        {
            Guid customerId = customerBl.Create(model);
            bool result = Guid.Empty == customerId ? false : true;
            Assert.False(result, "customerId must be different from empty guid");
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

        [Theory]
        [InlineData("")]
        public void GetByIdTest(Guid id)
        {
            CustomerDto customer = customerBl.GetById(id);
            Assert.NotNull(customer);
        }

        [Fact]
        public void ValidationTest()
        {

        }
    }
}
