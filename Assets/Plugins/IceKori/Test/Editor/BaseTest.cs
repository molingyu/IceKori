using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;
using Assets.Plugins.IceKori.Syntax.Statement;
using NUnit.Framework;

namespace Assets.Plugins.IceKori.Test.Editor
{
    public class BaseTest
    {
        public Interpreter Interpreter;
        public Enviroment Env;
        public ErrorHandling ErrorHandling;

        [SetUp]
        public void Setup()
        {
            Interpreter = new Interpreter(new Dictionary<string, BaseExpression>(),
                new Dictionary<string, List<BaseStatement>>(), new Dictionary<string, IceKoriBaseType>(),
                new Dictionary<string, List<BaseStatement>>(), new List<BaseStatement>());
            Env = Interpreter.Env;
            ErrorHandling = Interpreter.ErrorHandling;
        }
    }
}
