using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nhadan : MonoBehaviour
{
    private Animator nhadan;
    public Enemyphai enemyphai;

    void Start()
    {
        nhadan = GetComponent<Animator>();
        nhadan.SetBool("no", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grenade")
        {
            nhadan.SetBool("no", true);
            enemyphai.Show();
        }
    }
}

