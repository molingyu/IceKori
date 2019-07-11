using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class IceKoriFree : BaseStatement
    {
        public BaseExpression Value;

        public IceKoriFree()
        {
            Reducible = true;
        }

        public IceKoriFree(BaseExpression value)
        {
            Reducible = true;
            Value = value;
        }

        public override string ToString()
        {
            return $"free {Value}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            if (Value is VariableGet)
            {
                env.Variables.Remove(((VariableGet) Value).Name);
            }
            if (Value is GlobalVariableGet gvg)
            {
                env.GlobalVariables.Remove(gvg.Name);
            }
            return new object[] { DoNothing.GetValue, env, errorHandling };
        }
    }
}