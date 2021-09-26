using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.RentDate == null)
            {
                return new ErrorResult(Messages.RentDateInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessDataResult<Rental>(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessDataResult<Rental>(Messages.RentalDeleted);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessDataResult<Rental>(Messages.RentalUpdated);
        }
    }
}
