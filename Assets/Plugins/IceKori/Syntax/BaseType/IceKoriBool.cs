using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriBool : IceKoriBaseType
    {
        public static IceKoriBool GetFalse => GetFalse ?? new IceKoriBool(false);
        public static IceKoriBool GetTrue =>  GetTrue ?? new IceKoriBool(true);

        public bool Value;
        public IceKoriBool()
        {
            ID = 1;
            Reducible = false;
        }

        public IceKoriBool(bool value)
        {
            ID = 1;
            Reducible = false;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public override object Unbox()
        {
            return Value;
        }
    }
}
