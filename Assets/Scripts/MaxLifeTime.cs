using UnityEngine;

public class MaxLifeTime : MonoBehaviour
{
    public float Time;
    void Start()
    {
        Destroy(this.gameObject, Time);
    }
}
