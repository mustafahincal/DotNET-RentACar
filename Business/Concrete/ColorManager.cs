﻿using Business.Abstract;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal) {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll() {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), "Renkler getirildi");
        }

        public IDataResult<Color> GetById(int colorId) {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId),"Renkler getirildi");
        }

        public IResult Add(Color color) {
            _colorDal.Add(color);
            return new SuccessResult("Renk eklendi");
        }

        public IResult Delete(Color color) {
            _colorDal.Delete(color);
            return new SuccessResult("Renk silindi");
        }

        public IResult Update(Color color) {
            _colorDal.Update(color);
            return new SuccessResult( "Renk güncellendi");
        }
    }
}
