using System;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;

namespace Assets.Plugins.IceKori.Syntax.Expression
{
    [Serializable]
    public enum BinaryOperator
    {
        Add,
        Sub,
        Mul,
        Div,
        Mod,
        Concat,
        Less,
        LessEqual,
        Equal,
        MoreEqual,
        More,
        NotEqual,
        And,
        Or
    }
    [PageSlider]
    [Serializable]
    public class BinaryExpression : BaseExpression
    {
        private static float TOLERANCE = 0.0000001f;

        /// <summary>
        /// 表达式的操作符
        /// </summary>
        public BinaryOperator Operator;
        /// <summary>
        /// 表达式左侧子表达式
        /// </summary>
        public BaseExpression Left;
        /// <summary>
        /// 表达式右侧子表达式
        /// </summary>
        public BaseExpression Right;

        /// <summary>
        /// 表示一个二元表达式对象。
        /// </summary>
        public BinaryExpression()
        {
            Reducible = true;
        }

        /// <summary>
        /// 表示一个二元表达式对象。
        /// </summary>
        /// <param name="op">表达式的操作符</param>
        /// <param name="left">表达式左侧子表达式</param>
        /// <param name="right">表达式右侧子表达式</param>
        public BinaryExpression(BinaryOperator op, BaseExpression left, BaseExpression right)
        {
            Reducible = true;
            Operator = op;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return $"({Left} {_GetSymbol()} {Right})";
        }

        private string _GetSymbol()
        {
            switch (Operator)
            {
                case BinaryOperator.Add:
                    return "+";
                case BinaryOperator.Sub:
                    return "-";
                case BinaryOperator.Mul:
                    return "*";
                case BinaryOperator.Div:
                    return "/";
                case BinaryOperator.Mod:
                    return "%";
                case BinaryOperator.Concat:
                    return "..";
                case BinaryOperator.Less:
                    return "<";
                case BinaryOperator.LessEqual:
                    return "<=";
                case BinaryOperator.Equal:
                    return "==";
                case BinaryOperator.MoreEqual:
                    return ">=";
                case BinaryOperator.More:
                    return ">";
                case BinaryOperator.NotEqual:
                    return "!=";
                case BinaryOperator.And:
                    return "&&";
                case BinaryOperator.Or:
                    return "||";
                default:
                    throw new System.Exception($"error operator,\"{Operator}\" not define.");
            }
        }

