namespace Assets.Plugins.IceKori.Syntax.Error
{
    [System.Serializable]
    public class TypeError : BaseError
    {
        public TypeError(string msg = "")
        {
            Reducible = false;
            Name = "ReferenceError";
            Msg = msg;
        }
    }
}
