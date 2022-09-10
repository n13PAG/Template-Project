using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class UITweenRotation : UITweenBase
    {
        protected bool isStartingRotationSet = false;

        [System.Serializable]
        public struct RotationChain
        {
            public bool fromStartingRotation;
            public Vector3 startingAngles;
            public Vector3 rotationChange;
            public float percentageOfDuration;
        }

        public List<RotationChain> rotationChainList;

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
            base.NextTween();

            if (!CheckForNextChain(rotationChainList.Count)) { return; }

            isStartingRotationSet = false;

            // Set current chain data
            RotationChain currentChain = rotationChainList[chainIndex];

            // Move to next chain
            chainIndex++;

            if (currentChain.fromStartingRotation && !isStartingRotationSet)
            {
                // Set starting rotation to current rotation
                currentChain.startingAngles = targetRect.rotation.eulerAngles;
                isStartingRotationSet = true;
            }

            // Set starting rotation
            targetRect.rotation = Quaternion.Euler(currentChain.startingAngles);

            // Calculate chain duration
            chainDuration = GetChainDuration(currentChain.percentageOfDuration);

            // Set ending rotation
            Vector3 endingRotation = currentChain.startingAngles + currentChain.rotationChange;
            Debug.Log(endingRotation);

            LeanTween.rotateLocal(targetRect.gameObject, endingRotation, chainDuration)
                .setEase(tweenType)
                .setOnComplete(NextTween);
        }
    }
}
