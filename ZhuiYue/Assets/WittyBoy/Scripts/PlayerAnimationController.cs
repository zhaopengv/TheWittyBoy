using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PlayerAnimationController : MonoBehaviour {

	SkeletonAnimation mSkeletonAnimation;
	Spine.AnimationState mAnimationState;
	const string blinkName = "blink";
	const string walkName = "walk";
	const string jumpName = "jump";
	const string climbName = "climb";
	const string idleName = "idle";

	// Use this for initialization
	void Start () {
		mSkeletonAnimation = gameObject.GetComponent<SkeletonAnimation> ();
		//mSkeletonAnimation.AnimationName = walkName;
		mAnimationState = mSkeletonAnimation.state;
		mAnimationState.SetAnimation (0, blinkName, true);
		mAnimationState.SetAnimation (1, walkName, true);

	}

	// Update is called once per frame
	void Update () {

	}
}
