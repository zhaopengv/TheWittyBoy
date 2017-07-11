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

    Vector2 playerVolocity = Vector2.zero;
    float jump = 0;


    bool isGroud = false;

    PlayerAnimationController mAnimationController;


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


        isGroud = Physics2D.OverlapCircle(groudCheckPoint.position, groudCheckRadius, groudCheckMask);

        //print("isGroud : "+ isGroud);
        //if(playerRigidbody)

        playerVolocity.x = x * moveSmooth;
        if(x != 0)
            mAnimationController.flip(x < 0);

        if (isGroud)
        {
            if (jump != 0)
            {
                print("jumping!!!!");
                playerVolocity.y = jump * jumpSmooth;
                mAnimationController.jump();
            }
            else
            {
                if (x != 0)
                {
                    mAnimationController.walk();
                }
                else
                {
                    mAnimationController.idle();
                }
            }

        }
        else
        {
            playerVolocity.y -= gravity * Time.deltaTime;
        }






        // print(" x is " + playerVolocity.x);
        //playerVolocity.y = Mathf.Max(0, playerVolocity.y);

        playerRigidbody.velocity = playerVolocity;

        // playerRigidbody.velocity.Set(playerRigidbody.x,)


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("OnCollisionEnter2D!!!!");

    }

    private void OnCollisionExit(Collision collision)
    {
        print("OnCollisionExit!!!!");
    }

    private void OnCollisionStay(Collision collision)
    {
        print("OnCollisionStay!!!!");
    }
}
