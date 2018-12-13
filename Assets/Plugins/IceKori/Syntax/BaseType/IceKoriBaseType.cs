using Assets.Plugins.IceKori.Syntax.Expression;
using System;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    public abstract class IceKoriBaseType : BaseExpression
    {
        public static int Null = 0;
        public static int Bool = 1;
        public static int Int = 2;
        public static int Float = 3;
        public static int String = 4;
        public static int Object = 5;

        /// <summary>
        /// 对 IceKori 类型对象拆箱。
        /// </summary>
        /// <returns>返回值为其对应的 c# 原始对象</returns>
        public abstract object Unbox();

        public override BaseExpression Reduce(Enviroment env)
        {
            throw new Exception(ToString());
        }
    }
}
