using UnityEngine;

namespace Mako.ScriptableVariables
{
    [CreateAssetMenu(menuName = "ScriptableVariables/Bool")]
    public class BoolVariable : ScriptableVariable<bool> { }
    
    [System.Serializable]
    public class BoolReference : VariableReference<bool, BoolVariable>
    {
        public BoolReference() { }

        public BoolReference(bool value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
    }
}