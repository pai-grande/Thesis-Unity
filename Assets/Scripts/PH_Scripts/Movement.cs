 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Movement : MonoBehaviour {

   // ParticleSystem ps;
    public float m_velocity = 2f;
    public Vector3 Rotation;
    public AttitudeRotation attRot;
    public InputActions1 playeractions;
    public Vector3 movement;
    public Vector3 torque;
    public bool InputTimer;
    public Vector2 prevJoyPos, look;
    public float joystickDistance;




    // Use this for initialization
    void Start () {
        prevJoyPos.x = 0;
        prevJoyPos.y = 0;
        joystickDistance = 0;

    }

    private void FixedUpdate()
    {
        Rotation = transform.rotation.eulerAngles ;
        attRot.GetAttitude(Rotation);
        //transform.Translate(movement);
        //GetComponent<Rigidbody>().AddTorque(torque);

    }

    void OnMovement(InputValue value)
    {
        Vector2 move = value.Get<Vector2>();

        movement = new Vector3(move.x , 0, move.y) * 0.5f * Time.deltaTime;
        
        //transform.Translate(movement);
 
        //movement.x = move[0];
        //movement.y = 0.0f;
        //movement.z = move[1];

        //GetComponent<Rigidbody>().AddForce(movement * 0.010f, ForceMode.VelocityChange);
    }


    void OnLookInv(InputValue value)
    {
        Vector2 look = value.Get<Vector2>();


        //GetComponent<Rigidbody>().AddTorque(new Vector3(look.y * 0.001f, 0f, -look.x * 0.001f));

        torque = (new Vector3(look.y * 0.003f, 0f, -look.x * 0.003f));

        if (look.x != 0 || look.y != 0 )
            InputTimer = true;
        
        joystickDistance += Mathf.Sqrt(Mathf.Pow((look.x - prevJoyPos.x), 2) + Mathf.Pow((look.y - prevJoyPos.y), 2));
        Debug.Log(joystickDistance);


    }


    void OnLook(InputValue value)
    {
        Vector2 look = value.Get<Vector2>();


        //GetComponent<Rigidbody>().AddTorque(new Vector3(-look.y * 0.001f, 0f, -look.x* 0.001f));
        Debug.Log(look);
        torque = (new Vector3(-look.y * 0.0003f, 0f, -look.x * 0.0003f));
        joystickDistance += Mathf.Sqrt(Mathf.Pow((look.x - prevJoyPos.x), 2) + Mathf.Pow((look.y - prevJoyPos.y), 2));
        Debug.Log(joystickDistance);


        if (look.x != 0 || look.y != 0 )
            InputTimer = true;

    }


    // Update is called once per frame
    void Update () {

        //GetComponent<Rigidbody>().AddForce(movement);
        transform.Translate(movement);
        //transform.Rotate(torque);
        GetComponent<Rigidbody>().AddRelativeTorque(torque);
        prevJoyPos = look;


        


        //Mathf.Sqrt()

        if (Input.GetKeyDown(KeyCode.M))
            GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0.01f, 0f));

        if (Input.GetKeyDown(KeyCode.N))
            GetComponent<Rigidbody>().AddTorque(new Vector3(0f, -0.01f, 0f));

        if (Input.GetKeyDown(KeyCode.UpArrow))
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 0.05f, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            GetComponent<Rigidbody>().AddForce(Vector3.back * 0.05f, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            GetComponent<Rigidbody>().AddForce(Vector3.right * 0.05f, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            GetComponent<Rigidbody>().AddForce(Vector3.left * 0.05f, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.W)) 
            GetComponent<Rigidbody>().AddTorque(new Vector3(0.01f, 0f, 0f));

        if (Input.GetKeyDown(KeyCode.S))
            GetComponent<Rigidbody>().AddTorque(new Vector3(-0.01f, 0f, 0f));

        if (Input.GetKeyDown(KeyCode.A))
            GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, 0.01f));

        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, -0.01f));
        }
    }
}