        private BaseExpression _Add()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value + ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value + ((IceKoriFloat)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value + ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value + ((IceKoriFloat)Right).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Sub()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value - ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value - ((IceKoriFloat)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value - ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value - ((IceKoriFloat)Right).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Mul()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value * ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value * ((IceKoriFloat)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value * ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value * ((IceKoriFloat)Right).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Div()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value / ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value / ((IceKoriFloat)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value / ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value / ((IceKoriFloat)Right).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Mod()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value % ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value % ((IceKoriFloat)Right).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value % ((IceKoriInt)Right).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value % ((IceKoriFloat)Right).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Concat()
        {
            return new IceKoriString($"{Left}{Right}");
        }

        private BaseExpression _Less()
        {
            if (Left is IceKoriBool ||
               Right is IceKoriBool ||
               Left is IceKoriString ||
               Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return ((IceKoriInt)Left).Value < ((IceKoriInt)Right).Value
                        ? IceKoriBool.GetTrue
                        : IceKoriBool.GetFalse;
                }
                return (((IceKoriInt)Left).Value < ((IceKoriFloat)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }
            if (Right is IceKoriInt)
            {
                return (((IceKoriFloat)Left).Value < ((IceKoriInt)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }
            return (((IceKoriFloat)Left).Value < ((IceKoriFloat)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;

        }

        private BaseExpression _LessEqual()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return ((IceKoriInt)Left).Value <= ((IceKoriInt)Right).Value
                        ? IceKoriBool.GetTrue
                        : IceKoriBool.GetFalse;
                }
                return (((IceKoriInt)Left).Value <= ((IceKoriFloat)Right).Value)
                    ? IceKoriBool.GetTrue
                    : IceKoriBool.GetFalse;
            }
            if (Right is IceKoriInt)
            {
                return ((IceKoriFloat)Left).Value <= ((IceKoriInt)Right).Value
                    ? IceKoriBool.GetTrue
                    : IceKoriBool.GetFalse;
            }
            return ((IceKoriFloat)Left).Value <= ((IceKoriFloat)Right).Value
                ? IceKoriBool.GetTrue
                : IceKoriBool.GetFalse;
        }

        private BaseExpression _Equal()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return (((IceKoriInt)Left).Value == ((IceKoriInt)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
                }
                return (Math.Abs(((IceKoriInt)Left).Value - ((IceKoriFloat)Right).Value) < TOLERANCE)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }
            if (Right is IceKoriInt)
            {
                return (Math.Abs(((IceKoriFloat)Left).Value - ((IceKoriInt)Right).Value) < TOLERANCE)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }
            return (Math.Abs(((IceKoriFloat)Left).Value - ((IceKoriFloat)Right).Value) < TOLERANCE)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
        }

        private BaseExpression _MoreEqual()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return (((IceKoriInt)Left).Value >= ((IceKoriInt)Right).Value)
                        ? IceKoriBool.GetTrue
                        : IceKoriBool.GetFalse;
                }
                return (((IceKoriInt)Left).Value >= ((IceKoriFloat)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }
            if (Right is IceKoriInt)
            {
                return (((IceKoriFloat)Left).Value >= ((IceKoriInt)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }
            return (((IceKoriFloat)Left).Value >= ((IceKoriFloat)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
        }

        private BaseExpression _More()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return (((IceKoriInt)Left).Value > ((IceKoriInt)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
                }
                return (((IceKoriInt)Left).Value > ((IceKoriFloat)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }
            if (Right is IceKoriInt)
            {
                return (((IceKoriFloat)Left).Value > ((IceKoriInt)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }
            return (((IceKoriFloat)Left).Value > ((IceKoriFloat)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
        }

        private BaseExpression _NotEqual()
        {
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return (((IceKoriInt)Left).Value != ((IceKoriInt)Right).Value)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;

                }
                return (Math.Abs(((IceKoriInt)Left).Value - ((IceKoriFloat)Right).Value) > TOLERANCE)
					? IceKoriBool.GetTrue
					: IceKoriBool.GetFalse;
            }

            if (Left is IceKoriFloat)
            {
                if (Right is IceKoriInt)
                {
                    return (Math.Abs(((IceKoriFloat)Left).Value - ((IceKoriInt)Right).Value) > TOLERANCE)
                        ? IceKoriBool.GetTrue
                        : IceKoriBool.GetFalse;
                }
                return (Math.Abs(((IceKoriFloat)Left).Value - ((IceKoriFloat)Right).Value) > TOLERANCE)
                    ? IceKoriBool.GetTrue
                    : IceKoriBool.GetFalse;
            }

            if (Left.ID == IceKoriBaseType.Null)
            {
                return (Right.ID != IceKoriBaseType.Null)
                    ? IceKoriBool.GetTrue
                    : IceKoriBool.GetFalse;
            }
            if (Right.ID == IceKoriBaseType.Null)
            {
                return (Left.ID != IceKoriBaseType.Null)
                    ? IceKoriBool.GetTrue
                    : IceKoriBool.GetFalse;
            }
            if (Left.ID != Right.ID) return new TypeError($"Argument of type '{Right}' is not assignable to parameter of type '{Left.GetType().Name}'.");
            if (Left is IceKoriBool)
            {
                return (((IceKoriBool)Left).Value != ((IceKoriBool)Right).Value)
                    ? IceKoriBool.GetTrue
                    : IceKoriBool.GetFalse;
            }

            return (((IceKoriString)Left).Value != ((IceKoriString)Right).Value)
                ? IceKoriBool.GetTrue
                : IceKoriBool.GetFalse;
        }

        private BaseExpression _And()
        {
            if (Left.ID != IceKoriBaseType.Bool)
            {
                return new TypeError($"Argument of type '{Left}' is not assignable to parameter of type 'IceKoriBool'.");
            }
            if (Right.ID != IceKoriBaseType.Bool)
            {
                return new TypeError($"Argument of type '{Right}' is not assignable to parameter of type 'IceKoriBool'.");
            }
            return (((IceKoriBool)Left).Value && ((IceKoriBool)Right).Value)
                ? IceKoriBool.GetTrue
                : IceKoriBool.GetFalse;
        }

        private BaseExpression _Or()
        {
            if (Left.ID != IceKoriBaseType.Bool)
            {
                return new TypeError($"Argument of type '{Left}' is not assignable to parameter of type 'IceKoriBool'.");
            }
            if (Right.ID != IceKoriBaseType.Bool)
            {
                return new TypeError($"Argument of type '{Right}' is not assignable to parameter of type 'IceKoriBool'.");
            }
            return (((IceKoriBool)Left).Value || ((IceKoriBool)Right).Value)
                ? IceKoriBool.GetTrue
                : IceKoriBool.GetFalse;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Left.Reducible) return new BinaryExpression(Operator, Left.Reduce(env), Right);
            if (Left.ID == BaseError.Error)
            {
                return Left;
            }
            if (Right.Reducible) return new BinaryExpression(Operator, Left, Right.Reduce(env));
            if (Right.ID == BaseError.Error)
            {
                return Right;
            }
            if (Left.ID == IceKoriBaseType.Object)
            {
                return new TypeError($"Argument of type '{Left}' is not assignable to parameter of type 'IceKoriInt || IceKoriFloat || IceKoriBool || IceKoriString || IceKoriNull'");
            }
            if (Right.ID == IceKoriBaseType.Object)
            {
                return new TypeError($"Argument of type '{Left}' is not assignable to parameter of type 'IceKoriInt || IceKoriFloat || IceKoriBool || IceKoriString || IceKoriNull'");
            }
            switch (Operator)
            {
                case BinaryOperator.Add:
                    return _Add();
                case BinaryOperator.Sub:
                    return _Sub();
                case BinaryOperator.Mul:
                    return _Mul();
                case BinaryOperator.Div:
                    return _Div();
                case BinaryOperator.Mod:
                    return _Mod();
                case BinaryOperator.Concat:
                    return _Concat();
                case BinaryOperator.Less:
                    return _Less();
                case BinaryOperator.LessEqual:
                    return _LessEqual();
                case BinaryOperator.Equal:
                    return _Equal();
                case BinaryOperator.MoreEqual:
                    return _MoreEqual();
                case BinaryOperator.More:
                    return _More();
                case BinaryOperator.NotEqual:
                    return _NotEqual();
                case BinaryOperator.And:
                    return _And();
                case BinaryOperator.Or:
                    return _Or();
                default:
                    throw new System.Exception($"error operator,\"{Operator}\" not define.");
            }
        }
    }
}
