using Application;
using Frame.Core;

namespace Tests
{
    public class WebModule : AutoModule,IModule
    {
        public override void Load()
        {
            _Imps.Add(typeof(WebModule));
            _Imps.Add(typeof(ApplicationModule));
        }
    }
}
