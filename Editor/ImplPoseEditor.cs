using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ImplPose))]
public class ImplPoseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ImplPose poser = (ImplPose)target;
        if (GUILayout.Button("Apply T-Pose"))
        {
            poser.Initialize();
            EditorUtility.SetDirty(poser);
            // Mark all bones as dirty so their transforms are saved
            var bonesField = typeof(ImplPose).GetField("_bones", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var bones = bonesField.GetValue(poser) as List<Transform>;
            if (bones != null)
                foreach (var bone in bones) 
                    if (bone != null) EditorUtility.SetDirty(bone);
        }
    }
}