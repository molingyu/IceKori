using System;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Std.Array
{
    [PageSlider, Serializable]
    public class Include : BaseExpression
    {
        public BaseExpression Array;
        public BaseExpression Value;
        
        public Include(BaseExpression array, BaseExpression value)
        {
            Array = array;
            Value = value;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Array.Reducible) return new Include(Array.Reduce(env), Value);
            if (Array.ID == BaseError.Error)
            {
                return Array;
            }
            if (Value.Reducible) return new Include(Array, Value.Reduce(env));
            if (Value.ID == BaseError.Error)
            {
                return Value;
            }
            if (Array.ID == IceKoriBaseType.Array)
            {
                return new IceKoriBool(((IceKoriArray)Array).Value.Contains((IceKoriBaseType)Value));
            }
            return new TypeError($"Argument of type '{Array}' is not assignable to parameter of type 'IceKoriString'.");
        }

        public override string ToString()
        {
            return $"Array.include({Array}, {Value})";
        }
    }
}