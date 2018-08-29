using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFloor : MonoBehaviour
{



    public ParticleSystem particleSystem;
    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void ParticleUpdate(ParticleSystem system)
    {
        //ParticleSystem.EmitParams emitParams;
        //emitParams.position
        ParticleSystem.EmissionModule emission = particleSystem.emission;
        //emission.rateOverTime = 
    }

}
