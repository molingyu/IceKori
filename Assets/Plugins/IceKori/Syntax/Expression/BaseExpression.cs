using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Expression
{
    [System.Serializable]
    public abstract class BaseExpression : BaseNode
    {
        [HideInEditorMode]
        public int ID = 16;

        /// <summary>
        /// 对表达式求值
        /// </summary>
        /// <param name="env">环境对象</param>
        /// <returns></returns>
        public abstract BaseExpression Reduce(Enviroment env);
    }
}
