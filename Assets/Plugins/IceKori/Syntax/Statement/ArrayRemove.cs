using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class ArrayRemove : BaseStatement
    {
        public BaseExpression Array;
        public BaseExpression Value;
        
        public ArrayRemove()
        {
            Reducible = true;
        }
        
        public ArrayRemove(BaseExpression array, BaseExpression value)
        {
            Reducible = true;
            Array = array;
            Value = value;
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var statement = _Pretreatment(Array, () => new ArrayRemove(Array.Reduce(env), Value), () =>
            {
                return _Pretreatment(Array, () => new ArrayRemove(Array, Value.Reduce(env)), () =>
                {
                    ((IceKoriArray)Array).Value.Remove((IceKoriBaseType)Value);
                    return DoNothing.GetValue;
                });
            });
            return new object[]{ statement, env, errorHandling};
        }

        public override string ToString()
        {
            return $"{Array} >> {Value}";
        }
    }
}