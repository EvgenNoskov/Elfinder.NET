using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ElFinder
{
    /// <summary>
    /// Represents a root of file system
    /// </summary>
    public class Root
    {
        #region private
        string _volumeId;
        string _alias;
        DirectoryInfo _directory;
        string _tmbPath;
        string _tmbUrl;
        int _tmbSize;
        
        string _tmbBgColor;
        string _url;
        #endregion private

        #region public

        /// <summary>
        /// Initialize new instanse of class ElFinder.Root
        /// </summary>
        /// <param name="directory">Directory which will be root</param>
        /// <param name="url">Url to root</param>
        public Root(DirectoryInfo directory, string url)
        {
            if (directory == null)
                throw new ArgumentNullException("directory", "Root directory can not be null");
            if (!directory.Exists)
                throw new ArgumentException("Root directory must exist", "directory");
            _alias = directory.Name;
            _directory = directory;
            _tmbPath = ".thumbnails";
            _tmbSize = 48;
            _tmbBgColor = "#ff0000";
            _url = _tmbUrl = url ?? string.Empty;
        }

        /// <summary>
        /// Initialize new instanse of class ElFinder.Root
        /// </summary>
        /// <param name="directory">Directory which will be root</param>
        public Root(DirectoryInfo directory) : this(directory, string.Empty) { }


        public string VolumeId
        {
            get { return _volumeId; }
            internal set { _volumeId = value; }
        }

        /// <summary>
        /// Get or sets root alias
        /// </summary>
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }
        public DirectoryInfo Directory
        {
            get { return _directory; }
        }
        public string Url
        {
            get { return _url; }
        }
        public string TmbUrl
        {
            get { return _tmbUrl; }
            set { _tmbUrl = value; }
        }
        public string TmbPath
        {
            get { return _tmbPath; }
            set { _tmbPath = value; }
        }
        public int TmbSize
        {
            get { return _tmbSize; }
            set { _tmbSize = value; }
        }
        public string TmbBgColor
        {
            get { return _tmbBgColor; }
            set { _tmbBgColor = value; }
        }
        public bool IsReadOnly { get; set; }
       
        #endregion public
    }
}