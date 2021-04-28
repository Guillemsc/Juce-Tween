﻿using System.Collections.Generic;

namespace Juce.Tween.Repositories
{
    public class SequenceTweenTweenRepository
    {
        private readonly List<Tween> tweens = new List<Tween>();

        private bool creatingGroupTween;

        public IReadOnlyList<Tween> Tweens => tweens;

        public void Append(Tween tween)
        {
            creatingGroupTween = false;

            tweens.Add(tween);
        }

        public void Join(Tween tween)
        {
            if(tweens.Count == 0)
            {
                Append(tween);

                return;
            }

            if(creatingGroupTween)
            {
                GroupTween groupTween = (GroupTween)tweens[tweens.Count - 1];

                groupTween.Add(tween);

                return;
            }

            creatingGroupTween = true;

            GroupTween newGroupTween = new GroupTween();

            newGroupTween.Add(tween);

            tweens.Add(newGroupTween);
        }
    }
}
