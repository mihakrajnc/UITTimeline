using UnityEditor;

namespace UITTimeline.Editor
{
    [CustomEditor(typeof(UITBackgroundTintClip))]
    public class UITBackgroundTintClipEditor : UnityEditor.Editor
    {
        private SerializedProperty color;

        void OnEnable()
        {
            color = serializedObject.FindProperty("_template.Color");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(color);
            serializedObject.ApplyModifiedProperties();
        }
    }
}