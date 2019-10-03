using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Graph))]
public class GraphEditor : Editor
{
    private const float VERTEX_TEXT_X_OFFSET = 0.3f;
    private const float VERTEX_TEXT_Y_OFFSET = 0.2f;

    private Graph graph;
    private SpriteRenderer renderer;

    private void OnEnable()
    {

        graph = target as Graph;
    }
    private void OnSceneGUI()
    {
        DrawGraph();
    }


    private void OnDisable()
    {
        foreach (Vertex vertex in graph.vertices)
        {
            DrawVertice(vertex, false);
        }
    }

    private void DrawGraph()
    {
        foreach (Vertex vertex in graph.vertices)
        {
            DrawVertice(vertex, true);
            foreach (Vertex connection in vertex.connections)
            {
                DrawEdge(vertex, connection);
            }
        }
    }

    private void DrawVertice(Vertex vertex, bool enable)
    {
        if (enable)
        {
            Handles.Label(new Vector3(vertex.transform.position.x + VERTEX_TEXT_X_OFFSET, vertex.transform.position.y + VERTEX_TEXT_Y_OFFSET, vertex.transform.position.z), vertex.name, EditorStyles.whiteLabel);
        }
        renderer = vertex.GetComponent<SpriteRenderer>();
        renderer.enabled = enable;
    }

    private void DrawEdge(Vertex vertex, Vertex connection)
    {
        if (vertex != null && connection != null)
        {
            Color oldColor = Handles.color;
            Handles.color = Color.white;
            Handles.DrawLine(vertex.transform.position, connection.transform.position);
            Handles.color = oldColor;
        }        
    }
}
