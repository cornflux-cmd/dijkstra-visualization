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
    private Vector3 tempVertexPosition;
    private Vector3 tempConnectionPosition;

    private void OnEnable()
    {
        graph = target as Graph;
        graph.CreateVerticesList();
        path = graph.GetComponent<ShortestPath>();
    }

    private void OnSceneGUI()
    {
        if (graph.vertices != null && graph.vertices.Count > 0)
        {
            graph.SyncConnections();
            path.vertices = graph.vertices;
            path.CalculateShortestPath();
            DrawGraph();
        }
    }

    private void OnDisable()
    {
            graph.vertices.Clear();
            isBuildButtonPressed = false;
    }

    private void DrawGraph()
    {
        foreach (Vertex vertex in graph.vertices)
        {
            visitedVertices.Add(vertex.name);
            foreach (Vertex connection in vertex.connections)
            {
                if (visitedVertices.Contains(connection.name)) continue;
                if (path.vertices.Contains(vertex) && path.vertices.Contains(connection))
                {
                    if (vertex == path.start || connection == path.start)
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
            tempVertexPosition = vertex.transform.position;
            tempConnectionPosition = connection.transform.position;
            Handles.DrawLine(tempVertexPosition, tempConnectionPosition);
            Handles.color = oldColor;
            Handles.Label((tempConnectionPosition + tempVertexPosition) / 2, Vector3.Distance(tempConnectionPosition, tempVertexPosition).ToString(), EditorStyles.whiteLabel);
        }
    }
}
