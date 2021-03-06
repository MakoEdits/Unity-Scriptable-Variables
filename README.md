## Unity-Scriptable-Events

Based on Ryan Hipple's Unite 2017 talk and demos.

Full credit to him and his team for the concept, initial implementations and philosophy.

[Original Demonstration Repo](https://github.com/roboryantron/Unite2017)

[Unite Austin 2017 - Game Architecture with Scriptable Objects](https://youtu.be/raQ3iHhE_Kk)



## Description

Scriptable Variables decouple variable values so that variables can be used in multiple places with the same reference.



## Installation

**To install this package:**

* Open the Unity Package Manager under Window > Package Manager.
* Click the add + button in the status bar.
* Select **Add package from git URL.**
* Enter: [https://github.com/MakoEdits/Unity-Scriptable-Variables.git](https://github.com/MakoEdits/Unity-Scriptable-Variables.git)
* Click **Add.**



## Usage

### Scriptable Variable

* Create new ScriptableVariable under Create > ScriptableVariables.

### Using Scriptable Variables

* Create a new ScriptableVariable.
* Add a related Variable field in a script (e.g. FloatVariable for float ScriptableVariable).
* Drag and drop new ScriptableVariable into your new field.

*e.g.*

**MyClass.cs**

```cs
using Mako.ScriptableVariables;

public class MyClass : MonoBehaviour
{
	public FloatVariable myFloat;
	public FloatVariable otherFloat;

	void Start()
	{
		// Read Value
		Debug.Log(myFloat.Value);


		// Set Value
		myFloat.SetValue(5f);

		Debug.Log(myFloat.Value);


		// Copy value from another ScriptableVariable
		myFloat.SetValue(otherFloat);

		Debug.Log(myFloat.Value);


		// Change ScriptableVariable reference
		otherFloat.SetValue(10f);
		myFloat = otherFloat;

		Debug.Log(myFloat.Value);
	}
}
```

Editing the Value of a ScriptableVariable changes the Value in the asset, so the changes will persist outside of runtime.

Editing Values in runtime will reflect immediately, making this a good tool for itteration and testing.

### Some ScriptableVariables have extra modification methods, like Float and Int.

*e.g.*

**MyClass.cs**

```cs
using Mako.ScriptableVariables;

public class MyClass : MonoBehaviour
{
	public IntVariable myInt;
	public IntVariable otherInt;

	void Start()
	{
		// Add can take either {type} or {type}Variable
        myInt.Add(10);
        Debug.Log(myInt.Value);

        // Same with Multiply
        myInt.Multiply(otherInt);
        Debug.Log(myInt.Value);
	}
}
```

### Using VariableReferences

VariableReferences encompass ScriptableVariables to give you the option to swap between a constant value, or a ScriptableVariable.

They offer a simple way to change your mind about how you want to implement a variable.

* Create a new ScriptableVariable.
* Add a related Reference field in a script (e.g. FloatReference for Float ScriptableVariable).
* Click on the three dots in the Inspector to swap between a constant value and a ScriptableVariable.
* Drag and drop new ScriptableVariable into your new field, if you want to use a ScriptableVariable.

*e.g.*

**MyClass.cs**

```cs
using Mako.ScriptableVariables;

public class MyClass : MonoBehaviour
{
    public FloatReference myReference;
    public FloatReference otherReference;

    void Start()
    {
    	// Set constant value, set to return constant
        myReference.ConstantValue = 5f;
        myReference.UseConstant = true;

        Debug.Log(myReference.Value);


        // Set to new reference with constant value
        myReference = new FloatReference(10f);

        Debug.Log(myReference.Value);
        

        // Set to new reference and copy variable reference to new reference
        myReference = new FloatReference();
        myReference.Variable = otherReference.Variable;
        myReference.UseConstant = false;

        Debug.Log(myReference.Value);


        // Instantiate new Scriptable instance, set value, and set reference variable to new instance
        var newVariable = (FloatVariable)ScriptableObject.CreateInstance(typeof(FloatVariable));
        newVariable.SetValue(20f);

        myReference.Variable = newVariable;
        myReference.UseConstant = false;

        Debug.Log(myReference.Value);
    }
}
```



## Extending Functionality

### Making new basic ScriptableVariable types

* Create a new script along the lines of the following:

*Ensure that the name of the script is the same as the class that creates the Variable.gameEvent*

*because it will create a ScriptableObject.*

```cs
using UnityEngine;

using Mako.ScriptableVariables;

[CreateAssetMenu(menuName = "ScriptableVariables/{type}")]
public class {type}Variable : ScriptableVariable<{type}>
{ }
```

*e.g.*

**ColorVariable.cs**

```cs
using UnityEngine;

using Mako.ScriptableVariables;

[CreateAssetMenu(menuName = "ScriptableVariables/Color")]
public class ColorVariable : ScriptableVariable<Color>
{ }
```

New ScriptableVariables won't be added to the CustomPropertyDrawer automatically.

### Making new ScriptableVariable types with modifier methods

Modifier methods will only work if the type inherently allows such modifications.

These are just extensions of the ScriptableVariable's functionality, so anything could be put in here depending on the type's functionality.

* Create a new script along the lines of the following:

*Ensure that the name of the script is the same as the class that creates the Variable.gameEvent*

*because it will create a ScriptableObject.*

```cs
using UnityEngine;

using Mako.ScriptableVariables;

[CreateAssetMenu(menuName = "ScriptableVariables/{type}")]
public class {type}Variable : ScriptableVariable<{type}>
{
    public void Add({type} amount)
    {
        Value += amount;
    }

    public void Add({type}Variable amount)
    {
        Value += amount.Value;
    }

    public void Multiply({type} amount)
    {
        Value += amount;
    }

    public void Multiply({type}Variable amount)
    {
        Value += amount.Value;
    }
}
```

### Making new VariableReference types

VariableReference declarations can be put anywhere inside your project.

```cs
using Mako.ScriptableVariables;

[System.Serializable]
public class {type}Reference : VariableReference<{type}, {type}Variable>
{
    public {type}Reference()
    { }

    public {type}Reference({type} value)
    {
        UseConstant = true;
        ConstantValue = value;
    }
}
```

*e.g.*

```cs
using Mako.ScriptableVariables;

[System.Serializable]
public class ColorReference : VariableReference<Color, ColorVariable>
{
    public ColorReference()
    { }

    public ColorReference(Color value)
    {
        UseConstant = true;
        ConstantValue = value;
    }
}
```

### Extending VariableReferenceDrawer

The custom property drawer for VariableReferences is designed for values that take up single lines, so things like lists or arrays will not draw properly, so it's advised against.

The typeof must be a subclass of VariableReference.

```cs
using UnityEditor;
using Mako.ScriptableVariables;

[CustomPropertyDrawer(typeof({type}Reference))]
public class ExtendedReferenceDrawer : VariableReferenceDrawer
{ }
```

*e.g.*

```cs
using UnityEditor;
using Mako.ScriptableVariables;

[CustomPropertyDrawer(typeof(ColorReference))]
public class ExtendedReferenceDrawer : VariableReferenceDrawer
{ }
```



## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.



## License
[MIT](https://choosealicense.com/licenses/mit/)