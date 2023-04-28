using UnityEditor;

namespace UITTimeline.Editor
{
    [CustomEditor(typeof(UITPositionClip))]
    public class UITPositionClipEditor : UnityEditor.Editor
    {
        private SerializedProperty position;

        private void OnEnable()
        {
            position = serializedObject.FindProperty("_template.Position");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(position);
            serializedObject.ApplyModifiedProperties();
        }
    }
}