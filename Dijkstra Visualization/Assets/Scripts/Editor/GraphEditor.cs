using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Graph))]
public class GraphEditor : Editor
{
    private const float VertexTextOffsetX = 0.3f;
    private const float VertexTextOffsetY = 0.2f;
    private const int NormalEdgeCode = 0;
    private const int PathEdgeCode = 1;
    private const int StartEdgeCode = 2;

    private Graph graph;
    private ShortestPath path;
    private SpriteRenderer renderer;
    private bool isBuildButtonPressed;
    private List<string> visitedVertices = new List<string>();

    private void Build()
    {
        graph = target as Graph;
        graph.CreateVerticesList();
        path = graph.GetComponent<ShortestPath>();
        DrawVertices(true);
        graph.SyncConnections();
    }

    private void OnSceneGUI()
    {
        if (isBuildButtonPressed && graph.vertices.Count > 0)
        {
            path.vertices = graph.vertices;
            path.CalculateShortestPath();
            DrawGraph();
        }
    }

    private void OnDisable()
    {
        if (isBuildButtonPressed)
        {
            DrawVertices(false);
            graph.vertices.Clear();
            isBuildButtonPressed = false;
        }
    }

    private void DrawGraph()
    {

        foreach (Vertex vertex in graph.vertices)
        {
            visitedVertices.Add(vertex.name);
            DrawVertexLabel(vertex);
            foreach (Vertex connection in vertex.connections)
            {
                if (visitedVertices.Contains(connection.name)) continue;
                if (path.vertices.Contains(vertex) && path.vertices.Contains(connection))
                {
                    if (vertex == path.start)
                    {
                        DrawEdge(vertex, connection, StartEdgeCode);
                    }
                    else
                    {
                        DrawEdge(vertex, connection, PathEdgeCode);
                    }

                }
                else
                {
                    DrawEdge(vertex, connection, NormalEdgeCode);
                }
            }
        }
        visitedVertices.Clear();
    }

    private void DrawVertices(bool enable)
    {
        foreach (Vertex vertex in graph.vertices)
        {
            renderer = vertex.GetComponent<SpriteRenderer>();
            renderer.enabled = enable;
        }

    }

    private void DrawVertexLabel(Vertex vertex)
    {
        Handles.Label(vertex.transform.position, vertex.name, EditorStyles.whiteLabel);
    }

    private void DrawEdge(Vertex vertex, Vertex connection, int variant)
    {
        if (vertex != null && connection != null)
        {
            Color oldColor = Handles.color;
            if (variant == NormalEdgeCode)
            {
                Handles.color = Color.white;

            }
            else if (variant == PathEdgeCode)
            {
                Handles.color = Color.green;
            }
            else if (variant == StartEdgeCode)
            {
                Handles.color = Color.red;
            }

            Handles.DrawLine(vertex.transform.position, connection.transform.position);
            Handles.color = oldColor;
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Build"))
        {
            isBuildButtonPressed = true;
            Build();
        }
    }
}
