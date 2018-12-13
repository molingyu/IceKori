using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax
{
    [System.Serializable]
    public abstract class BaseNode
    {
        [HideInEditorMode]
        public bool Reducible;
    }
}
