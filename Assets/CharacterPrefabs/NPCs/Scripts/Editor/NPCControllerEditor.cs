using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(NPCController))]
public class NPCControllerEditor : Editor {
	
	
	public override void OnInspectorGUI(){
		NPCController controller = target as NPCController;
		DrawDefaultInspector();

		if (GUILayout.Button("Create Action MGR")){
			controller.create_action_mgr();
		}
	}
}
