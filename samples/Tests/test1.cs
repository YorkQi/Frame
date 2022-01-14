using Frame.Core;

namespace Tests
{
    public class test1: IModule, ISingletonInstance
    {
        public string Name { get { return "york"; } }
    }
}
