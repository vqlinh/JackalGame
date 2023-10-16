using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhalinh : MonoBehaviour
{
    private Animator nhadan;
    public Soldier soldier;
    // Start is called before the first frame update
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
            soldier.Show();
        }
    }
}
