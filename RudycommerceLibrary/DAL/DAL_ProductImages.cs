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
    public static class DAL_ProductImages
    {
        private static Account myAccount = new Account (
                "dhgcdhtlx",
                "874148858628711",
                "N7fTdEIRuW_vflagtsRJnAttx6A");

        public static string uploadImage(ProductImage img)
        {
            Cloudinary cloudinary = new Cloudinary(myAccount);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(img.fileLocation),
                PublicId = $"ID{img.ProductID}Ord{img.Order}",
                Overwrite = true,
                Folder = $"Products/{img.ProductID.ToString()}"
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            string url = uploadResult.Uri.ToString();

            return url;
        }
    }
}
