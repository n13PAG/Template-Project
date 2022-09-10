using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class UITweenScale : UITweenBase
    {
        protected bool isStartingScaleSet = false;

        [System.Serializable]
        public struct ScaleChain
        {
            public bool fromCurrentScale;
            public Vector3 startingScale;
            public Vector3 endingScale;
            [Range(0, 100)]
            public float percentageOfDuration;
        }

        public List<ScaleChain> scaleChainList = new List<ScaleChain>();

        public override void Tween()
        {
            base.Tween();
        }

        protected override void NextTween()
        {
            if (!CheckForNextChain(scaleChainList.Count)) { return; }

            isStartingScaleSet = false;

            // Set current chain data
            ScaleChain currentChain = scaleChainList[chainIndex];

            // Move to next chain
            chainIndex++;

            if (currentChain.fromCurrentScale && !isStartingScaleSet)
            {
                // Set starting scale to current scale
                currentChain.startingScale = targetRect.localScale;
                isStartingScaleSet = true;
            }

            // Set starting scale
            targetRect.localScale = currentChain.startingScale;

            // Calculate duration
            chainDuration = GetChainDuration(currentChain.percentageOfDuration);

            LeanTween.scale(targetRect, currentChain.endingScale, chainDuration)
                .setEase(tweenType)
                .setOnComplete(NextTween);    
        }

        public override void TweenReturn()
        {
            base.TweenReturn();
        }

      
    }

    
}
