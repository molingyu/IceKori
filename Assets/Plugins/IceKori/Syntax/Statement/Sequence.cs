using System.Collections.Generic;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class Sequence : BaseStatement
    {
        public BaseStatement First;
        public Queue<BaseStatement> Last;

        public Sequence(BaseStatement first, Queue<BaseStatement> last)
        {
            Reducible = true;
            First = first;
            Last = last;
        }

        public Sequence(List<BaseStatement> statements)
        {
            Reducible = true;
            if (statements.Count >= 2)
            {
                Last = new Queue<BaseStatement>(statements);
                First = Last.Dequeue();
            }
            else
            {
                if (statements.Count == 0)
                {
                    First = new DoNothing();
                }
                else
                {
                    First = statements[0];
                }
                Last = new Queue<BaseStatement>();
            }
        }

        public override string ToString()
        {
            var str = "";
            if (First.GetType() != typeof(EvalCallback)) str += $"{First}\n";
            foreach (var baseStatement in Last)
            {
                if (baseStatement.GetType() == typeof(EvalCallback)) continue;
                str += $"{baseStatement}\n";
            }

            return str;
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            if (First.GetType() == typeof(Break)) return new object[] {new DoNothing(), env, errorHandling};
            if (First.GetType() == typeof(DoNothing))
            {
                if (Last.Count == 0) return new object[] {new DoNothing(), env, errorHandling};
                return new object[]{ new Sequence(Last.Dequeue(), Last), env, errorHandling  };
            }
            var reduceValue = First.Reduce(env, errorHandling);
            return new[]{ new Sequence((BaseStatement)reduceValue[0], Last), reduceValue[1], reduceValue[2] };
        }
    }
}
