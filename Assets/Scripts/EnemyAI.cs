using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float enemyPursueDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    
    
    public GameObject EnemyShot;
    public Transform EnemyShotSpawn;
    public Transform fpsTarget;

    private float nextFire;
    public float fireRate;

    Rigidbody theRigidBody;
    Renderer myRender;

    // Use this for initialization
    void Start () {
        myRender = GetComponent<Renderer>();
        theRigidBody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if(fpsTargetDistance<enemyLookDistance)
        {
            
            lookAtPlayer();
           //pursuePlayer();
            print("Look at Player Please!");
        }
        if(fpsTargetDistance<enemyPursueDistance)
        {
            pursuePlayer();
            print("Pursuing Player!");
        }
        if(fpsTargetDistance<attackDistance && Time.time > nextFire)
        {
            
            
            attackPlayer();
            print("ATTACK!");
        }
        
    }
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*damping);
    }
    void pursuePlayer()
    {
        theRigidBody.AddForce(transform.forward * enemyMovementSpeed);
    }
    void attackPlayer()
    {
       
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(EnemyShot, EnemyShotSpawn.position, EnemyShotSpawn.rotation) as GameObject;
        
    }
   

}


