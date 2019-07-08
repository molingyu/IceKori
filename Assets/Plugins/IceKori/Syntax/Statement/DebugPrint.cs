using Assets.Plugins.IceKori.Common;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [PageSlider]
    [System.Serializable]
    public class DebugPrint : BaseStatement
    {
        public BaseNode Object;

        public DebugPrint()
        {
            Reducible = true;
        }

        public override string ToString()
        {
            return $"debugPrint({Object})";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            Debug.Log(Object);
            return new object[]{ new DoNothing(), env, errorHandling };
        }
    }
}
