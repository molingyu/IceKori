using System;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Std.Math
{
    public class Pow : BaseExpression
    {
        public BaseExpression Floor;
        public BaseExpression Power;

        public Pow(BaseExpression f, BaseExpression p)
        {
            Floor = f;
            Power = p;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Floor.Reducible) return new Pow(Floor.Reduce(env), Power);
            if (Floor.ID == BaseError.Error)
            {
                return Floor;
            }
            if (Power.Reducible) return new Pow(Floor, Power.Reduce(env));
            if (Power.ID == BaseError.Error)
            {
                return Power;
            }
            if (Floor.ID != IceKoriBaseType.Float && Floor.ID != IceKoriBaseType.Int)
            {
                return new TypeError($"Argument of type '{Floor}' is not assignable to parameter of type 'IceKoriFloat || IceKoriInt'.");
            }
            if (Power.ID != IceKoriBaseType.Float && Power.ID != IceKoriBaseType.Int)
            {
                return new TypeError($"Argument of type '{Power}' is not assignable to parameter of type 'IceKoriFloat || IceKoriInt'.");
            }
            return new IceKoriFloat(Mathf.Pow((float)((IceKoriBaseType)Floor).Unbox(), (float)((IceKoriBaseType)Power).Unbox()));

        }

        public override string ToString()
        {
            return $"Math.pow({Floor}, {Power})";
        }
    }
}
