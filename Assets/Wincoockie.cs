﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Wincoockie : MonoBehaviour
{
    [SerializeField]
    private Image WinScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            WinScreen.enabled = true;
        }
    }
}
