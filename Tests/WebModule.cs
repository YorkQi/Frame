using Application;
using Frame.Core;

namespace Tests
{
    public class WebModule : AutoModule,IModule
    {
        public override void Load()
        {
            _Modules.Add(typeof(WebModule));
            _Modules.Add(typeof(ApplicationModule));
        }
    }
}
