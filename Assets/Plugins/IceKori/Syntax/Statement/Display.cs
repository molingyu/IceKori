using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.Expression;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class Display : BaseStatement
    {
        public BaseExpression Body;

        public Display()
        {
            Reducible = true;
        }

        public Display(BaseExpression body)
        {
            Reducible = true;
            Body = body;
        }

        public override string ToString()
        {
            return $"display({Body})";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var statement = _Pretreatment(Body, () => new Display(Body.Reduce(env)), () =>
            {
                Debug.Log(Body);
                return DoNothing.GetValue;
            });
            return new object[] { statement, env, errorHandling };
        }
    }
}
