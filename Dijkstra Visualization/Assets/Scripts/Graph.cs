using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    List<Vertex> verticesList = new List<Vertex>();
    public virtual List<Vertex> vertices
    {
        get
        {
            return verticesList;
        }
    }

    public void CreateVerticesList()
    {
        Vertex[] verticesArray = transform.GetComponentsInChildren<Vertex>();

        for (int i = 0; i < verticesArray.Length; i++)
        {
            verticesList.Add(verticesArray[i]);
        }
    }
}