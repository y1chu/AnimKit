using UnityEditor;
using UnityEngine;

public class TimelineDataEditorWindow : EditorWindow
{
    private TimelineData timelineData;
    private Vector2 scrollPosition;
    private string newAnimationId = string.Empty;
    
    // Placeholders for AnimationClipData parameters
    private AnimationClip newAnimationClip;
    private float newAnimationStartTime = 0f;
    private float newAnimationDuration = 0f;
    private bool newAnimationIsLooping = false; // Placeholder for animation looping

    [MenuItem("Window/TimelineData Editor")]
    public static void ShowWindow()
    {
        GetWindow<TimelineDataEditorWindow>("TimelineData Editor");
    }

    private void OnGUI()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        timelineData = (TimelineData)EditorGUILayout.ObjectField("Timeline Data", timelineData, typeof(TimelineData), false);

        if (timelineData != null)
        {
            SerializedObject serializedObject = new SerializedObject(timelineData);
            SerializedProperty animationListProperty = serializedObject.FindProperty("animations");
            EditorGUILayout.PropertyField(animationListProperty, true);
            serializedObject.ApplyModifiedProperties();

            GUILayout.Space(20);
            GUILayout.Label("Add New AnimationClipData", EditorStyles.boldLabel);

            newAnimationId = EditorGUILayout.TextField("Animation ID", newAnimationId);
            newAnimationClip = (AnimationClip)EditorGUILayout.ObjectField("Animation Clip", newAnimationClip, typeof(AnimationClip), false);
            newAnimationStartTime = EditorGUILayout.FloatField("Start Time", newAnimationStartTime);
            newAnimationDuration = EditorGUILayout.FloatField("Duration", newAnimationDuration);
            newAnimationIsLooping = EditorGUILayout.Toggle("Is Looping", newAnimationIsLooping); // Toggle for animation looping

            if (GUILayout.Button("Add AnimationClipData"))
            {
                AnimationClipData newAnimationClipData = ScriptableObject.CreateInstance<AnimationClipData>();
                newAnimationClipData.Init(newAnimationId, newAnimationClip, newAnimationStartTime, newAnimationDuration, newAnimationIsLooping);
                timelineData.AddAnimationClipData(newAnimationClipData);
            }

            if (GUILayout.Button("Clear All AnimationClipData"))
            {
                timelineData.ClearAnimations();
            }
        }

        if (GUILayout.Button("Create New TimelineData"))
        {
            timelineData = CreateInstance<TimelineData>();
            AssetDatabase.CreateAsset(timelineData, "Assets/NewTimelineData.asset");
            AssetDatabase.SaveAssets();
        }

        EditorGUILayout.EndScrollView();
    }
}
