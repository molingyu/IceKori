using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.BaseType.Object;
using Assets.Plugins.IceKori.Syntax.Expression;
using Assets.Plugins.IceKori.Syntax.Statement;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax
{
    /// <summary>
    /// 解释器的运行状态
    /// </summary>
    public enum InterpreterState
    {
        /// <summary>
        /// 解释器已初始化完毕，但未开始运行。
        /// </summary>
        Pending,
        /// <summary>
        /// 解释器正在运行。
        /// </summary>
        Runnig,
        /// <summary>
        /// 解释器暂停状态。
        /// </summary>
        Stop,
        /// <summary>
        /// 解释器运行结束。
        /// </summary>
        End
    }

    public class Interpreter
    {
        /// <summary>
        /// 解释器的运行状态。
        /// </summary>
        public InterpreterState State;
        /// <summary>
        /// 是否开启 Debug 状态。
        /// </summary>
        public bool IsDebug;
        /// <summary>
        /// 当前正在求值的语句。
        /// </summary>
        public BaseStatement Statement;
        /// <summary>
        /// 解释器的环境对象。
        /// </summary>
        public Enviroment Env;
        /// <summary>
        /// 解释器的错误处理对象。
        /// </summary>
        public ErrorHandling ErrorHandling;

        /// <summary>
        /// IceKori 解释器对象。
        /// </summary>
        /// <param name="commonVariables">公共变量列表</param>
        /// <param name="commonCommands">公共指令列表</param>
        /// <param name="globalVariables">全局变量列表</param>
        /// <param name="globalCommands">全局指令列表</param>
        /// <param name="commands">指令列表</param>
        public Interpreter(Dictionary<string, BaseExpression> commonVariables,
            Dictionary<string, List<BaseStatement>> commonCommands,
            Dictionary<string, IceKoriBaseType> globalVariables,
            Dictionary<string, List<BaseStatement>> globalCommands,
            List<BaseStatement> commands)
        {
            ErrorHandling = new ErrorHandling();
            Env = new Enviroment(this, commonVariables, commonCommands, globalVariables, globalCommands);
            Statement = new Sequence(commands);
            _DefaultDefine();
            State = InterpreterState.Pending;
        }

        private void _DefaultDefine()
        {
            Env.Variables.Add("$!", IceKoriNull.GetNull);
        }

        private void _Reduce()
        {
            if (IsDebug) Debug.Log(IceKori.PrettifyPrint(Statement.ToString()));
            if (Statement.GetType() != typeof(DoNothing))
            {
                var reduceValue = Statement.Reduce(Env, ErrorHandling);
                Statement = (BaseStatement)reduceValue[0];
                Env = (Enviroment)reduceValue[1];
                ErrorHandling = (ErrorHandling)reduceValue[2];
            }
            else
            {
                State = InterpreterState.End;
            }

        }

        /// <summary>
        /// 对表达式求值。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IceKoriBaseType ExpressionValue(BaseExpression expression)
        {
            while (expression.Reducible)
            {
                expression = expression.Reduce(Env);
            }
            return (IceKoriBaseType)expression;
        }

        /// <summary>
        /// 对解释器进行一次求值。
        /// </summary>
        public void Reduce()
        {
            switch (State)
            {
                case InterpreterState.Pending:
                    State = InterpreterState.Runnig;
                    _Reduce();
                    break;
                case InterpreterState.Runnig:
                    _Reduce();
                    break;
                case InterpreterState.Stop:
                    _WaiteTime();
                    _WaiteFrame();
                    break;
                case InterpreterState.End:
                    return;
            }

        }

        private void _WaiteTime()
        {
            if (Env.GetTopVariables().ContainsKey("$TIMER"))
            {
                var timer = ((IceKoriDataTime)Env.GetTopVariables()["$TIMER"]).Value;
                var date = ((IceKoriInt)Env.GetTopVariables()["$DATE"]).Value;
                if ((DateTime.Now - timer).Ticks >= date * 10000000)
                {
                    Env.GetTopVariables().Remove("$TIMER");
                    Env.GetTopVariables().Remove("$DATE");
                    State = InterpreterState.Runnig;
                    _Reduce();
                }
            }
        }

        private void _WaiteFrame()
        {
            if (Env.GetTopVariables().ContainsKey("$WAIT_FRAME"))
            {
                var frame = ((IceKoriInt)Env.GetTopVariables()["$WAIT_FRAME"]).Value;
                var index = ((IceKoriInt)Env.GetTopVariables()["$WAIT_FRAME_INDEX"]).Value;
                if (index > frame)
                {
                    Env.GetTopVariables().Remove("$WAIT_FRAME_INDEX");
                    Env.GetTopVariables().Remove("$WAIT_FRAME");
                    State = InterpreterState.Runnig;
                    _Reduce();
                }
                else
                {
                    ((IceKoriInt) Env.GetTopVariables()["$WAIT_FRAME_INDEX"]).Value += 1;
                }
            }
        }

        /// <summary>
        /// 运行解释器，直到所有语句运行完成。
        /// </summary>
        public void Run()
        {
            State = InterpreterState.Runnig;
            while (Statement.Reducible && State != InterpreterState.Stop)
            {
                Reduce();
            }
        }
    }
}
