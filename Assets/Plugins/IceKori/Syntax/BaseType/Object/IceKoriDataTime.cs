using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    [System.Serializable]
    public class IceKoriDataTime : IceKoriBaseType
    {
        /// <summary>
        /// 原始值。
        /// </summary>
        [HideInEditorMode]
        public DateTime Value
        {
            get
            {
                if (_value != null)
                {
                    return (DateTime) _value;
                }
                else
                {
                    return new DateTime(Year, Moth, Day, Hour, Minute, Second);
                }
            }
        }

        private DateTime? _value;

        /// <summary>年份</summary>
        public int Year;
        /// <summary>月份</summary>
        [Range(1, 12)]
        public int Moth;
        /// <summary>天数</summary>
        [Range(0, 31)]
        public int Day;
        /// <summary>小时</summary>
        [Range(0, 23)]
        public int Hour;
        /// <summary>分钟</summary>
        [Range(0, 59)]
        public int Minute;
        /// <summary>秒数</summary>
        [Range(0, 59)]
        public int Second;

        /// <summary>
        /// IceKori 的 DataTime 对象。是 System.DateTime 对象的装箱。
        /// </summary>
        public IceKoriDataTime()
        {
            Reducible = false;
        }

        /// <summary>
        /// IceKori 的 DataTime 对象。是 System.DateTime 对象的装箱。
        /// <param name="value">DataTime 对象</param>
        /// </summary>
        public IceKoriDataTime(DateTime value)
        {
            Reducible = false;
            _value = value;
        }

        public override object Unbox()
        {
            return Value;
        }

        public override string ToString()
        {
            return $"<DataTime Day:{Value.Day}, Hour:{Value.Hour}, Minute:{Value.Minute}, Second:{Value.Second}>";
        }
    }
}
