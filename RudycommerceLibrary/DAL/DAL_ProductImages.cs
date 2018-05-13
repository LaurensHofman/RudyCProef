using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using RudycommerceLibrary.Entities.ProductsAndCategories;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_Images
    {
        private static Account myAccount = new Account (
                "dhgcdhtlx",
                "874148858628711",
                "N7fTdEIRuW_vflagtsRJnAttx6A");

        public static string uploadProductImage(ProductImage img)
        {
            Cloudinary cloudinary = new Cloudinary(myAccount);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(img.FileLocation),
                PublicId = $"ID{img.ProductID}Ord{img.Order}",
                Overwrite = true,
                Folder = $"Products/{img.ProductID.ToString()}"
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            string url = uploadResult.Uri.ToString();

            return url;
        }

        public static string uploadFlagIcon(Entities.Language lang)
        {
            Cloudinary cloudinary = new Cloudinary(myAccount);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(lang.LocalFlagIconPath),
                PublicId = $"{lang.LanguageID}{lang.EnglishName}_flag",
                Overwrite = true,
                Folder = $"LanguageIcon/"
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            string url = uploadResult.Uri.ToString();

            return url;
        }
    }
}
