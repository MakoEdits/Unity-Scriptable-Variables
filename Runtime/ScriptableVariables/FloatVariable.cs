using UnityEngine;

namespace Mako.ScriptableVariables
{
    [CreateAssetMenu(menuName = "ScriptableVariables/Float")]
    public class FloatVariable : ScriptableVariable<float>
    {
        public void Add(float amount)
        {
            Value += amount;
        }

        public void Add(FloatVariable amount)
        {
            Value += amount.Value;
        }
        
        public void Multiply(float amount)
        {
            Value *= amount;
        }

        public void Multiply(FloatVariable amount)
        {
            Value *= amount.Value;
        }
    }
    
    [System.Serializable]
    public class FloatReference : VariableReference<float, FloatVariable>
    {
        public FloatReference()
        { }

        public FloatReference(float value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
    }
}