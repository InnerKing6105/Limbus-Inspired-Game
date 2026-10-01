using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BattleTest))]
public class BattleTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BattleTest battleTest = (BattleTest)target;

        EditorGUILayout.Space();

        if (GUILayout.Button("Test Player Attack"))
        {
            battleTest.TestPlayerAttack();
        }
    }
}