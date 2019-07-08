using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class VariableUpdate : BaseStatement
    {
        public string Name;
        public BaseExpression Value;

        public VariableUpdate()
        {
            Reducible = true;
        }

        public VariableUpdate(string name, BaseExpression value)
        {
            Reducible = true;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name} = {Value}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var statement = _Pretreatment(Value, () => new VariableUpdate(Name, Value.Reduce(env)), () =>
            {
                if (!env.Variables.ContainsKey(Name))
                    return new Throw(new TypeError($"Identifier \"{Name}\" does not defined"));
                env.Variables[Name] = (IceKoriBaseType)Value;
                return new DoNothing();
            });
            return new object[] { statement, env, errorHandling };
        }
    }
}
