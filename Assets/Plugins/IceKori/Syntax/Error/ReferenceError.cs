namespace Assets.Plugins.IceKori.Syntax.Error
{
    [System.Serializable]
    public class ReferenceError : BaseError
    {
        public ReferenceError(string msg = "")
        {
            Reducible = false;
            Name = "ReferenceError";
            Msg = msg;
        }
    }
}
    