using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class UITweenPosition : UITweenBase
    {
        protected bool isStartingPositionSet = false;

        [System.Serializable]
        public struct PositionChain
        {
            public bool fromCurrentPosition;
            public bool usePositionChange;
            public Vector3 startingPosition;
            public Vector3 endingPosition;
            public Vector3 positionChange;
            public bool isStartingPositionSet;
            public bool isEndingPositionSet;
            [Range(0, 100)]
            public float percentageOfDuration;

            public void StartingPositionSet()
            {
                isStartingPositionSet = true;
            }
        }

        public List<PositionChain> positionChainList;

        public override void Tween()
        {
            base.Tween();
        }

        protected override void NextTween()
        {
            if (!CheckForNextChain(positionChainList.Count)) { return; }

            positionChainList[chainIndex].StartingPositionSet();

            isStartingPositionSet = false;

            // Set current chain data
            PositionChain currentChain = positionChainList[chainIndex];



            //if (currentChain.fromCurrentPosition && !isStartingPositionSet)
            //{
            //    // Set starting position to current position
            //    currentChain.startingPosition = targetRect.anchoredPosition;
            //    isStartingPositionSet = true;
            //}

            if (currentChain.fromCurrentPosition && !currentChain.isStartingPositionSet)
            {
                currentChain.startingPosition = targetRect.anchoredPosition;
                currentChain.StartingPositionSet();
            }

            // Set to starting position
            targetRect.anchoredPosition = currentChain.startingPosition;

            if (currentChain.usePositionChange && !currentChain.isEndingPositionSet)
            {
                // Set ending position
                currentChain.endingPosition = (Vector3)targetRect.anchoredPosition + currentChain.positionChange;
                currentChain.isEndingPositionSet = true;
            }

            // Calculate duration
            chainDuration = GetChainDuration(currentChain.percentageOfDuration);

            positionChainList[chainIndex] = currentChain;

            // Move to next chain
            chainIndex++;

            tDescr = LeanTween.move(targetRect, currentChain.endingPosition, chainDuration)
                .setEase(tweenType)
                .setOnComplete(NextTween);
        }
    }
}
