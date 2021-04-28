using Juce.Tween.Easing;
using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class GroupTween : Tween
    {
        private readonly List<Tween> tweens = new List<Tween>();
        private readonly List<Tween> playingTweens = new List<Tween>();

        public override void OnTimeScaleChanges(float timeScale)
        {
            foreach (Tween tween in tweens)
            {
                tween.OnTimeScaleChanges(timeScale);
            }
        }

        public override void OnEaseDelegateChanges(EaseDelegate easeFunction)
        {
            foreach (Tween tween in tweens)
            {
                tween.OnEaseDelegateChanges(easeFunction);
            }
        }

        public override void OnLoopFinished(LoopResetMode loopResetMode)
        {
            for (int i = tweens.Count - 1; i >= 0; --i)
            {
                Tween tween = tweens[i];

                tween.OnLoopFinished(loopResetMode);
            }

            StartTweens();
        }

        public override void Start()
        {
            if (IsPlaying)
            {
                Kill();
            }

            MarkStart();

            StartTweens();
        }

        public override void Update()
        {
            for (int i = playingTweens.Count - 1; i >= 0; --i)
            {
                Tween tween = playingTweens[i];

                tween.Update();

                if (!tween.IsPlaying)
                {
                    playingTweens.RemoveAt(i);
                }
            }

            if (playingTweens.Count == 0)
            {
                MarkFinish(canLoop: true);
            }
        }

        public override void Complete()
        {
            if(!IsPlaying)
            {
                Start();
            }

            foreach(Tween tween in playingTweens)
            {
                tween.Complete();
            }

            playingTweens.Clear();

            MarkFinish(canLoop: false);
        }

        public override void Kill()
        {
            if (!IsPlaying)
            {
                return;
            }

            foreach (Tween tween in playingTweens)
            {
                tween.Kill();
            }

            playingTweens.Clear();

            MarkKilled();
        }

        public override void Reset()
        {
            Kill();

            for (int i = tweens.Count - 1; i >= 0; --i)
            {
                Tween tween = tweens[i];

                tween.Reset();
            }

            MarkReset();
        }

        public void Add(ITween tween)
        {
            Tween castedTween = tween as Tween;

            if(castedTween == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(Add)} a null {nameof(Tween)} on {nameof(GroupTween)}");
            }

            if(IsPlaying)
            {
                return;
            }

            if(tween.IsPlaying)
            {
                return;
            }

            if(castedTween.IsNested)
            {
                return;
            }

            castedTween.IsNested = true;

            tweens.Add(castedTween);
        }

        private void StartTweens()
        {
            playingTweens.Clear();
            playingTweens.AddRange(tweens);

            for (int i = playingTweens.Count - 1; i >= 0; --i)
            {
                Tween tween = playingTweens[i];

                tween.SetEase(EaseFunction);

                tween.Start();

                if (!tween.IsPlaying)
                {
                    playingTweens.RemoveAt(i);
                }
            }

            if (playingTweens.Count == 0)
            {
                MarkFinish(canLoop: true);
            }
        }
    }
}
