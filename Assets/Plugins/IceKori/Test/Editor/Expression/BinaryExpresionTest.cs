using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using NUnit.Framework;

namespace Assets.Plugins.IceKori.Test.Editor.Expression
{
    public class BinaryExpresionTest : BaseTest
    {
        public BinaryExpression BinaryExpression;

        [SetUp]
        public void Start()
        {
            BinaryExpression = new BinaryExpression(BinaryOperator.Add, new IceKoriInt(1), new IceKoriInt(2));
        }

        [Test]
        public void BasePasses()
        {
            Assert.IsTrue(BinaryExpression.Reducible, "BinaryExpression can't reducible");
        }

        [Test]
        public void AddPasses()
        {
            
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriInt), "BinaryExpression#Add(int + int) type is error");
            Assert.AreEqual(((IceKoriInt)BinaryExpression.Reduce(Env)).Value, 3, "BinaryExpression#Add(int + int) value is error");

            BinaryExpression.Left = new IceKoriFloat(2.3f);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriFloat), "BinaryExpression#Add(int + float) type is error");
            Assert.AreEqual(((IceKoriFloat)BinaryExpression.Reduce(Env)).Value, 4.3f, "BinaryExpression#Add(int + float) value is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#Add TypeError");
        }

        [Test]
        public void SubPasses()
        {
            BinaryExpression.Operator = BinaryOperator.Sub;
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriInt), "BinaryExpression#Sub(int - int) type is error");
            Assert.AreEqual(((IceKoriInt)BinaryExpression.Reduce(Env)).Value, -1, "BinaryExpression#Sub(int + int) value is error");

            BinaryExpression.Left = new IceKoriFloat(2.5f);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriFloat), "BinaryExpression#Sub(int - float) type is error");
            Assert.AreEqual(((IceKoriFloat)BinaryExpression.Reduce(Env)).Value, 0.5f, "BinaryExpression#Sub(int - float) value is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#Sub TypeError");
        }

        [Test]
        public void MulPasses()
        {
            BinaryExpression.Operator = BinaryOperator.Mul;
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriInt), "BinaryExpression#Mul(int * int) type is error");
            Assert.AreEqual(((IceKoriInt)BinaryExpression.Reduce(Env)).Value, 2, "BinaryExpression#Add(int * int) value is error");

            BinaryExpression.Left = new IceKoriFloat(0.5f);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriFloat), "BinaryExpression#Mul(int * float) type is error");
            Assert.AreEqual(((IceKoriFloat)BinaryExpression.Reduce(Env)).Value, 1f, "BinaryExpression#Div(int * float) value is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#Mul TypeError");
        }

        [Test]
        public void DivPasses()
        {
            BinaryExpression.Operator = BinaryOperator.Div;
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriInt), "BinaryExpression#Div(int / int) type is error");
            Assert.AreEqual(((IceKoriInt)BinaryExpression.Reduce(Env)).Value, 0, "BinaryExpression#Add(int / int) value is error");

            BinaryExpression.Left = new IceKoriFloat(1.0f);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriFloat), "BinaryExpression#Div(int / float) type is error");
            Assert.AreEqual(((IceKoriFloat)BinaryExpression.Reduce(Env)).Value, 0.5f, "BinaryExpression#Div(int / float) value is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#Div TypeError");
        }

        [Test]
        public void ModPasses()
        {
            BinaryExpression.Operator = BinaryOperator.Mod;
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriInt), "BinaryExpression#Mod(int % int) type is error");
            Assert.AreEqual(((IceKoriInt)BinaryExpression.Reduce(Env)).Value, 1, "BinaryExpression#Mod(int % int) value is error");

            BinaryExpression.Right = new IceKoriFloat(0.5f);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(IceKoriFloat), "BinaryExpression#Mod(int % float) type is error");
            Assert.AreEqual(((IceKoriFloat)BinaryExpression.Reduce(Env)).Value, 0f, "BinaryExpression#Mod(int % float) value is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#Mod TypeError");
        }

        [Test]
        public void LessExpressionPasses()
        {
            BinaryExpression.Operator = BinaryOperator.Less;
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#Less({BinaryExpression.Left} < {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriFloat(1.0f);
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#Less({BinaryExpression.Left} < {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#Less TypeError");
        }

        [Test]
        public void LessEqualExpressionPasses()
        {
            BinaryExpression.Operator = BinaryOperator.LessEqual;

            BinaryExpression.Left = new IceKoriInt(2);
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#LessEqual({BinaryExpression.Left} <= {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriFloat(2.0f);
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#LessEqual({BinaryExpression.Left} <= {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#LessEqual TypeError");
        }

        [Test]
        public void MoreExpressionPasses()
        {
            BinaryExpression.Operator = BinaryOperator.More;
            Assert.IsFalse(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#More({BinaryExpression.Left} > {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriFloat(3.0f);
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#More({BinaryExpression.Left} > {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#More TypeError");
        }

        [Test]
        public void MoreEqualExpressionPasses()
        {
            BinaryExpression.Operator = BinaryOperator.MoreEqual;
            Assert.IsFalse(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#MoreEqual({BinaryExpression.Left} >= {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriFloat(2.0f);
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#MoreEqual({BinaryExpression.Left} >= {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#MoreEqual TypeError");
        }

        [Test]
        public void EqualExpressionPasses()
        {
            BinaryExpression.Operator = BinaryOperator.Equal;
            Assert.IsFalse(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#Equal({BinaryExpression.Left} == {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriFloat(2.0f);
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#Equal({BinaryExpression.Left} == {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#Equal TypeError");
        }

        [Test]
        public void NotEqualExpressionPasses()
        {
            BinaryExpression.Operator = BinaryOperator.NotEqual;
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#NotEqual({BinaryExpression.Left} != {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriFloat(2.0f);
            Assert.IsFalse(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, $"BinaryExpression#NotEqual({BinaryExpression.Left} != {BinaryExpression.Right}) is error");

            BinaryExpression.Left = new IceKoriBool(true);
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#NotEqual TypeError");
        }

        [Test]
        public void LogicExpressionPasses()
        {
            BinaryExpression.Operator = BinaryOperator.Or;
            Assert.AreEqual(BinaryExpression.Reduce(Env).GetType(), typeof(TypeError), "BinaryExpression#Logic Expression TypeError");

            BinaryExpression.Left = new IceKoriBool(true);
            BinaryExpression.Right = new IceKoriBool(false);
            Assert.IsTrue(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, "BinaryExpression#Or is error");
            
            BinaryExpression.Operator = BinaryOperator.And;
            Assert.IsFalse(((IceKoriBool)BinaryExpression.Reduce(Env)).Value, "BinaryExpression#And is error");
        }

        [Test]
        public void StringConcatPasses()
        {
            BinaryExpression.Operator = BinaryOperator.Concat;
            Assert.AreEqual(((IceKoriString)BinaryExpression.Reduce(Env)).Value, "12", "BinaryExpression#Add is error");
        }
    }

}
