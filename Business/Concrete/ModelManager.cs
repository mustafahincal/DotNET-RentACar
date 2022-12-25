using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
      public class ModelManager : IModelService
      {
            IModelDal _modelDal;
            public ModelManager(IModelDal modelDal)
            {
                  _modelDal = modelDal;
            }

            public IDataResult<List<Model>> GetAll()
            {
                  return new SuccessDataResult<List<Model>>(_modelDal.GetAll(), "Modeller getirildi");
            }

            public IDataResult<Model> GetById(int modelId)
            {
                  return new SuccessDataResult<Model>(_modelDal.Get(m => m.Id == modelId), "Model getirildi");
            }

            public IResult Add(AddModelDto addModelDto)
            {
                  var modelToAdd = new Model
                  {
                        BrandId = addModelDto.BrandId,
                        Name = addModelDto.Name
                  };
                  _modelDal.Add(modelToAdd);
                  return new SuccessResult("Model eklendi");
            }

            public IResult Delete(Model model)
            {
                  _modelDal.Delete(model);
                  return new SuccessResult("Model silindi");
            }

            public IResult Update(Model model)
            {
                  _modelDal.Update(model);
                  return new SuccessResult("Model güncellendi");
            }

            public IDataResult<List<Model>> GetModelsByBrandId(int id)
            {
                  return new SuccessDataResult<List<Model>>(_modelDal.GetAll(m => m.BrandId == id));
            }
      }
}
