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
        
        ps.transform.rotation = Quaternion.LookRotation((target.position - ps.transform.position).normalized,
            (target.position - ps.transform.position).normalized);
        ps.transform.position = (LiquidBottom.position - target.position.normalized * 0.01f);

        ps.SetParticles(particles, particles.Length);
        //ps.trigger.AddCollider(Obj_Colision);
        
    }
}
