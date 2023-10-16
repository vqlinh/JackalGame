using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gated : MonoBehaviour
{

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grenade")
        {
            this.gameObject.SetActive(false);
        }
    }
}
