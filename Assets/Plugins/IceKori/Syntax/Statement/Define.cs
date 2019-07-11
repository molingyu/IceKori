using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class Define : BaseStatement
    {
        public string Name;
        public BaseExpression Value;

        public Define()
        {
            Reducible = true;
        }

        public Define(string name, BaseExpression value)
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
            var statement = _Pretreatment(Value, () => new Define(Name, Value.Reduce(env)), () =>
            {
                if (env.Variables.ContainsKey(Name))
                    return new Throw(new TypeError($"Identifier \"{Name}\" has already been declared"));
                env.Variables.Add(Name, (IceKoriBaseType)Value);
                return DoNothing.GetValue;
            });
            return new object[] { statement, env, errorHandling };
        }
    }
}
