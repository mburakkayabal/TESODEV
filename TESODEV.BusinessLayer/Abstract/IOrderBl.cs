using System;
using System.Collections.Generic;
using System.Text;
using TESODEV.DataTransferObject;

namespace TESODEV.BusinessLayer.Abstract
{
    public interface IOrderBl
    {
        Guid Create(OrderDto dto);
        bool Update(OrderDto dto);
        bool Delete(Guid id);
        OrderDto[] Get();
        OrderDto[] GetArrayById(Guid id);
        OrderDto GetById(Guid id);
        bool ChangeStatus(Guid id, string status);
    }
}
