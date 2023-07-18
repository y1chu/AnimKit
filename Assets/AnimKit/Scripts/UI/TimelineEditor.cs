//----------------------------------------------------------------------------------------
// TimelineEditor.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This custom editor script provides a custom inspector for the AnimationTimeline component.
//    It allows the user to add, delete, and modify timeline events in the editor.
//
// Usage:
//    1. Create a new C# script in the Editor folder of your project.
//    2. Copy and paste the code below into the script file.
//    3. Ensure that the AnimationTimeline script is located in the same project folder.
//    4. Save the script and return to the Unity editor.
//    5. The custom inspector will now be displayed for the AnimationTimeline component.
//
// Notes:
//    - This script should be placed in an Editor folder or a folder with the "Editor" in its name.
//    - The AnimationTimeline script must have a [Serializable] attribute for this editor to work.
//
//----------------------------------------------------------------------------------------
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AnimationTimeline))]
public class TimelineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AnimationTimeline timeline = (AnimationTimeline)target;

        for (int i = 0; i < timeline.timelineEvents.Count; i++)
        {
            EditorGUILayout.LabelField("Event Name: ", timeline.timelineEvents[i].eventName);
            EditorGUILayout.LabelField("Event Time: ", timeline.timelineEvents[i].eventTime.ToString());

            timeline.timelineEvents[i].targetScript = (MonoBehaviour)EditorGUILayout.ObjectField("Target Script", timeline.timelineEvents[i].targetScript, typeof(MonoBehaviour), true);
            timeline.timelineEvents[i].targetMethod = EditorGUILayout.TextField("Target Method", timeline.timelineEvents[i].targetMethod);

            if (GUILayout.Button("Delete Event"))
            {
                timeline.timelineEvents.RemoveAt(i);
            }
        }

        if (GUILayout.Button("Add Event"))
        {
            timeline.timelineEvents.Add(new TimelineEvent());
        }
    }
}
