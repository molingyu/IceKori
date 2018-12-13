using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Std.Math
{
    public class Max : BaseExpression
    {
        public BaseExpression A;
        public BaseExpression B;

        public Max(BaseExpression a, BaseExpression b)
        {
            A = a;
            B = b;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (A.Reducible) return new Pow(A.Reduce(env), B);
            if (A.ID == BaseError.Error)
            {
                return A;
            }
            if (B.Reducible) return new Pow(A, B.Reduce(env));
            if (B.ID == BaseError.Error)
            {
                return B;
            }
            if (A.ID != IceKoriBaseType.Float && A.ID != IceKoriBaseType.Int)
            {
                return new TypeError($"Argument of type '{A}' is not assignable to parameter of type 'IceKoriFloat || IceKoriInt'.");
            }
            if (B.ID != IceKoriBaseType.Float && B.ID != IceKoriBaseType.Int)
            {
                return new TypeError($"Argument of type '{B}' is not assignable to parameter of type 'IceKoriFloat || IceKoriInt'.");
            }

            if (A.ID == IceKoriBaseType.Float)
            {
                return new IceKoriFloat(Mathf.Max(((IceKoriFloat)A).Value, ((IceKoriInt)B).Value));
            }
            if (B.ID == IceKoriBaseType.Float)
            {
                return new IceKoriFloat(Mathf.Max(((IceKoriFloat)A).Value, ((IceKoriInt)B).Value));
            }
            return new IceKoriFloat(Mathf.Max(((IceKoriInt)A).Value, ((IceKoriInt)B).Value));

        }

        public override string ToString()
        {
            return $"Math.pow(${A}, ${B})";
        }
    }
}
