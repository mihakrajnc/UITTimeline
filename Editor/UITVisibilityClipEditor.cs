using UnityEditor;

namespace UITTimeline.Editor
{
    [CustomEditor(typeof(UITVisibilityClip))]
    public class UITVisibilityClipEditor : UnityEditor.Editor
    {
        private SerializedProperty visible;

        private void OnEnable()
        {
            visible = serializedObject.FindProperty("_template.Visible");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(visible);
            serializedObject.ApplyModifiedProperties();
        }
    }
}