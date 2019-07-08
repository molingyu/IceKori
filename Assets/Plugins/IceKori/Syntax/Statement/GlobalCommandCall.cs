using Assets.Plugins.IceKori.Common;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class GlobalCommandCall : BaseStatement
    {
        public string Name;

        public GlobalCommandCall()
        {
            Reducible = true;

        }

        public GlobalCommandCall(string name)
        {
            Reducible = true;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}()";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            return new object[]{ new Sequence(env.GlobalCommands[Name]), env, errorHandling };

        }
    }
}
