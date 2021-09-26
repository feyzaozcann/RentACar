using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        
        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==7)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetCarsByBrandId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == carId));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }
        public IDataResult<Car> GetCarsByColorId(int carId)
        {
            return new SuccessDataResult<Car> (_carDal.Get(c => c.ColorId == carId));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarIdExists(car.CarId),
                CheckIfCarCountOfBrandCorrect(car.BrandId));
            if (result!=null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
             _carDal.Delete(car);
            return new SuccessResult(Messages.CarsDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarsUpdated);
        }


        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            //Select count(*) from cars where brandId=1
           var result = _carDal.GetAll(c => c.BrandId == c.BrandId).Count;
           if (result >= 15)
           {
              return new ErrorResult(Messages.CarCountofBrandError);
           }
           return new SuccessResult();
        }

         private IResult CheckIfCarIdExists(int carId)
         {
            var result = _carDal.GetAll(c => c.CarId == c.CarId).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarAlreadyExists);
            }
            return new  SuccessResult();
         }





    }
}