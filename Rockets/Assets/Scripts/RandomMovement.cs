using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
		randomDir();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 2f) {
			timer = 0f;
			randomDir();
				}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Border") {
			randomDir();
				}
		}

	void randomDir() {
		int randomvalue = Random.Range (0, 4);
			switch(randomvalue) {
			case 0:
				rigidbody2D.velocity = new Vector2(2f, 0);
				break;
			case 1:
				rigidbody2D.velocity = new Vector2(-2f, 0);
				break;
			case 2:
				rigidbody2D.velocity = new Vector2(0,2f);
				break;
			case 3:
				rigidbody2D.velocity = new Vector2(0,-2f);
				break;
			}
		}
}
