using DeltaX.FilmIndustry.BusinessLogic.Interface;
using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.BusinessLogic
{
    public class ImageBAL : IImageBAL
    {
        private readonly IImageDAL _imageDAL;

        public ImageBAL(IImageDAL imageDAL)
        {
            this._imageDAL = imageDAL;
        }

        public Image GetImage(int id)
        {
            try
            {
                return this._imageDAL.GetImage(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UploadImage(Image imageToUpload)
        {
            try
            {
                if (imageToUpload.ImageId != 0)
                {
                    Image image = this.GetImage(imageToUpload.ImageId);
                    image.ImageData = imageToUpload.ImageData;
                    this._imageDAL.UpdateImage(image);
                }
                else
                {
                    this._imageDAL.UploadImage(imageToUpload);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
