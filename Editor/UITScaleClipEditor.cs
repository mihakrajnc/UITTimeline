using UnityEditor;

namespace UITTimeline.Editor
{
    [CustomEditor(typeof(UITScaleClip))]
    public class UITScaleClipEditor : UnityEditor.Editor
    {
        private SerializedProperty scale;

        private void OnEnable()
        {
            scale = serializedObject.FindProperty("_template.Scale");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(scale);
            serializedObject.ApplyModifiedProperties();
        }
    }
}