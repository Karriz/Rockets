using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed, Input.GetAxisRaw("Vertical")*speed);


	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			Die (coll.gameObject);
				}
	}

	void Die(GameObject coll) {
		Destroy (coll);
		Destroy (gameObject);
	}
}
