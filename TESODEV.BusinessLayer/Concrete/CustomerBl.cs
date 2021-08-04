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
    public class CustomerBl : ICustomerBl
    {
        private IBaseUnitOfWork unitOfWork;

        public CustomerBl(IBaseUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Guid Create(CustomerDto dto)
        {
            try
            {
                Guid customerId = Guid.NewGuid();

                Customer entity = new Customer()
                {
                    Id = customerId,
                    Name = dto.Name,
                    Email = dto.Email,
                    CreatedAt = dto.CreatedAt,
                    UpdatedAt = dto.UpdatedAt,
                    Address = new Address()
                    {
                        AddressLine = dto.Address.AddressLine,
                        City = dto.Address.City,
                        Country = dto.Address.Country,
                        CityCode = dto.Address.CityCode
                    }
                };

                unitOfWork.Customer.Insert(entity);

                int result = unitOfWork.SaveChanges();

                if (result != 1) return Guid.Empty;

                return customerId;
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
                Customer entity = unitOfWork.Customer.Select(x => x.Id == id)
                    .Include(x => x.Address)
                    .FirstOrDefault();

                if (entity == null) throw new Exception("Customer not found!");

                unitOfWork.Customer.Delete(entity);

                int result = unitOfWork.SaveChanges();

                if (result != 1) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomerDto[] Get()
        {
            try
            {
                return unitOfWork.Customer.Select()
                    .Select(x => new CustomerDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
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

        public CustomerDto GetById(Guid id)
        {
            try
            {
                return unitOfWork.Customer.Select(x => x.Id == id)
                    .Select(x => new CustomerDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
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

        public bool Update(CustomerDto dto)
        {
            try
            {
                Customer entity = unitOfWork.Customer.Select(x => x.Id == dto.Id)
                    .Include(x => x.Address)
                    .FirstOrDefault();

                if (entity == null) throw new Exception("Customer not found!");

                entity.Name = dto.Name;
                entity.Email = dto.Email;
                entity.UpdatedAt = dto.UpdatedAt;

                entity.Address.AddressLine = dto.Address.AddressLine;
                entity.Address.City = dto.Address.City;
                entity.Address.Country = dto.Address.Country;
                entity.Address.CityCode = dto.Address.CityCode;

                unitOfWork.Customer.Update(entity);

                int result = unitOfWork.SaveChanges();

                if (result != 1) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Validate(Guid id)
        {
            try
            {
                Customer entity = unitOfWork.Customer.Select(x => x.Id == id)
                    .Include(x => x.Address)
                    .FirstOrDefault();

                if (entity == null) return false;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
