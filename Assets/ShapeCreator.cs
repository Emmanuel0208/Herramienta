using UnityEditor;
using UnityEngine;

public class ShapeCreator : EditorWindow
{
    GameObject cubePrefab, spherePrefab, capsulePrefab;

    [MenuItem("Window/Shape Creator")]
    private static void ShowWindow()
    {
        GetWindow<ShapeCreator>("Shape Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Prefabs", EditorStyles.boldLabel);

        cubePrefab = (GameObject)EditorGUILayout.ObjectField("Cube Prefab", cubePrefab, typeof(GameObject), false);
        spherePrefab = (GameObject)EditorGUILayout.ObjectField("Sphere Prefab", spherePrefab, typeof(GameObject), false);
        capsulePrefab = (GameObject)EditorGUILayout.ObjectField("Capsule Prefab", capsulePrefab, typeof(GameObject), false);

        if (GUILayout.Button("Create Cube"))
        {
            CreateShape(cubePrefab);
        }
        if (GUILayout.Button("Create Sphere"))
        {
            CreateShape(spherePrefab);
        }
        if (GUILayout.Button("Create Capsule"))
        {
            CreateShape(capsulePrefab);
        }
    }

    private void CreateShape(GameObject prefab)
    {
        if (prefab != null)
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab not assigned!");
        }
    }
}
