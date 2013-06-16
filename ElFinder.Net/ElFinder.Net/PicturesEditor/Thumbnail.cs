using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ElFinder
{
    public class Thumbnail
    {
        public string Mime { get; private set; }
        public Stream ImageStream { get; private set; }
        public Thumbnail(string mime, Stream stream)
        {
            Mime = mime;
            ImageStream = stream;
        }
    }
}
