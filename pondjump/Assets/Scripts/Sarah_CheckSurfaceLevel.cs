using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarah_CheckSurfaceLevel : MonoBehaviour
{
    public GameObject objectInQuestion;

    public Vector3[] vectorPoints;
    public Vector3[] newPoints;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        MeshFilter _meshfilter = objectInQuestion.GetComponent<MeshFilter>();
        Mesh curMesh = _meshfilter.mesh;

        vectorPoints = curMesh.vertices;
        if (newPoints.Length == 0)
        {
            newPoints = new Vector3[vectorPoints.Length];


            for (int i = 0; i < vectorPoints.Length; i++)
            {
                float newValue = Mathf.Round(vectorPoints[i].y * 10f) / 10f;
                newPoints[i] = new Vector3(vectorPoints[i].x, newValue, vectorPoints[i].z);
            }
            //unhide if you want the vers to round up
            //curMesh.vertices = newPoints;
        }
    }
}
