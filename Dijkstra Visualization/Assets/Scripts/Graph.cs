using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public virtual Vertex[] vertices
    {
        get
        {
            return transform.GetComponentsInChildren<Vertex>();
        }
    }
}