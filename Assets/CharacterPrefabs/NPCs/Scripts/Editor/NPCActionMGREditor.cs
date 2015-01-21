using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(NPCActionMGR))]
public class NPCActionMGREditor : Editor {
	
	
	public override void OnInspectorGUI(){
		NPCActionMGR manager = target as NPCActionMGR;
		DrawDefaultInspector();
		
		if (GUILayout.Button("Create New Action")){
			manager.create_npc_action();
		}
	}
}
