using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject enemyExplosion;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag=="Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        if (other.tag == "Enemy")
        {
            Instantiate(enemyExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }

}
