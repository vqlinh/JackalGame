using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nhadantrai : MonoBehaviour
{
    private Animator nhadan;
    public Enemytrai enemytrai;

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
            enemytrai.Show();
        }
    }
}
