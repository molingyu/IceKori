using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    [System.Serializable]
    public class IceKoriSprite : IceKoriObject
    {
        /// <summary>
        /// 原始值。
        /// </summary>
        public Sprite Value;

        /// <summary>
        /// IceKori 的 Sprite 对象。是 UnityEngine.Sprite 对象的装箱。
        /// </summary>
        public IceKoriSprite()
        {
            Reducible = false;
        }

        /// <summary>
        /// IceKori 的 Sprite 对象。是 UnityEngine.Sprite 对象的装箱。
        /// <param name="value">Sprite 对象</param>
        /// </summary>
        public IceKoriSprite(Sprite value)
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
            return $"<sprite {Value.name}>";
        }
    }
}
