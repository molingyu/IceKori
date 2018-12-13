using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Statement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax
{
    [CreateAssetMenu(menuName = "IceKori/GlobalConf")]
    public class GlobalConf : SerializedScriptableObject
    {
        public Dictionary<string, IceKoriBaseType> GlobalVariables;
        public Dictionary<string, List<BaseStatement>> GlobalCommands;

    }
}
