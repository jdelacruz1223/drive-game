using UnityEngine;

// Scriptable script for future levels.
// Every level that is created will instantiate this script. The levels will then be used.
// Should work because each level will be using the exact same things (assets, prefabs, etc.),
// with the only thing changing being difficulty (for now).

// Second Theory: Dynamically create each level. Use premade scriptable_object to 

[CreateAssetMenu(fileName = "TestScriptable", menuName = "Scriptable Objects/TestScriptable")]
public class TestScriptable : ScriptableObject
{
    // Array containing prefabs needed for each level.
    // Maybe split in the future?
    public string[] prefabNames = new string[] { };

    // Just a test parameter.
    public int difficultyLevel;
}
