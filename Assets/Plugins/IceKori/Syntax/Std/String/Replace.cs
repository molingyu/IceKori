using System;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Std.String
{ 
    [PageSlider, Serializable]
    public class Replace : BaseExpression
    {
        public BaseExpression Value;
        public BaseExpression OldValue;
        public BaseExpression NewValue;
        
        public Replace(BaseExpression value, BaseExpression oldValue, BaseExpression newValue)
        {
            Value = value;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Value.Reducible) return new Replace(Value.Reduce(env), OldValue, NewValue);
            if (Value.ID == BaseError.Error)
            {
                return Value;
            }
            if (OldValue.Reducible) return new Replace(Value, OldValue.Reduce(env), NewValue);
            if (OldValue.ID == BaseError.Error)
            {
                return OldValue;
            }
            if (NewValue.Reducible) return new Replace(Value, OldValue, NewValue.Reduce(env));
            if (NewValue.ID == BaseError.Error)
            {
                return NewValue;
            }

            if (Value.ID == IceKoriBaseType.String)
            {
                if (OldValue.ID == IceKoriBaseType.String)
                {
                    if (NewValue.ID == IceKoriBaseType.String)
                    {
                        ((IceKoriString) Value).Value = ((IceKoriString) Value).Value.Replace(((IceKoriString) OldValue).Value,
                            ((IceKoriString) NewValue).Value);
                        return Value;
                    }
                    return new TypeError($"Argument[3] of type '{NewValue}' is not assignable to parameter of type 'IceKoriString'.");
                }
                return new TypeError($"Argument[2] of type '{OldValue}' is not assignable to parameter of type 'IceKoriString'.");
            }
            return new TypeError($"Argument[1] of type '{Value}' is not assignable to parameter of type 'IceKoriString'.");

        }

        public override string ToString()
        {
            return $"String.replace({Value}, {OldValue}, {NewValue})";
        }
    }
}