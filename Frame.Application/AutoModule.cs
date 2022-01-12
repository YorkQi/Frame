using System;
using System.Collections.Generic;

namespace Frame.Core
{
    public abstract class AutoModule
    {
        /// <summary>
        /// 需要注入的类库模组
        /// </summary>
        public static IList<Type> _Imps { get; set; } = new List<Type>() { };

        /// <summary>
        /// 注入方法
        /// </summary>
        public abstract void Load();

    }
}
