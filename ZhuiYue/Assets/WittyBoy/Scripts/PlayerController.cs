using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D playerRigidbody;
    public float moveSmooth = 1;
    public float jumpSmooth = 50;
    public int gravity = 20;
    public LayerMask groudCheckMask;

    public Transform groudCheckPoint;

    public float groudCheckRadius = 0.1f;

	public float climbSmooth = 5;

    Vector2 playerVolocity = Vector2.zero;
    float jump = 0;


    bool isGroud = false;

	bool onMonster = false;

	Vector2 addtionVelocity = Vector2.zero;

    PlayerAnimationController mAnimationController;

	bool onLadder =  false;



    void Start()
    {
        mAnimationController = GetComponent<PlayerAnimationController>();

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR_WIN
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        jump = Input.GetKey("space") ? 1 : 0;


#endif
#if UNITY_EDITOR

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		jump = Input.GetKey("space") ? 1 : 0;

#endif


        isGroud = Physics2D.OverlapCircle(groudCheckPoint.position, groudCheckRadius, groudCheckMask);


        //if(playerRigidbody)

        playerVolocity.x = x * moveSmooth;
        if(x != 0)
            mAnimationController.flip(x < 0);

		if (onLadder) {
			//在梯子上时

			playerVolocity.y = climbSmooth * y;

			if (jump != 0) {
				//print("jumping!!!!");
				playerVolocity.y = jump * jumpSmooth;
				mAnimationController.jump ();
			} else {
				if (y != 0)
					mAnimationController.climb ();
				else {
					mAnimationController.stopClimb ();
				}
				if (isGroud) {
					if (x != 0) {
						mAnimationController.walk ();
					} else {
						mAnimationController.idle ();
					}
				}
			}

		} else {


			if (onMonster) {
				print ("onMonster : " + onMonster);

				if (jump != 0) {
					//print("jumping!!!!");
					playerVolocity.y = jump * jumpSmooth;
					mAnimationController.jump ();
				}

			} else if (isGroud) {
				if (jump != 0) {
					//print("jumping!!!!");
					playerVolocity.y = jump * jumpSmooth;
					mAnimationController.jump ();
				} else {
					if (x != 0) {
						mAnimationController.walk ();
					} else {
						mAnimationController.idle ();
					}
				}

			} else {
			
				playerVolocity.y -= gravity * Time.deltaTime;
			}

		}






        // print(" x is " + playerVolocity.x);
        //playerVolocity.y = Mathf.Max(0, playerVolocity.y);

		playerRigidbody.velocity = playerVolocity + addtionVelocity;

        // playerRigidbody.velocity.Set(playerRigidbody.x,)


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		print("OnCollisionEnter2D collision is "+collision.gameObject);

		ExternalFunction ef = collision.gameObject.GetComponent<ExternalFunction> ();
		print("OnCollisionEnter2D ef is "+ef);
		if (ef != null) {
			//ExternalFunction ef = (ExternalFunction)(collision.gameObject);
			//ef.apply (this);
			StartCoroutine(applyExternalFuntion(ef,collision));
			//applyExternalFuntion(ef,collision);
		}

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
		//onMonster = false;
        //print("OnCollisionExit!!!!");
		//addtionVelocity = Vector2.zero;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //print("OnCollisionStay!!!!");
    }

	IEnumerator applyExternalFuntion(ExternalFunction ef,Collision2D collision){

		onMonster = true;
		print("applyExternalFuntion !!!! ef is "+ef);
		//ef.apply()
		ef.apply(this,collision);


		addtionVelocity = (25 * Vector2.up) ;

		yield return new WaitForSeconds (.1f);

		onMonster = false;
		addtionVelocity = Vector2.zero;

	}


	void OnTriggerEnter2D(Collider2D c){
		Debug.Log("onTriggerEnter2D!!!! tag is "+c.tag);
		if ("ladder".Equals (c.tag)) {
			onLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D c){
		Debug.Log("OnTriggerExit2D!!!!");

		if ("ladder".Equals (c.tag)) {
			onLadder = false;
			mAnimationController.stopClimb ();
		}
	}

	void OnTriggerStay2D(Collider2D other){
		//Debug.Log("onTriggerStay2D!!!!");

	}


}
