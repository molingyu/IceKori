using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using Sirenix.OdinInspector;
using System;
using JetBrains.Annotations;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public abstract class BaseStatement : BaseNode
    {
        [HideInEditorMode]
        public int Level;
        /// <summary>
        /// 对语句进行一次求值。
        /// </summary>
        /// <param name="env">环境对象</param>
        /// <param name="errorHandling">错误处理对象</param>
        /// <returns></returns>
        public abstract object[] Reduce(Enviroment env, ErrorHandling errorHandling);

        protected BaseStatement _Pretreatment(BaseExpression reduceValue, Func<BaseStatement> isReducible, Func<BaseStatement> reduce, [CanBeNull] Action isBlock = null)
        {
            if (reduceValue.Reducible.GetType().IsSubclassOf(typeof(BaseError)))
            {
                isBlock?.Invoke();
                return new Throw((BaseError)reduceValue);
            }

            return reduceValue.Reducible ? isReducible() : reduce();
        }
    }
}
