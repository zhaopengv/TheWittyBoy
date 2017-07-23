using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ICode;
using System;
using Spine.Unity;
public class MonsterJumpAI : MonoBehaviour ,ExternalFunction {


    ICodeBehaviour cb;
	 const  int STATE_MOVE = 0;
	 const  int STATE_NAP = 1;

    // Use this for initialization
	//int State = S
	//bool isMove = false;
	//bool isNap = false;

	public Transform pointLeft;
	public Transform pointRight;

	Vector3 moveTartget;
	int state = 0;

	public float moveSmooth = 0.1f;

	float direction = 1;


	public SkeletonAnimation mSkeletonAnimation;
	Spine.AnimationState mAnimationState;
	const string blinkName = "blink";
	const string moveName = "run";
	const string deathName = "death";
	const string reboundName = "bounus";
	MeshRenderer meshRender;



	// Use this for initialization

	//  Spine.TrackEntry 

	void Start () {
		//mSkeletonAnimation = gameObject.GetComponent<SkeletonAnimation> ();
		//mSkeletonAnimation.AnimationName = walkName;
		mAnimationState = mSkeletonAnimation.state;
		mAnimationState.SetAnimation (0, blinkName, true);

		cb = gameObject.GetBehaviour(0);

		Debug.Log("cb is " + cb);
		// cb.stateMachine.

		FsmVariable move = cb.stateMachine.GetVariable("state");

		move.onVariableChange.AddListener(onFsmStateChange);

		moveTartget = new Vector3(direction == 1 ? pointRight.position.x : pointLeft.position.x,transform.position.y,transform.position.z);

		meshRender = GetComponent<MeshRenderer> ();
	}
		

    private void onFsmStateChange(object ss)
    {
		state = (int)ss;


//		/Debug.Log("onFsmMove value is " + arg0);
		//if(state
		if (state == STATE_MOVE) {
			//isMove = true;
			//mAnimationState.TimeScale = 2f;


			//if (state != walkName)
			//{
//			Spine.TrackEntry now = mAnimationState.GetCurrent(1);
//			if (now != null &&now.animation != null && now.animation.name == moveName && !now.IsComplete)
//			{
//				//此时请动画正在执行。
//
//			}
//			else
//			{
				Spine.TrackEntry entry = mAnimationState.SetAnimation(1, moveName, true);
//			}


		} else if (state == STATE_NAP) {
			//isNap = true;
		}

       // cb.stateMachine.SetVariable("move", false);


    }

	private void onFsmNap(object b){

		//Debug.Log("onFsmNap value is " + b);
		//isNap = (bool)b;

	}

    // Update is called once per frame
    void Update () {

       // Debug.Log("state is " + cb.stateMachine.GetState("move").IsEntered);
		//Node node = cb.stateMachine.gets
		//Debug.Log ("node is "+node.name);
		Debug.Log("visiable is "+GetComponent<MeshRenderer>().isVisible);

		if (state == STATE_MOVE) {

			//transform.position = Vector3.Lerp (transform.position, moveTartget, Time.deltaTime * moveSmooth);
			transform.Translate(moveSmooth * Vector3.right * direction * Time.deltaTime);
			if (direction == -1) {
				if (transform.position.x <= moveTartget.x) {
					changeTarget ();
				}
			} else if (direction == 1) {
				if (transform.position.x >= moveTartget.x) {
					changeTarget ();
				}
			}

			//moveTartget = transform.position.x <= moveTartget.x ? patrolPoint2.position : patrolPoint1.position;
		}
	}

	void changeTarget(){
		moveTartget = direction == -1 ? pointRight.position : pointLeft.position;

		direction *= -1;

		mSkeletonAnimation.skeleton.FlipX = direction == 1;

		//Debug.Log ("changeTarget target is " + moveTartget+" direction is "+direction );
	}

	private void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("OnCollisionEnter2D other is "+other);

	}

	public void apply (PlayerController playerController,Collision2D other){
		Debug.Log ("ReboundFunction !!!");
		//playerController.playerRigidbody.velocity.
	 
		Vector2 hitNormal = other.contacts [0].normal;
		Debug.Log ("relative velocity is "+other.relativeVelocity);
		Debug.Log ("hitNormal is "+hitNormal);
		//Death
		if (hitNormal.y > 0) {
			Destroy (gameObject);
		}
		//
		//playerController.playerRigidbody.AddForce(other.relativeVelocity.y * Vector2.up * 10);
	}
    

    
}
