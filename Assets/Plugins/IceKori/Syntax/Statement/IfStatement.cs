using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using System.Collections.Generic;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class IfStatement : BaseStatement
    {
        public BaseExpression Condition;
        public List<BaseStatement> Consequence = new List<BaseStatement>();
        public List<BaseStatement> Alternative = new List<BaseStatement>();

        public IfStatement()
        {
            Reducible = true;
        }

        public IfStatement(BaseExpression condition, List<BaseStatement> consequence, List<BaseStatement> alternative)
        {
            Reducible = true;
            Condition = condition;
            Consequence = consequence;
            Alternative = alternative;
        }

        public override string ToString()
        {
            var str = $"if({Condition}){{\n";
            foreach (var baseStatement in Consequence)
            {
                str += $"{baseStatement}\n";
            }

            str += "} else {\n";
            foreach (var baseStatement in Alternative)
            {
                str += $"{baseStatement}\n";
            }
            return str + "}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var statement = _Pretreatment(Condition, () => new IfStatement(Condition.Reduce(env), Consequence, Alternative), () =>
            {
                if (Condition.ID == IceKoriBaseType.Bool || Condition.ID == IceKoriBaseType.Null)
                {
                    var condition = Condition.ID != IceKoriBaseType.Null && ((IceKoriBool) Condition).Value;
                    var context = condition ? Consequence : Alternative;
                    if (context.Count == 0)
                    {
                        return DoNothing.GetValue;
                    }
                    env.VariablesStack.Push(new Dictionary<string, IceKoriBaseType>());
                    context.Add(new EvalCallback((enviroment, handling) => enviroment.VariablesStack.Pop()));
                    return new Sequence(context);
                }
                return new Throw(new TypeError($"Condition \"{Condition}\" not boolean"));
            }, () => env.VariablesStack.Pop());
            return new object[]{ statement, env, errorHandling};
        }
    }
}