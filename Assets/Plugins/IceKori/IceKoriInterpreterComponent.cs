using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;
using Assets.Plugins.IceKori.Syntax.Statement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Plugins.IceKori
{
    [AddComponentMenu("IceKori/Interpreter")]
    public class IceKoriInterpreterComponent : SerializedMonoBehaviour
    {
        public bool IsRun;
        public bool IsDebug;
        public Dictionary<string, BaseExpression> CommonVariables = new Dictionary<string, BaseExpression>();
        public Dictionary<string, List<BaseStatement>> CommonCommands = new Dictionary<string, List<BaseStatement>>();
        public List<BaseStatement> Commands = new List<BaseStatement>();
        private Interpreter _interpreter;

        void Start()
        {
            _interpreter = new Interpreter(CommonVariables, CommonCommands, new Dictionary<string, IceKoriBaseType>(), new Dictionary<string, List<BaseStatement>>(), Commands);
            _interpreter.IsDebug = IsDebug;
        }

        void Update()
        {
            if (IsRun)
            {
                _interpreter.Reduce();
            } 
        }
    }
}