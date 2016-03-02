using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace API_TOOL
{

    
    // Custom Editor using SerializedProperties.
    // Automatic handling of multi-object editing, undo, and prefab overrides.
    [CustomEditor(typeof(BaseCharacter))]
    [CanEditMultipleObjects]

    public class BaseCharacterEditor : Editor
    {
        SerializedProperty headProp;
        SerializedProperty torsoProp;
        SerializedProperty leftArmProp;
        SerializedProperty rightArmProp;
        SerializedProperty leftLegProp;
        SerializedProperty rightLegProp;
        SerializedProperty multiplier;
        bool defaultMultiplier = false;

        GameObject currentGO = Selection.activeGameObject;

        void OnEnable()
        {
            headProp = serializedObject.FindProperty("EZ_BodyHead");
            torsoProp = serializedObject.FindProperty("EZ_BodyTorso");
            leftArmProp = serializedObject.FindProperty("EZ_BodyLeftArm");
            rightArmProp = serializedObject.FindProperty("EZ_BodyRightArm");
            leftLegProp = serializedObject.FindProperty("EZ_BodyLeftLeg");
            rightLegProp = serializedObject.FindProperty("EZ_BodyRightLeg");
            multiplier = serializedObject.FindProperty("EZ_Multiplier");

            Debug.Log(defaultMultiplier);

            if (currentGO.GetComponent<BaseCharacter>().DefaultChoice == "Default")
            {
                /**/
                

                Debug.Log(currentGO);
                if (currentGO.GetComponent<BaseCharacter>().DefaultChoice == "Default")
                {
                    Debug.Log("Default:  " + currentGO);
                }
                // Setup the SerializedProperties.
                //damageProp = serializedObject.FindProperty("damage");
                //armorProp = serializedObject.FindProperty("armor");
                //gunProp = serializedObject.FindProperty("gun");
            }
        }

        public override void OnInspectorGUI()
        {
            // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
            serializedObject.Update();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                EditorGUILayout.PropertyField(headProp);
                EditorGUILayout.PropertyField(torsoProp);
                EditorGUILayout.PropertyField(leftArmProp);
                EditorGUILayout.PropertyField(rightArmProp);
                EditorGUILayout.PropertyField(leftLegProp);
                EditorGUILayout.PropertyField(rightLegProp);
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();

            EditorGUILayout.BeginToggleGroup("Custom Multiplier", defaultMultiplier);
            {
                EditorGUILayout.PropertyField(multiplier);
            }
            EditorGUILayout.EndToggleGroup();

            // Show the custom GUI controls.
            /*EditorGUILayout.IntSlider(damageProp, 0, 100, new GUIContent("Damage"));

            // Only show the damage progress bar if all the objects have the same damage value:
            if (!damageProp.hasMultipleDifferentValues)
                ProgressBar(damageProp.intValue / 100.0f, "Damage");

            EditorGUILayout.IntSlider(armorProp, 0, 100, new GUIContent("Armor"));

            // Only show the armor progress bar if all the objects have the same armor value:
            if (!armorProp.hasMultipleDifferentValues)
                ProgressBar(armorProp.intValue / 100.0f, "Armor");

            EditorGUILayout.PropertyField(gunProp, new GUIContent("Gun Object"));*/

            // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
            serializedObject.ApplyModifiedProperties();
        }

       
        // Custom GUILayout progress bar.
        void ProgressBar(float value, string label)
        {
            // Get a rect for the progress bar using the same margins as a textfield:
            Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(rect, value, label);
            EditorGUILayout.Space();
        }
    }
}