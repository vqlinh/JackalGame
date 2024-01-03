using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnmNade : MonoBehaviour
{
    private Animator Grenade;
    private bool isFlying = false; // Khởi tạo biến kiểm tra grenade đã được phóng lên hay chưa

    private void Awake()
    {
        Grenade = GetComponent<Animator>();
        StartCoroutine(ExplodeAfterDelay());
        Grenade.SetBool("fly", false);
    }

    void Update()
    {
        if (Input.GetKey((KeyCode)'x')) isFlying = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( isFlying) Grenade.SetBool("bum", true);
    }

    private IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(0.9f);
        IsExplosion();
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    public void IsExplosion()
    {
        Grenade.SetBool("bum", true);
    }
}
