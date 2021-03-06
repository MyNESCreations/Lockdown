﻿using UnityEngine;
using System.Collections;

public class KT_LockedRoom : MonoBehaviour
{

    [SerializeField]
    GameObject door;

    public enum ColorDoor
    {
        RED,
        YELLOW,
        BLUE,
        GRAY
    }

    public ColorDoor myDoor = ColorDoor.GRAY;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponentInChildren<Key>())
        {
            if (other.gameObject.GetComponent<LabTech>())
            {
                if (myDoor == ColorDoor.GRAY)
                {
                    if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.RED)
                    {
                        door.SetActive(false);
                    }
                }
            }
        }
    }
}
