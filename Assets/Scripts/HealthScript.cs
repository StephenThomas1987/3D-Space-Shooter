using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    public float health = 100;
    private float currentHealth;
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject enemyExplosion;
    public GameObject Shot;
    public GameObject EnemyShot;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Shot")
        {
            health -= 10;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "EnemyShot")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            health -= 10;  
        }
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if (other.tag == "Player")
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
    
    // Use this for initialization
    public void RemoveHealth(float amount)
    {
        health -= amount;
        if ((health -= 0) != 0)
        {
            Destroy(gameObject);
        }
    }
    
}

