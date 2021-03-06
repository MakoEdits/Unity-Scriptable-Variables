using UnityEngine;

namespace Mako.ScriptableVariables
{
    [CreateAssetMenu(menuName = "ScriptableVariables/Int")]
    public class IntVariable : ScriptableVariable<int>
    {
        public void Add(int amount)
        {
            Value += amount;
        }

        public void Add(IntVariable amount)
        {
            Value += amount.Value;
        }
                
        public void Multiply(int amount)
        {
            Value *= amount;
        }

        public void Multiply(IntVariable amount)
        {
            Value *= amount.Value;
        }
    }
    
    [System.Serializable]
    public class IntReference : VariableReference<int, IntVariable>
    {
        public IntReference() { }

        public IntReference(int value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
    }
}