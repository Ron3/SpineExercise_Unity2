using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerMove : MonoBehaviour {

    public float maxSpeed = 1.5f;
    public float jumpTakeOffSpeed = 7;

	public Transform targetPosition;
	protected Seeker seeker;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
	protected Rigidbody2D rigidbody2d;

	/** Only when the previous path has been calculated should the script consider searching for a new path */
	protected bool waitingForPathCalculation = false;


	protected virtual void FindComponents () {
		rigidbody2d = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();

		// Get a reference to the Seeker component we added earlier
        seeker = GetComponent<Seeker>();
	}

	protected void CancelCurrentPathRequest () {
		waitingForPathCalculation = false;
		// Abort calculation of the current path
		if (seeker != null) seeker.CancelCurrentPathRequest();
	}

	public void OnDisable () {
		CancelCurrentPathRequest();
		if (seeker != null) seeker.pathCallback -= OnPathComplete;
	}
	void OnEnable()
    {
        FindComponents();

		// Make sure we receive callbacks when paths are calculated
		if (seeker != null) seeker.pathCallback += OnPathComplete;
    }

	// Use this for initialization
	void Start () {
		animator.SetBool ("grounded", true);
		// SearchPath();
	}

	public virtual void SearchPath () {
			// if (float.IsPositiveInfinity(destination.x)) return;
			// if (onSearchPath != null) onSearchPath();

			// lastRepath = Time.time;
			// waitingForPathCalculation = true;

			// seeker.CancelCurrentPathRequest();

			// Vector3 start, end;
			// CalculatePathRequestEndpoints(out start, out end);

			// Alternative way of requesting the path
			//ABPath p = ABPath.Construct(start, end, null);
			//seeker.StartPath(p);

			// This is where we should search to
			// Request a path to be calculated from our current position to the destination
			// seeker.StartPath(start, end);

			if(targetPosition != null && seeker != null)
			{
				seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
			}
		}

	public void OnPathComplete (Path p) {
        Debug.Log("---- PlayerMove.OnPathComplete Yay, we got a path back. Did it have an error? " + p.error);
    }
	
	// Update is called once per frame
	void Update () {
			/*
			float horizontal = 0;  	//Used to store the horizontal move direction.
			float vertical = 0;		//Used to store the vertical move direction.
			
			//Check if we are running either in the Unity editor or in a standalone build.
#if UNITY_STANDALONE || UNITY_WEBPLAYER
			
			//Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
			horizontal = (Input.GetAxisRaw ("Horizontal"));
			vertical = (Input.GetAxisRaw ("Vertical"));
		
			// horizontal = (Input.GetAxis ("Horizontal"));
			// vertical = (Input.GetAxis ("Vertical"));

			// Debug.Log("---- PlayerMove.Update horizontal = " + horizontal);
			// Debug.Log("---- PlayerMove.Update vertical = " + vertical);
			
			//Check if moving horizontally, if so set vertical to zero.
			// if(horizontal != 0)
			// {
			// 	vertical = 0;
			// }
			
			//Check if we are running on iOS, Android, Windows Phone 8 or Unity iPhone
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
			
			//Check if Input has registered more than zero touches
			if (Input.touchCount > 0)
			{
				//Store the first touch detected.
				Touch myTouch = Input.touches[0];
				
				//Check if the phase of that touch equals Began
				if (myTouch.phase == TouchPhase.Began)
				{
					//If so, set touchOrigin to the position of that touch
					touchOrigin = myTouch.position;
				}
				
				//If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
				else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
				{
					//Set touchEnd to equal the position of this touch
					Vector2 touchEnd = myTouch.position;
					
					//Calculate the difference between the beginning and end of the touch on the x axis.
					float x = touchEnd.x - touchOrigin.x;
					
					//Calculate the difference between the beginning and end of the touch on the y axis.
					float y = touchEnd.y - touchOrigin.y;
					
					//Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
					touchOrigin.x = -1;
					
					//Check if the difference along the x axis is greater than the difference along the y axis.
					if (Mathf.Abs(x) > Mathf.Abs(y))
						//If x is greater than zero, set horizontal to 1, otherwise set it to -1
						horizontal = x > 0 ? 1 : -1;
					else
						//If y is greater than zero, set horizontal to 1, otherwise set it to -1
						vertical = y > 0 ? 1 : -1;
				}
			}
			
#endif //End of mobile platform dependendent compilation section started above with #elif

		if(horizontal > 0)
        {
            // if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        } 
        else if (horizontal < 0)
        {
            // if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

		// if(horizontal > 0.01f)
        // {
        //     // if(spriteRenderer.flipX == true)
        //     {
        //         spriteRenderer.flipX = false;
        //     }
        // } 
        // else if (horizontal < -0.01f)
        // {
        //     // if(spriteRenderer.flipX == false)
        //     {
        //         spriteRenderer.flipX = true;
        //     }
        // }

		float posX = horizontal * maxSpeed;
		float posY = vertical * maxSpeed;

		// Debug.Log("---- PlayerMove.Update posX = " + posX);
		// Debug.Log("---- PlayerMove.Update posY = " + posY);

		animator.SetFloat ("velocityX", 0);
		if(horizontal != 0 || vertical != 0)
		{
			animator.SetFloat ("velocityX", 1);
		}

		// transform.Translate(posX, posY, 0);
		rigidbody2d.MovePosition (rigidbody2d.position + Vector2.left * maxSpeed * Time.fixedDeltaTime);

		*/
	}

	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 currentVelocity = rigidbody2d.velocity;

		float newVelocityX = 0f;
		if (moveHorizontal < 0 && currentVelocity.x <= 0) {
			newVelocityX = -maxSpeed;
			spriteRenderer.flipX = true;
		} else if (moveHorizontal > 0 && currentVelocity.x >= 0) {
			newVelocityX = maxSpeed;
			spriteRenderer.flipX = false;
		} else {
			
		}

		float newVelocityY = 0f;
		if (moveVertical < 0 && currentVelocity.y <= 0)
		{
			newVelocityY = -maxSpeed;

		} else if (moveVertical > 0 && currentVelocity.y >= 0)
		{
			newVelocityY = maxSpeed;

		} else
		{

		}

		if(newVelocityX != 0 || newVelocityY != 0)
		{
			animator.SetFloat ("velocityX", 1);
		}
		else{
			animator.SetFloat ("velocityX", 0);
		}
		

		rigidbody2d.velocity = new Vector2 (newVelocityX, newVelocityY);
    }
}
