using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
      public class CarImageManager : ICarImageService
      {
            ICarImageDal _carImageDal;
            IFileHelper _fileHelper;

            public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
            {
                  _carImageDal = carImageDal;
                  _fileHelper = fileHelper;
            }

            public IResult Add(IFormFile file, CarImage carImage, int carId)
            {
                  IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
                  if (result != null)
                  {
                        return result;
                  }
                  carImage.ImagePath = _fileHelper.Upload(file, FilePath.ImagesPath);
                  carImage.Date = DateTime.Now;
                  carImage.CarId = carId;
                  _carImageDal.Add(carImage);
                  return new SuccessResult(Messages.ItemAdded);
            }

            public IResult Delete(CarImage carImage)
            {
                  _fileHelper.Delete(FilePath.ImagesPath + carImage.ImagePath);
                  _carImageDal.Delete(carImage);
                  return new SuccessResult();
            }

            public IDataResult<List<CarImage>> GetAll()
            {
                  return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), "Araba resimleri getirildi");
            }

            public IDataResult<List<CarImage>> GetByCarId(int carId)
            {
                  var result = BusinessRules.Run(CheckCarImage(carId));
                  if (result != null)
                  {
                        return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
                  }
                  return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            }

            public IDataResult<CarImage> GetByImageId(int imageId)
            {
                  return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
            }

            public IResult Update(IFormFile file, CarImage carImage)
            {
                  carImage.ImagePath = _fileHelper.Update(file, FilePath.ImagesPath + carImage.ImagePath, FilePath.ImagesPath);
                  _carImageDal.Update(carImage);
                  return new SuccessResult();
            }

            private IResult CheckIfCarImageLimit(int carId)
            {
                  var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
                  if (result >= 5)
                  {
                        return new ErrorResult();
                  }
                  return new SuccessResult();
            }

            private IDataResult<List<CarImage>> GetDefaultImage(int carId)
            {

                  List<CarImage> carImage = new List<CarImage>();
                  carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
                  return new SuccessDataResult<List<CarImage>>(carImage);
            }

            private IResult CheckCarImage(int carId)
            {
                  var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
                  if (result > 0)
                  {
                        return new SuccessResult();
                  }
                  return new ErrorResult();
            }
      }
}
