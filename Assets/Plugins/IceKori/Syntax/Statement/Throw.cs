using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.Error;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class Throw : BaseStatement
    {
        public BaseError Error;

        public Throw()
        {
            Reducible = true;
        }

        public Throw(BaseError error)
        {
            Reducible = true;
            Error = error;
        }

        public override string ToString()
        {
            return $"throw({Error})";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            return new object[]{ errorHandling.ThrowError(Error, env), env, errorHandling };
        }
    }
}
