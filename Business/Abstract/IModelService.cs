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
      public interface IModelService
      {

            IDataResult<List<Model>> GetAll();
            IDataResult<Model> GetById(int modelId);
            IResult Add(AddModelDto addModelDto);
            IResult Delete(Model model);
            IResult Update(Model model);
            IDataResult<List<Model>> GetModelsByBrandId(int id);
      }
}
