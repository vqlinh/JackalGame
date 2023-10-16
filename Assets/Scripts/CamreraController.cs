using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamreraController : MonoBehaviour
{
    public Transform Player;
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Camera = transform.position;
        Camera.x = Player.position.x;
        Camera.y = Player.position.y;

        Camera.z = -20;
        transform.position = Camera;

    }
}
