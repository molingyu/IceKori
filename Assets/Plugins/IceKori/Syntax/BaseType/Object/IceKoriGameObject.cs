using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    [System.Serializable]
    public class IceKoriGameObject : IceKoriObject
    {

        public GameObject Value;

        public IceKoriGameObject()
        {
            Reducible = false;
        }

        public IceKoriGameObject(GameObject value)
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
            return $"<GameObject {Value.name}>";
        }
    }
}
