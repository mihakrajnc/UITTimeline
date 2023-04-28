using UnityEditor;

namespace UITTimeline.Editor
{
    [CustomEditor(typeof(UITDisplayClip))]
    public class UITDisplayClipEditor : UnityEditor.Editor
    {
        private SerializedProperty display;

        private void OnEnable()
        {
            display = serializedObject.FindProperty("_template.Display");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(display);
            serializedObject.ApplyModifiedProperties();
        }
    }
}