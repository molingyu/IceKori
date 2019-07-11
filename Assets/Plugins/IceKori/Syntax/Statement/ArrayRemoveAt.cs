using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class ArrayRemoveAt : BaseStatement
    {
        public BaseExpression Array;
        public int Index;
        
        public ArrayRemoveAt()
        {
            Reducible = true;
        }
        
        public ArrayRemoveAt(BaseExpression array, int index)
        {
            Reducible = true;
            Array = array;
            Index = index;
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var statement = _Pretreatment(Array, () => new ArrayRemoveAt(Array.Reduce(env), Index), () =>
            {
                ((IceKoriArray)Array).Value.RemoveAt(Index);
                return DoNothing.GetValue;
            });
            return new object[]{ statement, env, errorHandling};
        }

        public override string ToString()
        {
            return $"{Array} >>@ {Index})";
        }
    }
}