using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveXZ : MonoBehaviour {

	public float maxSpeed = 3;

	public Transform playerTransform;
	public Transform targetTransform;
	// protected Seeker seeker;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
	protected Rigidbody rigidbody;

	/** Only when the previous path has been calculated should the script consider searching for a new path */
	protected bool waitingForPathCalculation = false;

	protected virtual void FindComponents () {
		rigidbody = GetComponent<Rigidbody> ();
		spriteRenderer = playerTransform.GetComponent<SpriteRenderer> (); 
        animator = playerTransform.GetComponent<Animator> ();

		// Get a reference to the Seeker component we added earlier
        // seeker = GetComponent<Seeker>();
	}
	
	void OnEnable()
    {
        FindComponents();

		// Make sure we receive callbacks when paths are calculated
		// if (seeker != null) seeker.pathCallback += OnPathComplete;
    }

	// Use this for initialization
	void Start () {
		animator.SetBool ("grounded", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 currentVelocity = rigidbody.velocity;

		float newVelocityX = 0f;
		if (moveHorizontal < 0 && currentVelocity.x <= 0) {
			newVelocityX = -maxSpeed;
			spriteRenderer.flipX = true;
		} else if (moveHorizontal > 0 && currentVelocity.x >= 0) {
			newVelocityX = maxSpeed;
			spriteRenderer.flipX = false;
		} else {
			
		}

		float newVelocityZ = 0f;
		if (moveVertical < 0 && currentVelocity.z <= 0)
		{
			newVelocityZ = -maxSpeed;

		} else if (moveVertical > 0 && currentVelocity.z >= 0)
		{
			newVelocityZ = maxSpeed;

		} else
		{

		}

		if(newVelocityX != 0 || newVelocityZ != 0)
		{
			animator.SetFloat ("velocityX", 1);
		}
		else{
			animator.SetFloat ("velocityX", 0);
		}
		

		rigidbody.velocity = new Vector3 (newVelocityX, 0, newVelocityZ);
    }
}
