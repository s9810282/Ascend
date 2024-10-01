using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SkillData))]
public class SkillDataEditor : Editor
{
    SkillData skillData;

    private void OnEnable()
    {
        skillData = (SkillData)target;
    }
    

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
        
        EditorGUILayout.Space();

        skillData.skillImage  = (Sprite)EditorGUILayout.ObjectField("Sprite", skillData.skillImage, typeof(Sprite), true);

        EditorGUILayout.Space();

        base.OnInspectorGUI();

        EditorGUILayout.EndVertical();
    }
}