using System;

namespace Mako.ScriptableVariables
{
	/// <summary>
	/// Create reference wrapper for ScriptableVariable to allow for swapping between constant value or ScriptableObject value
	/// </summary>
	/// <remarks>
	///	Parameter V requires subclass of ScriptableVariable so that it can be serialized in Unity inspector
	/// </remarks>
	/// <typeparam name="T">Base type of following parameter</typeparam>
	/// <typeparam name="V">Subclass of ScriptableVariable with type T</typeparam>

	[Serializable]
	public abstract class VariableReference<T, V> where V : ScriptableVariable<T>
	{
		public bool UseConstant = true;
		public T ConstantValue;
		public V Variable;
		
		public T Value => UseConstant ? ConstantValue : Variable.Value;

		public static implicit operator T(VariableReference<T, V> reference)
		{
			return reference.Value;
		}
	}
}