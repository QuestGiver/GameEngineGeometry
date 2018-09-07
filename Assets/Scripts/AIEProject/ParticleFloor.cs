using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleFloor : MonoBehaviour
{
    public int sizeX;
    public int sizeY;
    int numParticlesAlive;
    public PerlinTexture perlinTexture;
    public new ParticleSystem particleSystem;
    ParticleSystem.Particle[] particles;
    public new ParticleSystemRenderer renderer;
    // Use this for initialization

    void Start()
    {
        renderer = GetComponent<ParticleSystemRenderer>();
        perlinTexture = GetComponent<PerlinTexture>();
        particleSystem = GetComponent<ParticleSystem>();

        if (particles == null || particles.Length < particleSystem.main.maxParticles)
        {
            particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        }

        var main = particleSystem.main;
        main.startSpeed = 0;
        main.startLifetime = Mathf.Infinity;
        main.loop = false;
        main.maxParticles = sizeX * sizeY;


        var shape = particleSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Circle;
        shape.radius = 0;
        shape.radiusThickness = 0;

        var emission = particleSystem.emission;
        emission.rateOverTime = 0;

        //renderer = GetComponent<ParticleSystemRenderer>();
        renderer.renderMode = ParticleSystemRenderMode.Mesh;
        renderer.mesh = Resources.GetBuiltinResource<Mesh>("Capsule.fbx");
        renderer.alignment = ParticleSystemRenderSpace.World;
      



        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                transform.Translate(new Vector3(0, 0, 1));
                particleSystem.Emit(1);
            }
            transform.Translate(new Vector3(1, 0, -sizeY));
        }



        numParticlesAlive = particleSystem.GetParticles(particles);
    }


    // Update is called once per frame
    
    void Update()
    {
        // Change only the particles that are alive
        int xTotal = 0;
        int yTotal = 0;
        for (int x = 0; x < sizeX; x++)
        {
            xTotal++;
            for (int y = 0; y < sizeY; y++)
            {
                yTotal++;
                particles[xTotal + yTotal].position = new Vector3(0, perlinTexture.noiseTex.GetPixel(x,y).grayscale, 0);
                if (perlinTexture.noiseTex == null)
                {
                    Debug.Log("Noise texture is null");
                }
            }
        }



        // Apply the particle changes to the particle system
        particleSystem.SetParticles(particles, numParticlesAlive);
    }
}
