using System.IO;

namespace ElFinder
{
    /// <summary>
    /// Represents pictures editor for generate thumbnails
    /// </summary>
    public interface IPicturesEditor
    {        
        /// <summary>
        /// If pictures editor can process file
        /// </summary>
        /// <param name="fileExtension">The extension of file</param>
        /// <returns><c>True</c> if can process. otherwise <c>false</c></returns>
        bool CanProcessFile(string fileExtension);        

        /// <summary>
        /// Generate thumbnail of image
        /// </summary>
        /// <param name="input">Input stream of image</param>
        /// <param name="size">Size in pixels of output thumbnail. Thumbnail is square.</param>
        /// <param name="saveAspectRatio"><c>True</c> if aspect ratio of output thumbnail
        /// must be equal aspect ration of input image.</param>
        /// <returns>Generated thumbnail</returns>
        Thumbnail GetThumbnail(Stream input, int size, bool saveAspectRatio);

        /// <summary>
        /// Convert extension of file to browser's compatible images (png, jpg or gif)
        /// </summary>
        /// <param name="originalImageExtension">Extension of original file</param>
        /// <returns>Browser's compatible extension</returns>
        string ConvertThumbnailExtension(string originalImageExtension);
    }
}
