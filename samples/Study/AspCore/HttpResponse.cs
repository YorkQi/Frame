using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace AspCore
{
    public class HttpResponse
    {
        public int StatusCode { get; set; }
        public NameValueCollection Headers { get; }
        public Stream Body { get; }
    }
}
