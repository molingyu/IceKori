using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using NUnit;
using NUnit.Framework;

namespace Assets.Plugins.IceKori.Test.Editor.Expression
{
    public class GlobalVariableGetTest : BaseTest
    {
        [Test]
        public void BaseTest()
        {
            Env.GlobalVariables.Add("bar", new IceKoriInt(1));
            GlobalVariableGet globalVariableGet = new GlobalVariableGet("bar");

            Assert.IsTrue(globalVariableGet.Reducible, "GlobalVariableGet#Reducible is error");
            Assert.AreEqual(((IceKoriInt)globalVariableGet.Reduce(Env)).Value, 1, "GlobalVariableGet#Reduce is error");

            globalVariableGet.Name = "shit";

            Assert.AreEqual(globalVariableGet.Reduce(Env).GetType(), typeof(ReferenceError),
                "GlobalVariableGet#Reduce ReferenceError");
        }
    }
}
