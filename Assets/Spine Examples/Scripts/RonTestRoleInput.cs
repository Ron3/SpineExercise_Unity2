using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


namespace Spine.Unity.Examples{
	public class RonTestRoleInput : MonoBehaviour {
		#region Inspector
			public string horizontal = "Horizontal";
			public string vertical = "Vertical";
			public string attackButton = "Fire1";
			public string jumpButton = "Jump";

			public float speed = 0.1f;
		#endregion

		#region Inspector
			[Header("Components")]
			// public SpineboyBeginnerModel model;
			// public RonTest model;
			public FootSoldierExample model;
		#endregion

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			// float currentHorizontal = Input.GetAxisRaw(horizontalAxis);
			float x = Input.GetAxisRaw(this.horizontal);
			float y = Input.GetAxisRaw(this.vertical);
			// Debug.Log("x ==> " + x + " y==> " + y);

			if(x < 0)
			{
				this.model.GetSkeletonAnimation().skeleton.flipX = true;
				// this.model.tryWalk();
			}
			else if(x > 0)
			{
				this.model.GetSkeletonAnimation().skeleton.flipX = false;
				// this.model.tryWalk();
			}
			else if (y != 0)
			{
				// this.model.tryWalk();
			}
			else
			{
				// Debug.Log("idle ===> ");
				// this.model.tryIdle();
			}

			// x = this.gameObject.transform.position.x + x * this.speed;
			// y = this.gameObject.transform.position.y + y * this.speed;
			// float z = this.gameObject.transform.position.z;
			// this.gameObject.transform.position = new Vector3(x, y, z);
			

			
			if (Input.GetButton(attackButton))
			{
				// Debug.Log("attackButton");
				// this.model.tryAttack();
			}
			
			if (Input.GetButtonDown(jumpButton))
			{
				Debug.Log("Jump");
			}
		}
	}
}




