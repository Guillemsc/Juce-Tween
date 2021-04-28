using Juce.Utils.Singletons;
using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class JuceTween : AutoStartMonoSingleton<JuceTween>
    {
        private readonly List<Tween> aliveTweens = new List<Tween>();
        private readonly List<Tween> tweensToRemove = new List<Tween>();

        private float timeScale;

        public static float TimeScale
        {
            get { return Instance.timeScale; }
            set { Instance.timeScale = value; }
        }

        public static ISequenceTween Sequence()
        {
            return new SequenceTween();
        }

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            UpdateTweens();
        }

        private void Init()
        {
            timeScale = 1.0f;
        }

        public int GetAliveTweensCounts()
        {
            int aliveTweensCount = 0;

            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                //aliveTweensCount += aliveTweens[i].GetNestedTweenChildsCount() + 1;
            }

            return aliveTweensCount;
        }

        internal static void Add(Tween tween)
        {
            if (tween == null)
            {
                throw new ArgumentNullException($"Tried to play a null {nameof(Tween)} on {nameof(JuceTween)} instance");
            }

            if(tween.IsAlive)
            {
                Instance.TryStartTween(tween);

                return;
            }

            tween.IsAlive = true;

            Instance.aliveTweens.Add(tween);

            Instance.TryStartTween(tween);
        }

        private void TryStartTween(Tween tween)
        {
            if (!tween.IsPlaying)
            {
                tween.Start();
            }
        }

        private void UpdateTweens()
        {
            foreach(Tween tween in aliveTweens)
            {
                if(tween.IsPlaying && !tween.IsCompleted)
                {
                    tween.Update();
                }

                if(!tween.IsPlaying || tween.IsCompleted)
                {
                    tweensToRemove.Add(tween);
                }
            }

            foreach(Tween tween in tweensToRemove)
            {
                tween.IsAlive = false;

                aliveTweens.Remove(tween);
            }

            tweensToRemove.Clear();
        }
    }
}