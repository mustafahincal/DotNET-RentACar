using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
      public interface ICarService
      {
            IDataResult<List<Car>> GetAll();
            IDataResult<List<Car>> GetCarsByBrandId(int id);
            IDataResult<List<Car>> GetCarsByColorId(int id);
            IDataResult<Car> GetById(int carId);
            IResult Add(AddCarDto addCarDto);
            IResult Delete(DeleteCarDto deleteCarDto);
            IResult Update(Car car);
            IDataResult<List<CarDetailDto>> GetCarDetails();
            IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId);
            IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId);
            IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);
      }
}
