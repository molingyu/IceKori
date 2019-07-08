using System;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Std.String
{
    [PageSlider, Serializable]
    public class Match : BaseExpression
    {
        public BaseExpression Value;
        public string Exp;

        public Match(BaseExpression value, string exp)
        {
            Value = value;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Value.Reducible) return new Match(Value.Reduce(env), Exp);
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