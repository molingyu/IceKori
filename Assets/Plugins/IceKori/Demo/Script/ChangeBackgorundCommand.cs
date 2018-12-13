using Assets.Plugins.IceKori.Syntax;
using Assets.Plugins.IceKori.Syntax.EventCommand;
using Assets.Plugins.IceKori.Syntax.Statement;
using UnityEngine;

namespace Assets.Plugins.IceKori.Demo.Script
{
    [System.Serializable]
    public class ChangeBackgorundCommand : EventCommandBase
    {
        public Sprite Background;

        public override string ToString()
        {
            return $"<ChangeBackgorundCommand>";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            Gvar.Background.sprite = Background;
            return new object[]{ new DoNothing(), env, errorHandling };
        }
    }
}
