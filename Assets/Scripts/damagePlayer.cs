using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour {
    public int playerHealth = 100;
    int damage = 10;
	// Use this for initialization
	void Start () {
        print(playerHealth);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            playerHealth -= damage;
            print("owie hit!" + playerHealth);
        }
    }
}
