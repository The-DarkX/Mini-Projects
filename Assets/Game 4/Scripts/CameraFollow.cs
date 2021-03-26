using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(1, 1, 1);
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
