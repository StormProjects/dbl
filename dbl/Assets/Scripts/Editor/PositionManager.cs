using UnityEngine;
using UnityEditor;


public class PositionManager : MonoBehaviour {
	
	[MenuItem("Assets/Create/PositionManager")] // Define a menu option in the editor to create the new asset
	
	public static void CreateAsset() {
	
		ScriptingObjects positionManager = ScriptableObject.CreateInstance<ScriptingObjects>(); // Create a new instance of our scriptable object
		
		AssetDatabase.CreateAsset(positionManager, "Assets/newPositionManager.asset"); // Create a .asset file for our new object and save it
		AssetDatabase.SaveAssets();
		
		EditorUtility.FocusProjectWindow(); // Switch the inspector to our new object
		Selection.activeObject = positionManager;
	}

	public static PositionManager ReadPositionsFromAsset(string Name) {
		string path = "/";
		object o = Resources.Load(path + Name);
		PositionManager retrievedPositions = (PositionManager)o;
		return retrievedPositions;
	}
}
