namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class DoNothing : BaseStatement
    {
        public DoNothing()
        {
            Reducible = false;
        }

        public override string ToString()
        {
            return $"DoNothing()\n";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            return new object[]{};
        }
    }
}
