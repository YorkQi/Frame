using Frame.Core;

namespace Tests
{
    public class Test1 : IModule, ISingletonInstance
    {
        public string Name { get { return "york"; } }
    }
}
