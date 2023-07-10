using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSeek : MonoBehaviour
{
    public Transform target;
    public float force = 3f;

    public Transform LiquidBottom;
    //public Transform Obj_Colision;

    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
        ps.GetParticles(particles);

        if (Input.GetKey(KeyCode.P)){
            for (int i = 0; i < particles.Length; i++)
            {
                ParticleSystem.Particle p = particles[i];
                Vector3 directionToTarget = (target.position - p.position).normalized;
                //Vector3 directionToTarget = (GetComponent<Rigidbody>().position - p.position).normalized;
                Vector3 seekForce = (directionToTarget * force) * Time.deltaTime;
                p.velocity += seekForce;

                //p.position = p.position + new Vector3(0, 0.1f, 0);
                //   p.position = p.position + new Vector3(0.1f * transform.InverseTransformDirection(directionToTarget).normalized.x,
                //                                         0.1f * transform.InverseTransformDirection(directionToTarget).normalized.y,
                //                                         0.1f * transform.InverseTransformDirection(directionToTarget).normalized.z);

                //Vector3 addValue = new Vector3(2f, 0f, 0f);
                //p.position = p.position + new Vector3(0.05f * directionToTarget.x,
                //                                      0.05f * directionToTarget.y,
                //                                      0.05f * directionToTarget.z);

                //if (Input.GetKeyDown(KeyCode.W))
                //    p.position += p.position + addValue;

                //p.position = ((LiquidBottom.position-target.position.normalized*0.1f) + 
                //             new Vector3(Random.Range(-0.2f, 0.2f), 0f, Random.Range(-0.2f, 0.2f)));

                particles[i] = p;
            }
        }
    
        ps.transform.rotation = Quaternion.LookRotation((target.position - ps.transform.position).normalized,
            (target.position - ps.transform.position).normalized);
        ps.transform.position = (LiquidBottom.position - target.position.normalized * 0.01f);

        ps.SetParticles(particles, particles.Length);
        //ps.trigger.AddCollider(Obj_Colision);
        
    }
}
