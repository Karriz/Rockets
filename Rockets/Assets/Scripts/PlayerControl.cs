using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed, Input.GetAxisRaw("Vertical")*speed);
		if (Input.GetKeyDown(KeyCode.I)) {
			shoot("up");
		}
		if (Input.GetKeyDown(KeyCode.J)) {
			shoot("left");
		}
		if (Input.GetKeyDown(KeyCode.K)) {
			shoot("down");
		}
		if (Input.GetKeyDown(KeyCode.L)) {
			shoot("right");
		}
	}

	void shoot(string direction) {
		switch (direction) {
		case "up":
			GameObject newbullet1 = (GameObject)Instantiate(bullet);
			newbullet1.transform.position = transform.position;
			newbullet1.rigidbody2D.velocity = new Vector2(0f, 6f);
			break;
		case "left":
			GameObject newbullet2 = (GameObject)Instantiate(bullet);
			newbullet2.transform.position = transform.position;
			newbullet2.rigidbody2D.velocity = new Vector2(-6f, 0f);
			break;
		case "down":
			GameObject newbullet3 = (GameObject)Instantiate(bullet);
			newbullet3.transform.position = transform.position;
			newbullet3.rigidbody2D.velocity = new Vector2(0f, -6f);
			break;
		case "right":
			GameObject newbullet4 = (GameObject)Instantiate(bullet);
			newbullet4.transform.position = transform.position;
			newbullet4.rigidbody2D.velocity = new Vector2(6f, 0f);
			break;
				}
	}
}
