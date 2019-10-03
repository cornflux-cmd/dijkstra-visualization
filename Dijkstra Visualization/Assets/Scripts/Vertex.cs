using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    [SerializeField]
    private List<Vertex> connectionsList = new List<Vertex>();

    public virtual List<Vertex> connections
    {
        get
        {
            return connectionsList;
        }
    }
}
