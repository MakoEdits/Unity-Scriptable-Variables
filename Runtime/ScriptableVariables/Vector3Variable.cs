using UnityEngine;

namespace Mako.ScriptableVariables
{
    [CreateAssetMenu(menuName = "ScriptableVariables/Vector3")]
    public class Vector3Variable : ScriptableVariable<Vector3>
    { }
    
    [System.Serializable]
    public class Vector3Reference : VariableReference<Vector3, Vector3Variable>
    {
        public Vector3Reference() { }

        public Vector3Reference(Vector3 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
    }
}