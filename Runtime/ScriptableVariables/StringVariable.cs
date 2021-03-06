using UnityEngine;

namespace Mako.ScriptableVariables
{
    [CreateAssetMenu(menuName = "ScriptableVariables/String")]
    public class StringVariable : ScriptableVariable<string> { }
    
    [System.Serializable]
    public class StringReference : VariableReference<string, StringVariable>
    {
        public StringReference() { }

        public StringReference(string value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
    }
}