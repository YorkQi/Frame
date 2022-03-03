using System.Collections.Specialized;
using System.IO;

namespace AspCore
{
    public class HttpResponse
    {
        public int StatusCode { get; set; }
        public NameValueCollection Headers { get; }
        public Stream Body { get; }
    }
}
