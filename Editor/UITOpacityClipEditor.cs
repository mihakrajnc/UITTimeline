using UnityEditor;

namespace UITTimeline.Editor
{
    [CustomEditor(typeof(UITOpacityClip))]
    public class UITOpacityClipEditor : UnityEditor.Editor
    {
        private SerializedProperty opacity;

        private void OnEnable()
        {
            opacity = serializedObject.FindProperty("_template.Opacity");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(opacity);
            serializedObject.ApplyModifiedProperties();
        }
    }
}