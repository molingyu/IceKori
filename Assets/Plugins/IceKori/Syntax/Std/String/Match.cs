using System;
using System.Text.RegularExpressions;
using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Std.String
{
    [PageSlider, Serializable]
    public class Match : BaseExpression
    {
        public BaseExpression Value;
        public string Regexp;

        public Match(BaseExpression value, string regexp)
        {
            Value = value;
            Regexp = regexp;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Value.Reducible) return new Match(Value.Reduce(env), Regexp);
            if (Value.ID == BaseError.Error)
            {
                return Value;
            }

            if (Value.ID == IceKoriBaseType.String)
            {
                System.Text.RegularExpressions.Match match = Regex.Match(((IceKoriString) Value).Value, Regexp);
                int index = 0;
                foreach (Group matchGroup in match.Groups)
                {
                    env.GlobalVariables[$"${index+1}"] = new IceKoriString(matchGroup.Value);
                }
                return new IceKoriString(match.Value);
            }
            return new TypeError($"Argument[1] of type '{Value}' is not assignable to parameter of type 'IceKoriString'.");
        }

        public override string ToString()
        {
            return $"String.match({Value}, {Regexp})";
        }
    }
}