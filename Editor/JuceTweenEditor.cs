using UnityEditor;

namespace Juce.Tween
{
    [CustomEditor(typeof(JuceTween))]
    public class JuceTweenEditor : Editor
    {
        private JuceTween CustomTarget => (JuceTween)target;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField($"Juce Tween", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.LabelField($"Alive tweens: {CustomTarget.GetAliveTweensCounts()}", EditorStyles.boldLabel);
                EditorGUILayout.LabelField($"Playing tweens: {CustomTarget.GetPlayingTweensCounts()}", EditorStyles.boldLabel);
                EditorGUILayout.LabelField($"Update milliseconds: {CustomTarget.UpdateMilliseconds}", EditorStyles.boldLabel);

            }

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.LabelField($"Time Scale: {JuceTween.TimeScale}", EditorStyles.boldLabel);
            }

            Repaint();
        }
    }
}