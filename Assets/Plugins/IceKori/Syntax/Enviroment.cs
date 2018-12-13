using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using Assets.Plugins.IceKori.Syntax.Statement;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Plugins.IceKori.Syntax
{
    public class Enviroment
    {
        public Interpreter Interpreter;
        public Stack<Dictionary<string, IceKoriBaseType>> VariablesStack;
        public Dictionary<string, List<BaseStatement>> Commands;
        public Dictionary<string, IceKoriBaseType> GlobalVariables;
        public Dictionary<string, List<BaseStatement>> GlobalCommands;

        public Dictionary<string, IceKoriBaseType> Variables => VariablesStack.Peek();

        private Dictionary<string, IceKoriBaseType> _topVariables;

        public Enviroment(Interpreter interpreter,
            Dictionary<string, BaseExpression> commonVariables,
            Dictionary<string, List<BaseStatement>> commonCommands,
            Dictionary<string, IceKoriBaseType> globalVariables,
            Dictionary<string, List<BaseStatement>> globalCommands)
        {
            Interpreter = interpreter;
            GlobalCommands = globalCommands;
            GlobalVariables = globalVariables;
            Commands = commonCommands;
            VariablesStack = new Stack<Dictionary<string, IceKoriBaseType>>();
            _topVariables = new Dictionary<string, IceKoriBaseType>();
            VariablesStack.Push(_topVariables);
            _VariableReduce(commonVariables);
        }

        private void _VariableReduce(Dictionary<string, BaseExpression> variables)
        {
            foreach (var keyValuePair in variables)
            {
                BaseExpression value = keyValuePair.Value;
                while (true)
                {

                    if (value.Reducible)
                    {
                        value = value.Reduce(this);
                        if (value.GetType().IsSubclassOf(typeof(BaseError)))
                        {
                            Interpreter.ErrorHandling.ThrowError((BaseError)value, this);
                            return;
                        }
                    }
                    else
                    {
                        Variables[keyValuePair.Key] = (IceKoriBaseType)value;
                        break;
                    }
                }
 
            }
        }

        public Dictionary<string, IceKoriBaseType> GetTopVariables()
        {
            return _topVariables;
        }

        public BaseExpression FindVariable(string name)
        {
            foreach (var variables in VariablesStack.Reverse())
            {
                if (variables.ContainsKey(name)) return variables[name];
            }
            return new ReferenceError($"{name} is not defined");
        }
    }
}
