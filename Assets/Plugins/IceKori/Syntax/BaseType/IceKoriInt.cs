using System;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriInt : IceKoriBaseType
    {
        public int Value;
        public IceKoriInt()
        {
            ID = 2;
            Reducible = false;
        }

        public IceKoriInt(int value)
        {
            ID = 2;
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
