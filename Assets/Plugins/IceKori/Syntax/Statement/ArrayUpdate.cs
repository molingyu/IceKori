using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class ArrayUpdate : BaseStatement
    {
        public BaseExpression Array;
        public int Index;
        public BaseExpression Value;
        
        public ArrayUpdate()
        {
            Reducible = true;
        }
        
        public ArrayUpdate(BaseExpression array, int index, BaseExpression value)
        {
            Reducible = true;
            Array = array;
            Index = index;
            Value = value;
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var statement = _Pretreatment(Array, () => new ArrayUpdate(Array.Reduce(env), Index, Value), () =>
            {
                return _Pretreatment(Array, () => new ArrayUpdate(Array, Index, Value.Reduce(env)), () =>
                {
                    ((IceKoriArray)Array).Value[Index] = (IceKoriBaseType)Value;
                    return DoNothing.GetValue;
                });
            });
            return new object[]{ statement, env, errorHandling};
        }

        public override string ToString()
        {
            return $"{Array}[{Index}] = {Value}";
        }
    }
}