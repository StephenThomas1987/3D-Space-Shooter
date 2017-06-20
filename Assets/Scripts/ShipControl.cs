using UnityEditor.AnimatedValues;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    //public Texture Cross;
    //The purpose of this script is to simulate Newtonian phy
    private float ThrustWeight = 200; //The maximum Thrust provided by the thruster(s) at full throttle
    private float rollWeight = 5; //This float and the next two only serve to adjust sensitivity
    private float pitchWeight = 5;//of the controls, and to allow calibration for more massive ships.
    private float yawWeight = 5;//Set these 3 floats to the mass of the rigidbody for sensitive controls
    private float strafeWeight =200;
    //private float strafe;
   // private float throttle;


    

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        float yaw = yawWeight * Input.GetAxis("Yaw");
        float roll = rollWeight * Input.GetAxis("Roll");
        float pitch = pitchWeight * Input.GetAxis("Pitch");
        
        float throttle = Input.GetAxis("Throttle");
        
        GetComponent<Rigidbody>().AddRelativeTorque(pitch* pitchWeight*Time.deltaTime,yaw *yawWeight*Time.deltaTime,roll* rollWeight*Time.deltaTime);
        GetComponent<Rigidbody>().AddRelativeForce(0,0,throttle*ThrustWeight*Time.deltaTime);
        var strafe =new Vector3(Input.GetAxis("Horizontal") * strafeWeight * Time.deltaTime, Input.GetAxis("Vertical") * strafeWeight * Time.deltaTime, 0);

        GetComponent<Rigidbody>().AddRelativeForce(strafe);
        
    }

}