using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using NUnit;
using NUnit.Framework;

namespace Assets.Plugins.IceKori.Test.Editor.Expression
{
    public class VariableGetTest : BaseTest
    {
        [Test]
        public void BaseTest()
        {
            Env.Variables.Add("bar", new IceKoriInt(1));
            VariableGet variableGet = new VariableGet("bar");

            Assert.IsTrue(variableGet.Reducible, "VariableGet#Reducible is error");
            Assert.AreEqual(((IceKoriInt)variableGet.Reduce(Env)).Value, 1, "VariableGet#Reduce is error");

            variableGet.Name = "shit";

            Assert.AreEqual(variableGet.Reduce(Env).GetType(), typeof(ReferenceError),
                "VariableGet#Reduce ReferenceError");
        }
    }
}
