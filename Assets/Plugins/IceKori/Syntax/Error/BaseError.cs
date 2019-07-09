using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Error
{
     public abstract class BaseError : IceKoriBaseType
     {
         public static int Error = 7;

         public string Name;
         public string Msg;

         protected BaseError()
         {
             ID = 7;
         }

         public override BaseExpression Reduce(Enviroment env)
         {
             throw new Exception(ToString());
         }

         public override string ToString()
         {
             return $"<{Name}: {Msg}>";
        }

         public override object Unbox()
         {
             return ToString();
         }
    }
}
