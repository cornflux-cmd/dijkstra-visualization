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
        if (verticesArray.Length > 0)
        {
            for (int i = 0; i < verticesArray.Length; i++)
            {
                verticesList.Add(verticesArray[i]);
            }
        }

    }

    public void SyncConnections()
    {
        foreach (Vertex vertex in vertices)
        {
            if (vertex.connections.Count > 0)
            {
                vertex.connections.RemoveAll(v => v == null);
                foreach (Vertex connection in vertex.connections)
                {
                    if (connection != null)
                    {
                        connection.connections.RemoveAll(v => v == vertex);
                        connection.connections.Add(vertex);
                    }
                }
            }
        }
    }
}