using UnityEditor;

namespace UITTimeline.Editor
{
    [CustomEditor(typeof(UITRotationClip))]
    public class UITRotationClipEditor : UnityEditor.Editor
    {
        private SerializedProperty rotation;

        private void OnEnable()
        {
            rotation = serializedObject.FindProperty("_template.Rotation");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(rotation);
            serializedObject.ApplyModifiedProperties();
        }
    }
}