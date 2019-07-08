using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Common;

namespace Assets.Plugins.IceKori.Syntax.Expression
{
    [PageSlider]
    [System.Serializable]
    public class GlobalVariableGet : BaseExpression
    {
        public string Name;

        public GlobalVariableGet()
        {
            Reducible = true;
        }

        public GlobalVariableGet(string name)
        {
            Reducible = true;
            Name = name;
        }

        public override string ToString()
        {
            return $"${Name}";
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (!env.GlobalVariables.ContainsKey(Name)) return new ReferenceError($"Global variable {Name} is not defined");
            return env.GlobalVariables[Name];
        }
    }
}
