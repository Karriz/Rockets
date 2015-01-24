using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
	private Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		steer ();
	}
	void FixedUpdate () {
		rigidbody2D.AddForce (transform.right);
	}

	void steer() {
		Vector2 forwards = transform.right;
		Vector2 playerdir = player.position - transform.position;
		Vector3 cross = Vector3.Cross (new Vector3 (forwards.x, forwards.y, 0f), new Vector3 (playerdir.x, playerdir.y, 0f));
		float angle = cross.z * Vector2.Angle (forwards, playerdir);

		Debug.Log (angle);

		if (angle < 0f) {
			rigidbody2D.angularVelocity = -100f;
				}
		else if (angle > 0f) {
			rigidbody2D.angularVelocity = 100f;
		}
	}
}
