using Assets.Plugins.IceKori.Syntax.Statement;
using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax
{
    public class ErrorHandling
    {
        public int Pointer;
        public List<TryCatch> TryCatchStack;
        public TryCatch TryCatch => TryCatchStack.Last();

        public ErrorHandling()
        {
            TryCatchStack = new List<TryCatch>();
        }

        public void Push(TryCatch tryCatch)
        {
            TryCatchStack.Add(tryCatch);
            Pointer = TryCatchStack.Count - 1;
        }

        public void Pop()
        {
            if (TryCatchStack.Count != 0) TryCatchStack.RemoveAt(Pointer);
        }

        public BaseStatement ThrowError(BaseError error, Enviroment env)
        {
            if (Pointer < 0)
            {
                Debug.LogWarning(error);
                env.Interpreter.State = InterpreterState.End;
                return new DoNothing();
            }
            else
            {
                if (TryCatch.Catch != ErrorType.All && error.Name != TryCatch.Catch.ToString())
                {
                    Pointer -= 1;
                    return ThrowError(error, env);
                }

                env.GlobalVariables["$!"] = error;
                env.VariablesStack.Push(new Dictionary<string, IceKoriBaseType>());
                return new Sequence(TryCatch.Rescue);
            }
        }
    }
}
