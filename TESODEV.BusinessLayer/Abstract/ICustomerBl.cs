using System;
using System.Collections.Generic;
using System.Text;
using TESODEV.DataTransferObject;

namespace TESODEV.BusinessLayer.Abstract
{
    public interface ICustomerBl
    {
        Guid Create(CustomerDto dto);
        bool Update(CustomerDto dto);
        bool Delete(Guid id);
        CustomerDto[] Get();
        CustomerDto GetById(Guid id);
        bool Validate(Guid id);
    }
}
