using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class GlobalVariableUpdate : BaseStatement
    {
        public string Name;
        public BaseExpression Value;

        public GlobalVariableUpdate()
        {
            Reducible = true;
        }

        public GlobalVariableUpdate(string name, BaseExpression value)
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
            var statement = _Pretreatment(Value, () => new GlobalVariableUpdate(Name, Value.Reduce(env)), () =>
            {
                if (!env.GlobalVariables.ContainsKey(Name))
                    return new Throw(new TypeError($"Global identifier \"{Name}\" does not defined"));
                env.GlobalVariables[Name] = (IceKoriBaseType)Value;
                return DoNothing.GetValue;
            });
            return new object[] { statement, env, errorHandling };
        }
    }
}
