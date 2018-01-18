using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess.Interface
{
    public interface IImageDAL
    {
        Image GetImage(int id);
        bool UploadImage(Image imageToUpload);
        void UpdateImage(Image imageToUpdate);
    }
}
