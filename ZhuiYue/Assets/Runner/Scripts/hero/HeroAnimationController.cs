using UnityEngine;
using System.Collections;
using Spine.Unity;
using Spine;

public class HeroAnimationController : MonoBehaviour {


	public float timeScale = 0.2f;

	public string jumpName = "jump";
	public string runName = "run";
	public string idleName = "idle";
	public string fallName = "fall";
	public string flashName = "flash";
	public string slideName = "slide";


	// Use this for initialization
	SkeletonAnimation mSkeletonAnimation;
	SkeletonData mSkeletonData;
	RuntimeAnimatorController mAnimatorController;
	//SkeletonAnimation
	//MeshRenderer


	SkeletonRenderer mSkeletonRenderer;


	void Awake(){
		mSkeletonAnimation = gameObject.GetComponent<SkeletonAnimation> ();
		mAnimatorController = mSkeletonAnimation.skeletonDataAsset.controller;

		//mParticleSystemRenderer = mParticleSystem.part
		print ("mAnimatorController is "+mAnimatorController);

	}


	// Use this for initialization
	void Start () {
		

		mSkeletonAnimation.state.TimeScale = timeScale;
		mSkeletonAnimation.state.SetAnimation (0, "idle", true);


		//mParticleSystem.shape.shapeType = ParticleSystemMeshShapeType;
	
		mSkeletonRenderer = GetComponent<SkeletonRenderer> ();

		//mParticleSystemRenderer = GetComponent<ParticleSystemRenderer> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate(){

		//Shape
		//Particle[] ps = new Particle[mParticleSystem.particleCount];
		//mParticleSystem.GetParticles (ps);

	}


	public void jump(){
		//mSkeletonAnimation.skeleton.FindBone ("trunk").Y = 0;
		//mAnimatorController.
		//mCharacterController.Move(
		//mSkeletonAnimation.state.SetAnimation (0, "jump", false);
		mSkeletonAnimation.AnimationName = jumpName;
		//mSkeletonAnimation.state.AddAnimation (0, "run", true,0);
	}

	public void setTimeScale(float ts){

		//mSkeletonAnimation.state
	}

	public void run(float timeScale){
		//mSkeletonAnimation.state.SetAnimation (0, "run", true).TimeScale = timeScale;
		mSkeletonAnimation.AnimationName = runName;
	}

	public void idle(){
		mSkeletonAnimation.AnimationName = idleName;
	}

	public void fall(){
		mSkeletonAnimation.AnimationName = fallName;

	}

	public void flash(){
		mSkeletonAnimation.AnimationName = flashName;
	}


	public void slide(){
		mSkeletonAnimation.AnimationName = slideName;
	}



	//public void 

}
