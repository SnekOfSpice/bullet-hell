using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public int health = 1000;
        

    public void HandleHit()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
