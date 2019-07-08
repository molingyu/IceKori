using System;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Std.Math
{
    [PageSlider, Serializable]
    public class Floor : BaseExpression
    {
        public BaseExpression Value;

        public Floor(BaseExpression value)
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
                return new IceKoriInt((int)Mathf.Floor(((IceKoriFloat)Value).Value));
            }
            return new TypeError($"Argument of type '{Value}' is not assignable to parameter of type 'IceKoriFloat'.");
        }

        public override string ToString()
        {
            return $"Math.floor({Value})";
        }
    }
}
