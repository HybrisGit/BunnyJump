using UnityEngine;
using System.Collections;
using UnityEditor;


  [CustomEditor(typeof(BunnyController))]
  public class NinjaControllerEditor : Editor {

    private bool importExportFoldout = false;

    public override void OnInspectorGUI() {

      var ninjaController = target as BunnyController;

      DrawDefaultInspector();

      importExportFoldout = EditorGUILayout.Foldout(importExportFoldout, "Import/Export Physics Params");

      if(importExportFoldout == true) {
        string jsonString = JsonUtility.ToJson(ninjaController.PhysicsParams);
        jsonString = EditorGUILayout.TextField("Physics Params Json", jsonString);

        try {
          var physicsParams = JsonUtility.FromJson<PhysicsParams>(jsonString);
          ninjaController.PhysicsParams = physicsParams;
        } catch(System.Exception e) {
          Debug.LogError(e.Message);
        }
      }
    }
  }

