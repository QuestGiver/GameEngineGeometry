﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCraftedSphere : MonoBehaviour
{


    public int lat;
    public int lon;

    public GameObject debugSphere;

    int[] triangles;
    Vector3[] Verts;
    Vector3[] normales;
    Vector2[] uvs;
    // Use this for initialization
    void Start()
    {
        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        filter.mesh = mesh;
        //If there are M lines of latitude(horizontal) and N lines of longitude(vertical), then put dots at
        //(x, y, z) = (sin(Pi * m / M) * cos(2Pi * n / N), sin(Pi * m / M) * sin(2Pi * n / N), cos(Pi * m / M))
        //for each m in { 0, ..., M }
        //and n in { 0, ..., N - 1 }

        //edit: maybe adjust M by 1 or 2 as required, because you should decide whether or not to count "latitude lines" at the poles
        #region
        Verts = new Vector3[(lon + 1) * lat + 2];
        int i = 0;

        for (int m = 0; m < lat; m++)
        {
            for (int n = 0; n < lon; n++)
            {
                Verts[i] =  new Vector3(Mathf.Sin(Mathf.PI * m / lat) * Mathf.Cos(2 * Mathf.PI * n / lon),
                            Mathf.Sin(Mathf.PI * m / lat) * Mathf.Sin(2 * Mathf.PI * n / lon),
                            Mathf.Cos(Mathf.PI * m / lat));

                Instantiate(debugSphere, Verts[i], transform.rotation);

                i++;
            }
        }
        #endregion

        //If there are n lon slices in the sphere, each normal is set to equal the normalized vector of Vert[n].
        #region
        normales = new Vector3[Verts.Length];
        for (int n = 0; n < Verts.Length; n++)
        {
            normales[n] = Verts[n].normalized;
        }
        #endregion

        //If there is m Lat and n lon, the uvs of index[n + m * (lon + 1) + 1] is equal to a new vector. X = the current index of lon/themax of lon. y = (1 - the index of lat + 1)/(the max number of lat + 1);
        #region
        uvs = new Vector2[Verts.Length];
        uvs[0] = Vector2.up;
        uvs[uvs.Length - 1] = Vector2.zero;
        for (int m = 0; m < lat; m++)
        {
            for (int n = 0; n <= lon; n++)
            {
                uvs[n + m * (lon + 1) + 1] = new Vector2((float)n / lon, 1f - (float)(m + 1) / (lat + 1));
            }
        }
        #endregion

        #region Triangles
        int nbFaces = Verts.Length;
        int nbTriangles = nbFaces * 2;
        int nbIndexes = nbTriangles * 3;
        triangles = new int[nbIndexes];

        //Top Cap
        int k = 0;
        for (int n = 0; n < lon; n++)
        {
            triangles[k++] = lon + 2;
            triangles[k++] = lon + 1;
            triangles[k++] = 0;
        }

        //Middle
        for (int m = 0; m < lat - 1; m++)
        {
            for (int n = 0; n < lon; n++)
            {
                int current = n + m * (lon + 1) + 1;
                int next = current + n + 1;

                triangles[k++] = current;
                triangles[k++] = current + 1;
                triangles[k++] = next + 1;

                triangles[k++] = current;
                triangles[k++] = next + 1;
                triangles[k++] = next;
            }
        }

        //Bottom Cap
        for (int n = 0; n < lon; n++)
        {
            triangles[i++] = Verts.Length - 1;
            triangles[i++] = Verts.Length - (lon + 2) - 1;
            triangles[i++] = Verts.Length - (lon + 1) - 1;
        }
        #endregion


        mesh.vertices = Verts;
        mesh.normals = normales;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
