using System;
using Assets.Plugins.IceKori.Syntax;
using UnityEngine;

namespace Assets.Plugins.IceKori
{
    public static class IceKori
    {

        public static GlobalConf Conf;
        public static Action<GlobalConf> DefineGlobal;
        public static void LoadGlobalConf()
        {
            var db = Resources.Load<GlobalConf>("GlobalConf");
            db.hideFlags = HideFlags.DontSaveInBuild;
            Conf = db;
        }

        public static string PrettifyPrint(string codes)
        {
            var prettifyCode = "";
            string[] strs = codes.Split('\n');
            int level = 0;
            for (var i = 0; i < strs.Length; i++)
            {
                var code = strs[i];
                if (code.Trim() == "" || code.Trim() == "DoNothing()") continue;
                if (code.Contains("}")) level -= 1;
                prettifyCode += code.PadLeft(level * 2 + code.Length) + "\n";
                if (code.Contains("{")) level += 1;
                
            }

            return prettifyCode;
        }

        private static void _DefineGlobal()
        {
            DefineGlobal(Conf);
        }

        public static void Init()
        {
            LoadGlobalConf();
            _DefineGlobal();
        }
    }
}
