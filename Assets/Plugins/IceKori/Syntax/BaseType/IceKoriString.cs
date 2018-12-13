using System;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriString : IceKoriBaseType
    {
        public string Value;
        public IceKoriString()
        {
            ID = 4;
            Reducible = false;
        }

        public IceKoriString(string value)
        {
            ID = 4;
            Reducible = false;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override object Unbox()
        {
            return Value;
        }

        public bool ToBool()
        {
            return Convert.ToBoolean(Value);
        }
    }
}
