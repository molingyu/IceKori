using System;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Std.Math
{
    [PageSlider, Serializable]
    public class Abs : BaseExpression
    {
        public BaseExpression Value;

        public Abs(BaseExpression value)
        {
            Value = value;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Value.Reducible) return new Floor(Value.Reduce(env));
            if (Value.ID == BaseError.Error)
            {
                return Value;
            }

            if (Value.ID == IceKoriBaseType.Float)
            {
                return new IceKoriFloat(Mathf.Abs(((IceKoriFloat)Value).Value));
            }
            if (Value.ID == IceKoriBaseType.Int)
            {
                return new IceKoriInt(Mathf.Abs(((IceKoriInt)Value).Value));
            }
            return new TypeError($"Argument of type '{Value}' is not assignable to parameter of type 'IceKoriFloat || IceKoriInt'.");
        }

        public override string ToString()
        {
            return $"Math.abs({Value})";
        }
    }
}
