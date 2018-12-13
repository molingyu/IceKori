using System;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriFloat : IceKoriBaseType
    {
        public float Value;
        public IceKoriFloat()
        {
            ID = 3;
            Reducible = false;
        }

        public IceKoriFloat(float value)
        {
            ID = 3;
            Reducible = false;
            Value = value;
        }

        public override object Unbox()
        {
            return Value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public bool ToBool()
        {
            return Convert.ToBoolean(Value);
        }
    }
}
