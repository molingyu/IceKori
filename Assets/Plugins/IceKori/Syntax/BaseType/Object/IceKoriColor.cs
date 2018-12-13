using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    [System.Serializable]
    public class IceKoriColor : IceKoriObject
    {
        /// <summary>
        /// 原始值。
        /// </summary>
        public Color Value;

        /// <summary>
        /// IceKori 的 Color 对象。是 UnityEngine.Color 对象的装箱。
        /// </summary>
        public IceKoriColor()
        {
            Reducible = false;
        }


        /// <summary>
        /// Color 对象。是 UnityEngine.Color 对象的装箱。
        /// <param name="value">Color 对象</param>
        /// </summary>
        public IceKoriColor(Color value)
        {
            Reducible = false;
            Value = value;
        }

        public override object Unbox()
        {
            return Value;
        }

        public override string ToString()
        {
            return $"<Color r:{Value.r}, g:{Value.g}, b:{Value.b}, a:{Value.a}>";
        }
    }
}
