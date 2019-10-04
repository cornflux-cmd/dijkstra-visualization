using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Vertex))]
public class VertexEditor : Editor
{
    private Vertex vertex;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        vertex = target as Vertex;
        SyncConnections();
    }

    private void SyncConnections()
    {
        if (vertex.connections.Count > 0)
        {
            foreach (Vertex connection in vertex.connections)
            {
                if (!connection.connections.Contains(vertex))
                {
                    Debug.Log("here");
                    connection.connections.Add(vertex);
                }
            }
        }

    }
}
