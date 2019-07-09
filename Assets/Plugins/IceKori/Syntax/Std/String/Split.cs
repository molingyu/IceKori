using System.Linq;
using System.Text.RegularExpressions;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Std.String
{
    public class Split : BaseExpression
    {
        public BaseExpression Value;
        public BaseExpression Separator;

        public Split(BaseExpression value, BaseExpression separator)
        {
            Value = value;
            Separator = separator;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Value.Reducible) return new Split(Value.Reduce(env), Separator);
            if (Value.ID == BaseError.Error)
            {
                return Value;
            }
            if (Separator.Reducible) return new Split(Value, Separator.Reduce(env));
            if (Separator.ID == BaseError.Error)
            {
                return Separator;
            }

            if (Value.ID == IceKoriBaseType.String)
            {
                if (Separator.ID == IceKoriBaseType.String)
                {
                    string[] strings = Regex.Split(((IceKoriString) Value).Value, ((IceKoriString) Separator).Value);
                    var iceKoriStrings = strings.Select(value => (IceKoriBaseType)new IceKoriString(value)).ToList();
                    return new IceKoriArray(iceKoriStrings);
                }
                return new TypeError($"Argument[2] of type '{Separator}' is not assignable to parameter of type 'IceKoriString'.");
            }
            return new TypeError($"Argument[1] of type '{Value}' is not assignable to parameter of type 'IceKoriString'.");

        }

        public override string ToString()
        {
            return $"String.split({Value}, {Separator})";
        } 
    }
}