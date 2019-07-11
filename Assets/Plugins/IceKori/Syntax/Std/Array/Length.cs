using System;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Std.Array
{
    [PageSlider, Serializable]
    public class Length : BaseExpression
    {
        public BaseExpression Array;
        
        public Length(BaseExpression array)
        {
            Array = array;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Array.Reducible) return new Length(Array.Reduce(env));
            if (Array.ID == BaseError.Error)
            {
                return Array;
            }

            if (Array.ID == IceKoriBaseType.Array)
            {
                return new IceKoriInt(((IceKoriArray)Array).Value.Count);
            }
            return new TypeError($"Argument of type '{Array}' is not assignable to parameter of type 'IceKoriString'.");
        }

        public override string ToString()
        {
            return $"Array.length({Array})";
        }
    }
}