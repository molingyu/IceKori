using Assets.Plugins.IceKori.Syntax;
using Assets.Plugins.IceKori.Syntax.EventCommand;
using Assets.Plugins.IceKori.Syntax.Statement;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Plugins.IceKori.Demo.Script
{
    [System.Serializable]
    public class ShowMessageCommand : EventCommandBase
    {
        public string Name;
        public List<string> Messages;
        public bool ShowBackground;
        public Sprite Character1;
        public Sprite Character2;

        public override string ToString()
        {
            return $"<ShowMessageCommand>";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            env.Interpreter.State = InterpreterState.Stop;
            Gvar.MessageWindow.EndAction = () => env.Interpreter.State = InterpreterState.Runnig;
            Gvar.MessageWindow.Show(Messages, Name, ShowBackground, Character1, Character2);
            return new object[]{new DoNothing(), env, errorHandling};
        }
    }
}
