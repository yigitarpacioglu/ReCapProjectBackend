﻿using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;
        private int hour= Values.hour;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Customer>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), CustomerMessages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Customer>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.Id==id), CustomerMessages.CustomersListed); 
        }

        public IResult AddService(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult(CustomerMessages.CustomerAdded);
        }

        public IResult UpdateService(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(CustomerMessages.CustomerUpdated);
        }

        public IResult DeleteService(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(CustomerMessages.CustomerDeleted);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CustomerDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), CustomerMessages.CustomersListed);
        }
    }
}
