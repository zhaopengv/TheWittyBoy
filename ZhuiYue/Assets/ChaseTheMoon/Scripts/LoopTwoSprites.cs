using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTwoSprites : MonoBehaviour {

    public SpriteRenderer mFirst;
    public SpriteRenderer mSecond;

    SpriteRenderer mTarget;
    SpriteRenderer mPast;

    SpriteRenderer mTemp;

    Camera mainCamera;

    float lastPosition;
    float cameraMoved;

    public float moveSpeedMultiple = 0.001f;


    // Use this for initialization
    void Start()
    {


        //注意在本地坐标里计算

        mainCamera = Camera.main;

        print("Fold is " + Constant.PICTURE_FOLD);


        print("视口宽度 ： " + mainCamera.pixelWidth);

        print("mFirst width is " + mFirst.sprite.texture.width);

        mTarget = mSecond;
        mPast = mFirst;

        //1，摆正，将target
        mTarget.transform.localPosition = mPast.transform.localPosition + mPast.sprite.bounds.size.x * Vector3.right;



        



    }
	
	// Update is called once per frame
	void Update () {

        // mainCamera.WorldToViewportPoint
        // mTarget.transform.position.

        

        


        float cameraMovedX =  mainCamera.velocity.x * Time.deltaTime * moveSpeedMultiple;

        if (cameraMovedX != 0)
        {
            gameObject.transform.Translate(Vector3.left * cameraMovedX);

        }


        //如果target的右边缘的位置在视口坐标中小于或等于1，证明目标已经完全显示，需要
       // Vector3 targetRight = mTarget.transform.localPosition + mTarget.bounds.size.x * Vector3.right;

        Vector3 targetRightWorldPosition = mTarget.transform.position + mTarget.bounds.size.x * Vector3.right;

       // Vector3 targetRightWorldPosition = mTarget.transform.position;

        Debug.DrawLine(targetRightWorldPosition, targetRightWorldPosition + Vector3.up * 10, Color.red);

        if(mainCamera.WorldToViewportPoint(targetRightWorldPosition).x <= 1)
        {
            //此时证明target已经飞出屏幕

            mPast.transform.position = targetRightWorldPosition;

            mTemp = mTarget;

            mTarget = mPast;

            mPast = mTemp;
            //mPast = mTarget;

        }


        //print("Target screen point is " + mainCamera.WorldToViewportPoint(targetRight));


        //print("cameraMoved  is " + cameraMoved);



        // lastPosition = mainCamera.transform.position.x;

        //print("cameraMovedX is " + cameraMovedX);



    }


}
