﻿using System.Collections;
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
    public static GraphEditor editor;

    private void OnEnable()
    {
        graph = target as Graph;
        graph.CreateVerticesList();
        path = graph.GetComponent<ShortestPath>();
        DrawVertices(true);
    }
    private void OnSceneGUI()
    {
        if (graph.vertices.Count > 0)
        {
            path.vertices = graph.vertices;
            path.CalculateShortestPath();
            DrawGraph();
        }
    }
    private void OnDisable()
    {
        DrawVertices(false);
        graph.vertices.Clear();
    }

    private void DrawGraph()
    {

        foreach (Vertex vertex in graph.vertices)
        {
            DrawVertexLabel(vertex);
            foreach (Vertex connection in vertex.connections)
            {
                if (path.vertices.Contains(vertex) && path.vertices.Contains(connection))
                {
                    if (vertex == path.start)
                    {
                        DrawEdge(vertex, connection, StartEdgeCode);
                    } else
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
            } else if (variant == StartEdgeCode)
            {
                Handles.color = Color.red;
            }

            Handles.DrawLine(vertex.transform.position, connection.transform.position);
            Handles.color = oldColor;
        }
    }
}
