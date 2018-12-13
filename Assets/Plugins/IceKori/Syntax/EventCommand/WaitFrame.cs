using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Statement;

namespace Assets.Plugins.IceKori.Syntax.EventCommand
{
    public class WaitFrame : EventCommandBase
    {
        public int Frame;

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            env.Interpreter.State = InterpreterState.Stop;
            env.GetTopVariables().Add("$WAIT_FRAME", new IceKoriInt(Frame));
            env.GetTopVariables().Add("$WAIT_FRAME_INDEX", new IceKoriInt(1));
            return new object[]{ new DoNothing(), env, errorHandling };
        }
    }
}
