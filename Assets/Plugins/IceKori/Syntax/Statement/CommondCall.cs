using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.BaseType;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class CommandCall : BaseStatement
    {
        public string Name;

        public CommandCall()
        {
            Reducible = true;
        }

        public CommandCall(string name)
        {
            Reducible = true;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}.call()";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            env.VariablesStack.Push(new Dictionary<string, IceKoriBaseType>());
            var statement = new Sequence(env.Commands[Name]);
            statement.Last.Enqueue(new EvalCallback(((enviroment, handling) => enviroment.VariablesStack.Pop())));
            return new object[]{ statement, env, errorHandling };

        }
    }
}
