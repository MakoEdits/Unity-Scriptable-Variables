using UnityEngine;

namespace Mako.ScriptableVariables
{
    [CreateAssetMenu(menuName = "ScriptableVariables/Vector2")]
    public class Vector2Variable : ScriptableVariable<Vector2>
    { }
    
    [System.Serializable]
    public class Vector2Reference : VariableReference<Vector2, Vector2Variable>
    {
        public Vector2Reference() { }

        public Vector2Reference(Vector2 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
    }
}