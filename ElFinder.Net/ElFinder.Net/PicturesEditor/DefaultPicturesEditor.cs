using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ElFinder
{
    /// <summary>
    /// Represents default pictures editor
    /// </summary>
    internal class DefaultPicturesEditor : IPicturesEditor
    {
        public Thumbnail GetThumbnail(Stream input, int size, bool aspectRatio)
        {
            Image inputImage = Image.FromStream(input);
            int width;
            int height;
            if (aspectRatio)
            {
                double originalWidth = inputImage.Width;
                double originalHeight = inputImage.Height;
                double percentWidth = originalWidth != 0 ? size / originalWidth : 0;
                double percentHeight = originalHeight != 0 ? size / originalHeight : 0;
                double percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                width = (int)(originalWidth * percent);
                height = (int)(originalHeight * percent);
            }
            else
            {
                width = size;
                height = size;
            }            
            Bitmap newImage = new Bitmap(inputImage, width, height);
            MemoryStream output = new MemoryStream();
            string mime;
            if (inputImage.RawFormat.Guid == ImageFormat.Jpeg.Guid)
            {
                newImage.Save(output, ImageFormat.Jpeg);
                mime = "image/jpeg";
            }
            else if (inputImage.RawFormat.Guid == ImageFormat.Gif.Guid)
            {
                newImage.Save(output, ImageFormat.Gif);
                mime = "image/gif";
            }
            else
            {
                newImage.Save(output, ImageFormat.Png);
                mime = "image/png";
            }
            output.Position = 0;
            return new Thumbnail(mime, output);             
        }

        public bool CanProcessFile(string fileExtension)
        {
            string ext = fileExtension.ToLower();
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".tiff";
        }

        public string ConvertThumbnailExtension(string originalImageExtension)
        {
            string ext = originalImageExtension.ToLower();
            if (ext == ".tiff")
                return ".png";
            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
                return ext;
            else
                throw new ArgumentException(typeof(DefaultPicturesEditor).FullName + " not support thumbnails for '" + originalImageExtension + "' file extension");
        }
       
    }
}
