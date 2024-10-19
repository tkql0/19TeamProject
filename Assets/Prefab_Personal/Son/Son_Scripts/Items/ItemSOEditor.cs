using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemSO))]
public class ItemSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemSO itemSO = (ItemSO)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("itemType"));
        
        switch (itemSO.itemType)
        {
            case ItemType.Ball:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("ballType"), new GUIContent("Ball Item Type"));
                break;

            case ItemType.Paddle:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("paddleType"), new GUIContent("Paddle Item Type"));
                break;
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("value"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("SetLayer"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("itemSprite"));

        serializedObject.ApplyModifiedProperties();
    }
}
