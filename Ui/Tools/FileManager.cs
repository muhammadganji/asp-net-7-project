using Microsoft.AspNetCore.Hosting;

namespace Ui.Tools
{
    public class FileManager
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly static string _rootNormal = "img\\Product\\normalimage\\";
        private readonly static string _rootThubnail = "img\\Product\\thumbnailimage\\";

        public FileManager(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> Upload(IFormFile ImageFile, string FileName)
        {
            try
            {
                string uniqueFileName = string.Empty;
                if (ImageFile != null)
                {
                    var uploads = Path.Combine(_hostEnvironment.WebRootPath, _rootNormal);
                    var uploadsThubnail = Path.Combine(_hostEnvironment.WebRootPath, _rootThubnail);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName + Path.GetExtension(ImageFile.FileName);
                    string filePath = Path.Combine(uploads, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    // upload thumbnail image
                    ImageResizer img = new ImageResizer();
                    img.Resize(uploads + uniqueFileName, uploadsThubnail + uniqueFileName);
                }
                return uniqueFileName ?? "";
            }
            catch
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// Delete image of product
        /// </summary>
        /// <param name="ImageName">file name of image</param>
        /// <returns></returns>
        public bool Delete(string ImageName)
        {
            if (ImageName != null)
            {
                var uploads = Path.Combine(_hostEnvironment.WebRootPath, _rootNormal);
                var uploadsThubnail = Path.Combine(_hostEnvironment.WebRootPath, _rootThubnail);

                string filePath = Path.Combine(uploads, ImageName);
                string filePathThumbnailimage = Path.Combine(uploadsThubnail, ImageName);
                try
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    if (System.IO.File.Exists(filePathThumbnailimage))
                    {
                        System.IO.File.Delete(filePathThumbnailimage);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else { return false; }

        }



    }
}
