﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeArea : MonoBehaviour
{
    private PlayerManager playerManager;

    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Hurt()
    {
        playerManager.GetDamage(damage);
        Invoke("Hurt", 0.2f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col && col.GetComponent<Hero>())
        {
            Invoke("Hurt", 1f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col && col.GetComponent<Hero>())
        {
            CancelInvoke("Hurt");
        }
    }
}
