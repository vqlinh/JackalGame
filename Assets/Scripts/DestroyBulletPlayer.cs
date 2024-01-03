using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Gate") || collision.gameObject.CompareTag("Crep")|| collision.gameObject.CompareTag("TankAi"))
        {
           
            this.gameObject.SetActive(false);
        }
    }
}
