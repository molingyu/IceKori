using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using Assets.Plugins.IceKori.Syntax.Statement;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.EventCommand
{
    [System.Serializable]
    public class SetObjectActive : EventCommandBase
    {
        public GameObject Object;
        public BaseExpression Status;

        public SetObjectActive()
        {
        }

        public SetObjectActive(GameObject gameObject, BaseExpression status)
        {
            Object = gameObject;
            Status = status;
        }

        public override string ToString()
        {
            return $"<GameObject {Object.name}>#Active = {Status}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            BaseStatement statement;
            if (Status.Reducible)
            {
                var reduceValue = Status.Reduce(env);
                if (reduceValue.GetType().IsSubclassOf(typeof(BaseError)))
                {
                    statement = new Throw((BaseError)reduceValue);
                }
                else
                {
                    statement = new SetObjectActive(Object, reduceValue);
                }  
            }
            else
            {
                if (Status.GetType() != typeof(IceKoriBool))
                {
                    statement = new Throw(new TypeError($"Constant value \"{Status}\" cannot be converted to a bool"));
                }
                else
                {
                    Object.SetActive(((IceKoriBool)Status).Value);
                    statement = new DoNothing();
                }   
            }
            return new object[]{ statement, env, errorHandling };
        }
    }
}
