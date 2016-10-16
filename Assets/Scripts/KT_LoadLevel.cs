﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KT_LoadLevel : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
