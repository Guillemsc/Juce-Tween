#if JUCE_TEXT_MESH_PRO_EXTENSIONS

using Juce.Tween;
using Juce.Tween.Utils;
using TMPro;
using UnityEngine;

public static class JuceTweenTextMeshProExtensions
{
    public static ITween TweenFontSize(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        return Tween.To(
            () => textMeshProUGUI.fontSize, 
            x => textMeshProUGUI.fontSize = x, 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenColor(this TextMeshProUGUI textMeshProUGUI, Color to, float duration)
    {
        return Tween.To(
            () => textMeshProUGUI.color, 
            x => textMeshProUGUI.color = x, 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenColorAlpha(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => textMeshProUGUI.color.a, 
            x => textMeshProUGUI.color = ColorUtils.ChangeAlpha(textMeshProUGUI.color, x), 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenFaceColor(this TextMeshProUGUI textMeshProUGUI, Color to, float duration)
    {
        return Tween.To(
            () => textMeshProUGUI.faceColor, 
            x => textMeshProUGUI.faceColor = x, 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenFaceColorAlpha(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => textMeshProUGUI.faceColor.a, 
            x => textMeshProUGUI.faceColor = ColorUtils.ChangeAlpha(textMeshProUGUI.faceColor, x), 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenMaxVisibleCharacters(this TextMeshProUGUI textMeshProUGUI, int to, float duration)
    {
        return Tween.To(
            () => textMeshProUGUI.maxVisibleCharacters, 
            x => textMeshProUGUI.maxVisibleCharacters = x, 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenCharacterSpacing(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        return Tween.To(
            () => textMeshProUGUI.characterSpacing, 
            x => textMeshProUGUI.characterSpacing = x, 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenWordSpacing(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        return Tween.To(
            () => textMeshProUGUI.wordSpacing, 
            x => textMeshProUGUI.wordSpacing = x, 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenLineSpacing(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        return Tween.To(
            () => textMeshProUGUI.lineSpacing, 
            x => textMeshProUGUI.lineSpacing = x, 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }

    public static ITween TweenParagraphSpacingSpacing(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        return Tween.To(
            () => textMeshProUGUI.paragraphSpacing, 
            x => textMeshProUGUI.paragraphSpacing = x, 
            () => to, 
            duration,
            () => textMeshProUGUI != null
            );
    }
}

#endif