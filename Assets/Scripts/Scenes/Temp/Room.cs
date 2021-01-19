using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Range(0.0f, 150.0f)]
    public float width = 8;
    [Range(0.0f, 75.0f)]
    public float height = 4;

    [HideInInspector]
    public Vector3 center;

    private void Start()
    {
        center = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }
}
