using Assets.Plugins.IceKori.Common;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Expression
{  
    [PageSlider]
    [System.Serializable]
    public class ArrayGet : BaseExpression
    {
        [OnValueChanged("OnSource")]
        public BaseExpression Source;
        public int Index;
        
        public ArrayGet()
        {
            Reducible = true;
        }

        public ArrayGet(BaseExpression source, int index)
        {
            Reducible = true;
            Source = source;
            Index = index;
        }

        public override string ToString()
        {
            return $"{Source}[{Index}]";
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (Source.Reducible) return new ArrayGet(Source.Reduce(env), Index);
            if (Source.ID == BaseError.Error)
            {
                return Source;
            }
            return ((IceKoriArray)Source).Value[Index];
        }
        
#if UNITY_EDITOR
        private void OnSource()
        {
            if (Source.ID != IceKoriBaseType.Array && !(Source is VariableGet) && !(Source is GlobalVariableGet))
            {
                Source = null;
            }
        }
#endif
        
    }
}