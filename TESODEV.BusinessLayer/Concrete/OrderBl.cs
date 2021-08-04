using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TESODEV.BusinessLayer.Abstract;
using TESODEV.DataTransferObject;
using TESODEV.Entity;
using TESODEV.UnitOfWork.Abstract;

namespace TESODEV.BusinessLayer.Concrete
{
    public class OrderBl : IOrderBl
    {
        private IBaseUnitOfWork unitOfWork;

        public OrderBl(IBaseUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool ChangeStatus(Guid id, string status)
        {
            try
            {
                Order entity = unitOfWork.Order.Select(x => x.Id == id && x.Status == status)
                    .Include(x => x.Address)
                    .Include(x => x.Product)
                    .FirstOrDefault();

                if (entity == null) throw new Exception("Order not found!");

                entity.Status = status;
                entity.UpdatedAt = DateTime.Now;

                unitOfWork.Order.Update(entity);

                int result = unitOfWork.SaveChanges();

                if (result != 1) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Guid Create(OrderDto dto)
        {
            try
            {
                Guid orderId = Guid.NewGuid();
                Guid customerId = Guid.NewGuid();

                Order entity = new Order()
                {
                    Id = orderId,
                    CustomerId = customerId,
                    Quantity = dto.Quantity,
                    Price = dto.Price,
                    Status = dto.Status,
                    CreatedAt = dto.CreatedAt,
                    UpdatedAt = dto.UpdatedAt,
                    Address = new Address()
                    {
                        AddressLine = dto.Address.AddressLine,
                        City = dto.Address.City,
                        Country = dto.Address.Country,
                        CityCode = dto.Address.CityCode
                    },
                    Customer = new Customer()
                    {
                        Id = customerId,
                        Name = dto.Customer.Name,
                        Email = dto.Customer.Email,
                        CreatedAt = dto.Customer.CreatedAt,
                        UpdatedAt = dto.Customer.UpdatedAt
                    }
                };

                unitOfWork.Order.Insert(entity);

                int result = unitOfWork.SaveChanges();

                if (result != 1) return Guid.Empty;

                return orderId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                Order entity = unitOfWork.Order.Select(x => x.Id == id)
                    .Include(x => x.Address)
                    .Include(x => x.Product)
                    .FirstOrDefault();

                if (entity == null) throw new Exception("Order not found!");

                unitOfWork.Order.Delete(entity);

                int result = unitOfWork.SaveChanges();

                if (result != 1) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderDto[] Get()
        {
            try
            {
                return unitOfWork.Order.Select()
                    .Select(x => new OrderDto()
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        Status = x.Status,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    })
                    .ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderDto[] GetArrayById(Guid id)
        {
            try
            {
                return unitOfWork.Order.Select(x => x.Id == id)
                    .Select(x => new OrderDto()
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        Status = x.Status,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    })
                    .ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderDto GetById(Guid id)
        {
            try
            {
                return unitOfWork.Order.Select(x => x.Id == id)
                    .Select(x => new OrderDto()
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        Status = x.Status,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    })
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(OrderDto dto)
        {
            try
            {
                Order entity = unitOfWork.Order.Select(x => x.Id == dto.Id)
                    .Include(x => x.Address)
                    .Include(x => x.Product)
                    .FirstOrDefault();

                if (entity == null) throw new Exception("Order not found!");

                entity.Quantity = dto.Quantity;
                entity.Price = dto.Price;
                entity.UpdatedAt = dto.UpdatedAt;

                entity.Address.AddressLine = dto.Address.AddressLine;
                entity.Address.City = dto.Address.City;
                entity.Address.Country = dto.Address.Country;
                entity.Address.CityCode = dto.Address.CityCode;

                unitOfWork.Order.Update(entity);

                int result = unitOfWork.SaveChanges();

                if (result != 1) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int saveChanges()
        {
            try
            {
                return unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
