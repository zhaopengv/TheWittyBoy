using UnityEngine;
using System.Collections;


public class HeroController : MonoBehaviour {

	HeroAnimationController mHeroAnimationController;

	public float runSpeed = 10;
	public float gravity = 65;

	public float jumpSpeed = 25f;
	public float jumpDuration = 0.5f;
	public GameObject phantomPrefab;
	public GameObject phantomPrefabFlip;

	public float phantomInterval = 0.01f;
	public float phantomIntervalDestoryTime = 0.05f;

	public LayerMask groudCheckLayerMask;

	public BoxCollider2D normalBox;
	public BoxCollider2D slideBox;

	public float jumpForce = 400;

	public bool nonstop = true;

	public float flashSpeed = 50;

	public float flashTime = 0.3f;

	public Transform groudCheck;

	public float rushFreezeTime = 0.1f;

	bool slide = false;

	bool isRunshing = false;

	Vector2 velocity = Vector2.zero;

	//CharacterController mCharacterController;

	Transform mHeroTransform;

	Quaternion flipQuaternion = Quaternion.Euler(0,180,0);

	Rigidbody2D HeroRigidbody2D;

	MeshFilter meshFilter;



	float groudRadius = 0.1f;
	bool isGrounded;

	bool runshFreezing = false;


	void Awake(){
		mHeroAnimationController = gameObject.GetComponent<HeroAnimationController> ();
		HeroRigidbody2D = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Start () {
		//mCharacterController = gameObject.GetComponent<CharacterController> ();

		mHeroTransform = gameObject.transform;

		meshFilter = GetComponent<MeshFilter> ();

		StartCoroutine (createPhantom());

		//StartCoroutine (runshPaused ());
	}

	void FixedUpdate(){
		if (!isRunshing) {
			velocity.y -= gravity * Time.deltaTime;
		}
	}
	
	// Update is called once per frame
	void Update  () {





		#if UNITY_EDITOR_WIN
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
        //print("isGrounded is "+isGrounded	);
#else
        float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
#endif



        if (isRunshing) {

			//doNothing
			//runshedTime += Time.deltaTime;

		} else {

			bool jump = Input.GetButtonDown ("Jump");

			if (jump) {

				print ("jump");
				mHeroAnimationController.jump ();
				velocity.y = jumpSpeed;
				//HeroRigidbody2D.AddForce (Vector2.up * jumpForce);
			}

			bool jumping = velocity.y > 0;

			isGrounded = Physics2D.OverlapCircle (groudCheck.position, groudRadius, groudCheckLayerMask) && !jumping;
	

			slide = isGrounded && y < 0;
		
			print ("slide is "+slide);
			if (nonstop) {
				//如果是一直向前跑，直接不停的输入1
				if (x > 0 && ! runshFreezing) {
					//flash!
					isRunshing = true;
					StartCoroutine(flash());
					velocity.x = 1 * flashSpeed;
				} else {
					velocity.x = 1 * runSpeed;
				}
			} else {
				velocity.x = x * runSpeed;
			}

			if (!isRunshing) {
				if (isGrounded) {
			
		
					if (!jumping) {
						if (slide) {
							mHeroAnimationController.slide ();
							slideBox.enabled = true;
							normalBox.enabled = false;
						}else if (x != 0 || nonstop) {
							mHeroAnimationController.run (x);
							normalBox.enabled = true;
							slideBox.enabled = false;
						} else {
							mHeroAnimationController.idle ();
							normalBox.enabled = true;
							slideBox.enabled = false;
						}
						velocity.y = 0;
					}

				} else {
					if (HeroRigidbody2D.velocity.y < 0 && !jumping) {
						mHeroAnimationController.fall ();
					}


				}
			}

			//HeroRigidbody2D.AddForce (Vector2.right * x * runSpeed);
			if (!nonstop) {
				if (x > 0) {
					mHeroTransform.localRotation = Quaternion.identity;
				} else if (x < 0) {
					mHeroTransform.localRotation = flipQuaternion;
				}
			}

			HeroRigidbody2D.velocity = velocity;


			//velocity.y = Mathf.Max (-gravity * Time.deltaTime, velocity.y);
			//print ("gravity * Time.deltaTime  y  is " + gravity * Time.deltaTime);



			//print ("velocity.y is "+velocity.y);



			/*
		if (Input.GetMouseButtonDown (0)) {
			print ("OnMouseLeftDown");
			//mHeroAnimationController.jump ();
		}
		*/


		}
	
	}




	void LateUpdate(){
		

	}

	IEnumerator runshPaused(){
		while (true) {
			if (isRunshing) {
				runshFreezing = true; 
				yield return 0;
			} else {

				yield return new WaitForSeconds (rushFreezeTime);
				runshFreezing = false;
			}



		}


	}

	IEnumerator flash(){
		mHeroAnimationController.flash ();
		//StartCoroutine(createPhantom());
		velocity.y = 0;
		while (true) {
		
			yield return new WaitForSeconds(flashTime);
			isRunshing = false;
			//StopCoroutine (createPhantom ());
		}
		//StartCoroutine (createPhantom ());

	}


	IEnumerator createPhantom(){
		//yield return new WaitForSeconds (1);
		float increment = 0;

		while(true){

			increment += Time.deltaTime;
			yield return 0;
			if (increment > phantomInterval) {
				
				if (velocity.magnitude > 0 && isRunshing) {
					GameObject g;
					if (mHeroTransform.localRotation.eulerAngles.y == 0) {
						g = GameObject.Instantiate (phantomPrefab);
					} else{
						g = GameObject.Instantiate (phantomPrefabFlip);
					}


					MeshFilter mf = g.GetComponent<MeshFilter> ();
					MeshRenderer mr = g.GetComponent<MeshRenderer> ();


					mf.mesh = meshFilter.mesh;
					mr.sharedMaterial.color = Color.blue;

					g.transform.parent = this.transform.parent;
					g.transform.position = this.transform.position;

					StartCoroutine (desotryPhantom (g));


				}

				increment = 0;

			}
				

		}
	

	}

	IEnumerator desotryPhantom(GameObject g){
		yield return new WaitForSeconds (phantomIntervalDestoryTime);
		GameObject.DestroyImmediate (g);
	}


	public bool isRush(){

		return isRunshing;
	}
}
