using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
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
            return $"print({Object})";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            Debug.Log(Object);
            return new object[]{ new DoNothing(), env, errorHandling };
        }
    }
}
