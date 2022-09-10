using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class UITweenColor : UITweenBase
    {
        protected bool isStartingColorSet = false;

        [System.Serializable]
        public struct ColorChain
        {
            public bool fromCurrentColor;
            public Color startingColor;
            public Color endingColor;
            [Range(0, 100)]
            public float percentageOfDuration;
        }

        // Chain list
        public List<ColorChain> colorChains;

        public override void Tween()
        {
            base.Tween();
        }

        public override void TweenReturn()
        {
            base.TweenReturn();
        }

        protected override void NextTween()
        {
            if (!CheckForNextChain(colorChains.Count)) { return; }

            isStartingColorSet = false;

            // Set current chain data
            ColorChain currentChain = colorChains[chainIndex];

            // Move to next chain
            chainIndex++;

            if (currentChain.fromCurrentColor && !isStartingColorSet)
            {
                // Set starting color to current color
                currentChain.startingColor = targetImage.color;
                isStartingColorSet = true;
            }

            // Set starting Color
            targetImage.color = currentChain.startingColor;

            // Calculate duration
            chainDuration = GetChainDuration(currentChain.percentageOfDuration);

            // Tween
            LeanTween.color(targetRect, currentChain.endingColor, chainDuration)
                .setEase(tweenType)
                .setOnComplete(NextTween);
        }
    }
}
