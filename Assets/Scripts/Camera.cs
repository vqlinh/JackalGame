using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;

    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(Player.position.x, -1.17f, float.MaxValue);
        cameraPosition.y = Mathf.Clamp(Player.position.y, -4f, float.MaxValue);
        cameraPosition.z = -20;
        transform.position = cameraPosition;
    }
}
