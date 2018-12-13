using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    [System.Serializable]
    public class IceKoriTexture : IceKoriObject
    {
        public Texture Value;

        /// <summary>
        /// IceKori 的 Texture 对象。是 UnityEngine.Texture 对象的装箱。
        /// </summary>
        public IceKoriTexture()
        {
            Reducible = false;
        }

        /// <summary>
        /// IceKori 的 Texture 对象。是 UnityEngine.Texture 对象的装箱。
        /// <param name="value">Texture 对象</param>
        /// </summary>
        public IceKoriTexture(Texture value)
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
            return $"<Texture {Value.name}>";
        }
    }
}
