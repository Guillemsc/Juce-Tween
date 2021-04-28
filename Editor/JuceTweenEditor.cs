using UnityEditor;

namespace Juce.Tween
{
    [CustomEditor(typeof(JuceTween))]
    public class JuceTweenEditor : Editor
    {
        private JuceTween CustomTarget => (JuceTween)target;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField($"Alive tweens: {CustomTarget.GetAliveTweensCounts()}", EditorStyles.boldLabel);
        }
    }
}