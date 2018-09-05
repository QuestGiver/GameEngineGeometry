using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFloor : MonoBehaviour
{
    public int sizeX;
    public int sizeY;


    public ParticleSystem particleSystem;
    // Use this for initialization
    void Start()
    {
        //particleSystem = new ParticleSystem;

        ParticleSystem.MainModule main = particleSystem.main;
        main.startSpeed = 0;
        main.startLifetime = Mathf.Infinity;
        main.loop = false;
        main.maxParticles = sizeX * sizeY;
        

        ParticleSystem.ShapeModule shape = particleSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Circle;
        shape.radius = 0;
        shape.radiusThickness = 0;

        ParticleSystem.EmissionModule emission = particleSystem.emission;
        emission.rateOverTime = 0;





        for (int x = 0; x < sizeX; x++)
        {
            particleSystem.Emit(1);
            for (int y = 0; y < sizeY; y++)
            {
                
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public ParticleSystem ParticleSetUp(ParticleSystem system)
    //{
    //    ParticleSystem.MainModule main = system.main;
        
    //    main.startSpeed = 0;
    //    main.startLifetime = Mathf.Infinity;
    //    main.loop = false;

        
        
        

    //    return 
    //}

}
