using System;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class EvalCallback : BaseStatement
    {
        public Action<Enviroment, ErrorHandling> Func;

        public EvalCallback(Action<Enviroment, ErrorHandling> func)
        {
            Reducible = true;
            Func = func;
        }
        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            Func(env, errorHandling);
            return new object[]{ new DoNothing(), env, errorHandling };
        }
    }
}
