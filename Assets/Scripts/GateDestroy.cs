﻿using UnityEngine;

public class GateDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grenade") this.gameObject.SetActive(false);
    }
}
