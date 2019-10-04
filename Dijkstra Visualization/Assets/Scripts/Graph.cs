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
        foreach (Vertex vertex in verticesList)
        {
            if (vertex.connections.Count > 0)
            {
                while (vertex.connections.Remove(vertex) || vertex.connections.Remove(null)) { }
                foreach (Vertex connection in vertex.connections)
                {
                    if (connection != null && !connection.connections.Contains(vertex))
                    {
                        connection.connections.Add(vertex);
                    }
                }
            }
        }
    }
}