namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    public class IceKoriNull : IceKoriBaseType
    {
        public static IceKoriNull GetNull => new IceKoriNull();

        public IceKoriNull()
        {
            ID = 0;
            Reducible = false;
        }

        public override object Unbox()
        {
            return null;
        }
    }
}
