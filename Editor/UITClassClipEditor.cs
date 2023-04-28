using UnityEditor;

namespace UITTimeline.Editor
{
    [CustomEditor(typeof(UITClassClip))]
    public class UITClassClipEditor : UnityEditor.Editor
    {
        private SerializedProperty className;

        void OnEnable()
        {
            className = serializedObject.FindProperty("_template.ClassName");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(className);
            serializedObject.ApplyModifiedProperties();
        }
    }
}