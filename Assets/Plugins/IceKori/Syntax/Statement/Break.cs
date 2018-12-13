using System;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class Break : BaseStatement
    {
        /// <summary>
        /// break 语句。用于从 if/for/while 结构里跳出。
        /// </summary>
        public Break()
        {
            Reducible = false;
        }

        public override string ToString()
        {
            return "break";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            throw new NotImplementedException();
        }
    }
}
