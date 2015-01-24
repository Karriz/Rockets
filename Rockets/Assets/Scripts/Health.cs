using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    
    public int health;
    int points;

    void damages()
    {
        health--;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            damages();
            points = +1; 
        }

        if (col.gameObject.tag == "Missile")
        {
            damages();
            Destroy(col.gameObject);
        }
    
    }

    

	
	// Update is called once per frame
	void Update () {
	
	}
}
