using UnityEngine;

namespace Mako.ScriptableVariables
{
	/// <summary>
	/// Create ScriptableObjects containing values of type T
	/// </summary>
	/// <typeparam name="T">Base type of variable</typeparam>
	
	[System.Serializable]
	public abstract class ScriptableVariable<T> : ScriptableObject
	{
		#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
		#endif
		
		public T Value;

		public void SetValue(T value)
		{
			Value = value;
		}

		public void SetValue(ScriptableVariable<T> value)
		{
			Value = value.Value;
		}
	}
}