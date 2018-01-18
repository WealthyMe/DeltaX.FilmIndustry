using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess
{
    public class ImageDAL : IImageDAL
    {
        public Image GetImage(int id)
        {
            try
            {
                Image image;
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    image = dbContext.Images.FirstOrDefault(i => i.ImageId == id);
                }
                return image;
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
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    dbContext.Images.Add(imageToUpload);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateImage(Image imageToUpdate)
        {
            try
            {
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    dbContext.Entry(imageToUpdate).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
