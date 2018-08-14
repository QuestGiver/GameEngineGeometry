using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBox : MonoBehaviour
{
    [SerializeField]
    //public Vector3 verts = new Vector3[5];

    void Start()
    {
        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        filter.mesh = mesh;

        // Vertices
        // locations of vertices
        Vector3[] verts = new Vector3[6];
        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(1, 0, 0);
        verts[2] = new Vector3(0.3f, 0, -1);
        verts[3] = new Vector3(-0.8f, 0, -0.6f);
        verts[4] = new Vector3(-0.8f, 0, 0.6f);
        verts[5] = new Vector3(0.3f, 0, 1);

        mesh.vertices = verts;

        // Indices
        // determines which vertices make up an individual triangle
        int[] indices = new int[15];

        indices[0] = 0;
        indices[1] = 2;
        indices[2] = 1;

        indices[3] = 0;
        indices[4] = 3;
        indices[5] = 2;

        indices[6] = 0;
        indices[7] = 4;
        indices[8] = 3;

        indices[9] = 0;
        indices[10] = 5;
        indices[11] = 4;

        indices[12] = 0;
        indices[13] = 1;
        indices[14] = 5;



        mesh.triangles = indices;

        // Normals
        // describes how light bounces off the surface (at the vertex level)
        Vector3[] norms = new Vector3[6];

        norms[0] = -Vector3.forward;
        norms[1] = -Vector3.forward;
        norms[2] = -Vector3.forward;
        norms[3] = -Vector3.forward;
        norms[4] = -Vector3.forward;
        norms[5] = -Vector3.forward;


        mesh.normals = norms;

        // UVs, STs
        // defines how textures are mapped onto the surface
        Vector2[] UVs = new Vector2[6];

        UVs[0] = verts[0];
        UVs[1] = verts[1];
        UVs[2] = verts[2];
        UVs[3] = verts[3];
        UVs[4] = verts[4];
        UVs[5] = verts[5];

        mesh.uv = UVs;
    }
}
