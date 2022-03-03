using System;
using System.Collections.Specialized;
using System.IO;

namespace AspCore
{
    public class HttpRequest
    {
        public Uri Url { get; set; }
        public NameValueCollection Headers { get; set; }

        public Stream Body { get; set; }
    }
}
