using Juce.Tween.Easing;
using Juce.Tween.Repositories;
using Juce.Tween.Utils;
using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class SequenceTween : Tween, ISequenceTween
    {
        private readonly SequenceTweenTweenRepository tweenRepository = new SequenceTweenTweenRepository();
        private readonly List<Tween> playingTweens = new List<Tween>();

        public override void OnTimeScaleChanges(float timeScale)
        {
            foreach (Tween tween in tweenRepository.Tweens)
            {
                tween.OnTimeScaleChanges(timeScale);
            }
        }

        public override void OnEaseDelegateChanges(EaseDelegate easeFunction)
        {
            foreach (Tween tween in tweenRepository.Tweens)
            {
                tween.OnEaseDelegateChanges(easeFunction);
            }

            EaseFunction = easeFunction;
        }

        public override void OnLoopFinished(LoopResetMode loopResetMode)
        {
            for (int i = tweenRepository.Tweens.Count - 1; i >= 0; --i)
            {
                Tween tween = tweenRepository.Tweens[i];

                tween.OnLoopFinished(loopResetMode);
            }

            StartTweens();

            MarkLoop();
        }

        public override float OnGetDuration()
        {
            float totalDuration = 0.0f;

            foreach (Tween tween in tweenRepository.Tweens)
            {
                totalDuration += tween.GetDuration();
            }

            return totalDuration;
        }

        public override float OnGetElapsed()
        {
            float totalDuration = 0.0f;

            foreach (Tween tween in tweenRepository.Tweens)
            {
                totalDuration += tween.GetElapsed();
            }

            return totalDuration;
        }

        public override int OnGetTweensCount()
        {
            int totalTweens = 1;

            foreach (Tween tween in tweenRepository.Tweens)
            {
                totalTweens += tween.GetTweensCount();
            }

            return totalTweens;
        }

        public override int OnGetPlayingTweensCount()
        {
            if (!IsPlaying)
            {
                return 0;
            }

            int totalTweens = 1;

            foreach (Tween tween in tweenRepository.Tweens)
            {
                totalTweens += tween.OnGetPlayingTweensCount();
            }

            return totalTweens;
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
            if(playingTweens.Count == 0)
            {
                MarkCompleted(canLoop: true);

                return;
            }

            Tween tween = playingTweens[0];

            tween.Update();

            if(tween.IsPlaying)
            {
                return;
            }

            playingTweens.RemoveAt(0);

            if (playingTweens.Count > 0)
            {
                Tween nextTween = playingTweens[0];

                nextTween.Start();
            }
            else
            {
                Update();
            }
        }

        public override void Complete()
        {
            if (!IsPlaying)
            {
                Start();
            }

            foreach (Tween tween in playingTweens)
            {
                tween.Complete();
            }

            playingTweens.Clear();

            MarkCompleted(canLoop: false);
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

            for (int i = tweenRepository.Tweens.Count - 1; i >= 0; --i)
            {
                Tween tween = tweenRepository.Tweens[i];

                tween.Reset();
            }

            MarkReset(); 
        }

        public void Append(ITween tween)
        {
            Tween castedTween = tween as Tween;

            if (castedTween == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(Append)} a null {nameof(Tween)} on {nameof(SequenceTween)}");
            }

            bool canAdd = TweenUtils.CanAddTween(this, tween);

            if(!canAdd)
            {
                return;
            }

            tweenRepository.Append(castedTween);

            castedTween.IsNested = true;
        }

        public void Join(ITween tween)
        {
            Tween castedTween = tween as Tween;

            if (castedTween == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(Join)} a null {nameof(Tween)} on {nameof(SequenceTween)}");
            }

            bool canAdd = TweenUtils.CanAddTween(this, tween);

            if (!canAdd)
            {
                return;
            }

            tweenRepository.Join(castedTween);

            castedTween.IsNested = true;
        }

        private void StartTweens()
        {
            playingTweens.Clear();
            playingTweens.AddRange(tweenRepository.Tweens);

            for (int i = playingTweens.Count - 1; i >= 0; --i)
            {
                Tween tween = playingTweens[i];

                if (i == 0)
                {
                    tween.Start();
                }
            }

            if (playingTweens.Count == 0)
            {
                MarkCompleted(canLoop: true);
            }
        }

        public void AppendCallback(Action callback)
        {
            Append(new CallbackTween(callback));
        }

        public void JoinCallback(Action callback)
        {
            Join(new CallbackTween(callback));
        }

        public void AppendResetableCallback(Action callback, Action reset)
        {
            Append(new ResetableCallbackTween(callback, reset));
        }

        public void JoinResetableCallback(Action callback, Action reset)
        {
            Join(new ResetableCallbackTween(callback, reset));
        }
    }
}
