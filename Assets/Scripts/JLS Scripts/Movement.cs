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
    public Vector3 look3;




    // Use this for initialization
    void Start () {
     //   GameObject go = GameObject.Find("Particle System");
     //   ps = go.GetComponent<ParticleSystem>();

    }

    private void FixedUpdate()
    {
        Rotation = transform.rotation.eulerAngles ;
        attRot.GetAttitude(Rotation);
    }

    void OnMovement(InputValue value)
    {
        Vector2 move = value.Get<Vector2>();

        movement.x = move[0];
        movement.y = 0.0f;
        movement.z = move[1];

        GetComponent<Rigidbody>().AddForce(movement * 1.0f, ForceMode.VelocityChange);
        //GetComponent<Rigidbody>().AddForce(Vector3.forward * 0.05f, ForceMode.VelocityChange);

        //GetComponent<Rigidbody>().AddForce(Vector3.back * 0.05f, ForceMode.VelocityChange);

        //GetComponent<Rigidbody>().AddForce(Vector3.right * 0.05f, ForceMode.VelocityChange);

        //GetComponent<Rigidbody>().AddForce(Vector3.left * 0.05f, ForceMode.VelocityChange);

    }

    void OnLook(InputValue value)
    {
        Vector2 look = value.Get<Vector2>();
        //look3.x = look[0];

        GetComponent<Rigidbody>().AddTorque(new Vector3(look[1] * 0.001f, 0f, -look[0]* 0.001f));
    }


    // Update is called once per frame
    void Update () {
        //Vector3 dir = new Vector3();

        if (Input.GetKeyDown(KeyCode.M))
            GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0.01f, 0f));

        if (Input.GetKeyDown(KeyCode.N))
            GetComponent<Rigidbody>().AddTorque(new Vector3(0f, -0.01f, 0f));

        if (Input.GetKeyDown(KeyCode.UpArrow))
            //Debug.Log("UpKey pressed");
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 0.05f, ForceMode.VelocityChange);
        /*new
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = Vector3.Forward * m_velocity;
        }
        */

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
/*
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
            ps.GetParticles(particles);

            for (int i = 0; i < particles.Length; i++)
            {
                ParticleSystem.Particle p = particles[i];
                Vector3 addValue = new Vector3(10f, 0f, 0f);
                p.position += p.position + addValue;
                particles[i] = p;
            }

            ps.SetParticles(particles, particles.Length);
*/
        }
    }

    //fisica
    /*
    void FixedUpdate()
    {
        
     if(Input.GetKeyDown(KeyCode.UpArrow))    
            transform.Translate(5 * Input.GetAxis("Horizontal") * Time.deltaTime * -1, 
                -1 * 5 * Input.GetAxis("Horizontalmove") * Time.deltaTime, 
                5 * Input.GetAxis("Vertical") * -1 * Time.deltaTime);
                
    }
    */
}
