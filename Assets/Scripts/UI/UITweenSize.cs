using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class UITweenSize : UITweenBase
    {
        protected bool isStartingSizeSet = false;

        [System.Serializable]
        public struct SizeChain
        {
            public bool fromCurrentSize;
            public Vector2 startingSize;
            public Vector2 endingSize;
            [Range(0f, 100f)]
            public float percentageOfDuration;
        }

        public List<SizeChain> sizeChainList = new List<SizeChain>();

        public override void Tween()
        {
            base.Tween();
        }

        protected override void NextTween()
        {
            base.NextTween();

            if (!CheckForNextChain(sizeChainList.Count)) { return; }

            isStartingSizeSet = false;

            // Set current chain data
            SizeChain currentChain = sizeChainList[chainIndex];

            // Move to next chain
            chainIndex++;

            if (currentChain.fromCurrentSize && !isStartingSizeSet)
            {
                // Set starting size to current size
                currentChain.startingSize = targetRect.sizeDelta;
                isStartingSizeSet = true;
            }

            // Set starting size
            targetRect.sizeDelta = currentChain.startingSize;

            // Calculate duration
            chainDuration = GetChainDuration(currentChain.percentageOfDuration);

            LeanTween.size(targetRect, currentChain.endingSize, chainDuration)
                .setEase(tweenType)
                .setOnComplete(NextTween);
        }
    }
}
