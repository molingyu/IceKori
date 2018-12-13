using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class ForStatement : BaseStatement
    {
        public BaseExpression Count;
        public List<BaseStatement> Body = new List<BaseStatement>();
        [HideInEditorMode]
        public int Index;

        public ForStatement()
        {
            Reducible = true;
        }

        public ForStatement(BaseExpression count, List<BaseStatement> body)
        {
            Reducible = true;
            Count = count;
            Body = body;
        }

        public override string ToString()
        {
            var str = $"for({Count}){{\n";
            foreach (var baseStatement in Body)
            {
                str += $"{baseStatement}\n";
            }

            return str + "}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var statement = _Pretreatment(Count,() => new ForStatement(Count.Reduce(env), Body), () =>
            {
                if (Index == 0) env.VariablesStack.Push(new Dictionary<string, IceKoriBaseType>());
                Index += 1;
                return new IfStatement(
                new BinaryExpression(BinaryOperator.LessEqual, new IceKoriInt(Index), Count),
                new List<BaseStatement>(Body) {this},
                new List<BaseStatement>
                {
                    new EvalCallback((enviroment, handling) => enviroment.VariablesStack.Pop())
                });
            }, () => env.VariablesStack.Pop());
            return new object[] { statement, env, errorHandling };
        }
    }
}
