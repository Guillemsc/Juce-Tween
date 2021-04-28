namespace Juce.Tween
{
    public interface ISequenceTween : ITween
    {
        void Append(ITween tween);
        void Join(ITween tween);
    }
}
