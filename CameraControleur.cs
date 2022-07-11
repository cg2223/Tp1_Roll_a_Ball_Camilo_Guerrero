using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControleur : MonoBehaviour
{
    public GameObject player;
    private Vector3 Offset;

   
    void Start()
    {
        Offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + Offset;
    }
}
