using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PlayerAnimationController : MonoBehaviour {

	public SkeletonAnimation mSkeletonAnimation;
	Spine.AnimationState mAnimationState;
	const string blinkName = "blink";
	const string walkName = "walk";
	const string jumpName = "jump";
	const string climbName = "climb";
	const string idleName = "idle";


    // Use this for initialization

    string state = idleName;

  //  Spine.TrackEntry 
    
	void Start () {
		//mSkeletonAnimation = gameObject.GetComponent<SkeletonAnimation> ();
		//mSkeletonAnimation.AnimationName = walkName;
		mAnimationState = mSkeletonAnimation.state;
		mAnimationState.SetAnimation (0, blinkName, true);
		

	}

	// Update is called once per frame
	void Update () {

	}

    public void walk()
    {
//        print("PlayerAnimationController walk");


        //mAnimationState.SetAnimation(1, walkName, true);
        // mSkeletonAnimation.AnimationName = walkName;
        // if(mAnimationState.GetCurrent(1).)
		mAnimationState.TimeScale = 2f;


        //if (state != walkName)
        //{
        Spine.TrackEntry now = mAnimationState.GetCurrent(1);
        if (now != null &&now.animation != null && now.animation.name == walkName && !now.IsComplete)
        {
            //此时请动画正在执行。

        }
        else
        {
            Spine.TrackEntry entry = mAnimationState.SetAnimation(1, walkName, false);
        }

            

      //  print("entry is "+entry);
        //}
        

       // entry.

        state = walkName;
        
    }
    public void flip(bool b)
    {
       mSkeletonAnimation.skeleton.FlipX = b;

    }


    public void jump()
    {
		mAnimationState.TimeScale = 1f;
//        print("PlayerAnimationController jump");
        mAnimationState.SetAnimation(1, jumpName, false);
        //mSkeletonAnimation.AnimationName = jumpName;
        state = jumpName;
    }

    public void idle()
    {
        //print("PlayerAnimationController idle");
		mAnimationState.TimeScale = 1f;
        mAnimationState.SetAnimation(1, idleName, true);
       // mSkeletonAnimation.AnimationName = idleName;
       // state = idleName;
    }

    public void climb()
    {

        print("PlayerAnimationController climb");
		Spine.TrackEntry now = mAnimationState.GetCurrent(1);
		if (now != null && now.animation != null && now.animation.name == climbName && !now.IsComplete) {
			//此时请动画正在执行。

		} else {
			mAnimationState.SetAnimation (1, climbName, false);
			mAnimationState.TimeScale = 5f;
			//mSkeletonAnimation.AnimationName = climbName;
			state = climbName;
		}
    }

	public void stopClimb(){

		Spine.TrackEntry now = mAnimationState.GetCurrent(1);
		if (now != null && now.animation != null && now.animation.name == climbName && !now.IsComplete) {
			//此时请动画正在执行。
			//now.timeScale = 0;
		} 
	}
}
