using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShortestPath : MonoBehaviour
{
    [SerializeField]
    private Vertex startVertex;
    [SerializeField]
    private Vertex finishVertex;

    private List<Vertex> initialVerticesList = new List<Vertex>();
    private List<Vertex> tempVerticesList = new List<Vertex>();
    private List<Vertex> pathVerticesList = new List<Vertex>();
    private Dictionary<Vertex, float> distances = new Dictionary<Vertex, float>();
    private Dictionary<Vertex, Vertex> previous = new Dictionary<Vertex, Vertex>();
    private Vertex tempVertex;
    private float tempDistance;

    public virtual List<Vertex> vertices
    {
        set
        {
            initialVerticesList = value;
        }
        get
        {
            return pathVerticesList;
        }
    }

    public virtual Vertex start
    {
        get
        {
            return startVertex;
        }
    }

    public virtual Vertex finish
    {
        get
        {
            return finishVertex;
        }
    }


    public void CalculateShortestPath()
    {
        if (startVertex == finishVertex)
        {
            pathVerticesList.Clear();
        } else
        {
            if (startVertex != null && finishVertex != null)
            {
                tempVerticesList.Clear();
                distances.Clear();
                pathVerticesList.Clear();
                previous.Clear();
                foreach (Vertex vertex in initialVerticesList)
                {
                    if (vertex != null)
                    {
                        distances[vertex] = int.MaxValue;
                        previous[vertex] = null;
                        tempVerticesList.Add(vertex);
                    }                    
                }
                distances[startVertex] = 0;
                while (tempVerticesList.Count > 0)
                {
                    tempVertex = tempVerticesList.OrderBy(v => distances[v]).First();
                    tempVerticesList.Remove(tempVertex);
                    foreach (Vertex connection in tempVertex.connections)
                    {
                        if (!tempVerticesList.Contains(connection)) continue;
                        tempDistance = distances[tempVertex] + Vector3.Distance(tempVertex.transform.position, connection.transform.position);
                        if (tempDistance < distances[connection])
                        {
                            distances[connection] = tempDistance;
                            previous[connection] = tempVertex;
                        }
                    }
                }
                tempVerticesList = new List<Vertex>();
                tempVertex = finishVertex;
                while (previous[tempVertex] != null)
                {
                    tempVerticesList.Add(previous[tempVertex]);
                    tempVertex = previous[tempVertex];
                }
                tempVerticesList.Add(finishVertex);
                pathVerticesList = tempVerticesList;
            }
        }
    }
}
