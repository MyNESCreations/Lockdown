﻿//Name: Kevin Thomas
//Date: 10/9/16
//Credit:
//
//Purpose: To create movement for characters

using UnityEngine;
using System.Collections;

public class KT_CharacterMovement : MonoBehaviour
{
    [SerializeField]
    Light psyGlow;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float distanceToTarget;

    [SerializeField]
    float maxDist = 5;

    [SerializeField]
    float moveSpeed = 3;

    [SerializeField]
    GameObject thingToSwitchTo;

    public GameObject currentControl;

    public static bool up;
    public static bool right;
    public static bool down;
    public static bool left;
    bool lightOn = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentControl = GameObject.FindGameObjectWithTag("Player");
        currentControl.GetComponent<Light>().enabled = false;
        down = true;
    }

    // Update is called once per frame
    void Update()
    {
        psyGlow = currentControl.GetComponent<Light>();
        if (lightOn)
            psyGlow.enabled = true;
        else
        {
            psyGlow.enabled = false;
        }

        CharacterMovement();
        CanControl();

        //if (Input.GetButtonDown("Fire1") && currentControl == GameObject.FindGameObjectWithTag("Player"))
        //{
        //    if (thingToSwitchTo.GetComponent<Unit>().currentFaction == Unit.Faction.CONTROLLABLE)
        //    {
        //        currentControl = thingToSwitchTo;
        //        currentControl.GetComponent<Unit>().isControlled = true;
        //    }
        //}
        //else if (Input.GetButtonDown("Fire1") && currentControl == thingToSwitchTo)
        //{
        //    currentControl.GetComponent<Unit>().isControlled = false;
        //    currentControl.GetComponent<Unit>().originalPosition = currentControl.transform.position;
        //    currentControl.GetComponent<Unit>().section = 0;
        //    currentControl.GetComponent<Unit>().closestDistance = Mathf.Infinity;
        //    currentControl.GetComponent<Unit>().FindNearestWaypoint();
        //    currentControl = GameObject.FindGameObjectWithTag("Player");
        //}
    }

    void CharacterMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentControl.transform.position += currentControl.transform.up * moveSpeed;

            up = true;
            right = false;
            down = false;
            left = false;

        }
        if (Input.GetKey(KeyCode.A))
        {
            currentControl.transform.position += -currentControl.transform.right * moveSpeed;
            up = false;
            right = false;
            down = false;
            left = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentControl.transform.position += currentControl.transform.right * moveSpeed;
            up = false;
            right = true;
            down = false;
            left = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentControl.transform.position += -currentControl.transform.up * moveSpeed;
            up = false;
            right = false;
            down = true;
            left = false;
        }
        currentControl.GetComponent<Unit>().lookDirections[0].gameObject.SetActive(up);
        currentControl.GetComponent<Unit>().lookDirections[1].gameObject.SetActive(right);
        currentControl.GetComponent<Unit>().lookDirections[2].gameObject.SetActive(down);
        currentControl.GetComponent<Unit>().lookDirections[3].gameObject.SetActive(left);
    }

    void CanControl()
    {
        Vector2 drawDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - currentControl.transform.position);
        currentControl.layer = 2;
        if (Physics2D.Raycast(currentControl.transform.position, drawDirection, maxDist))
        {

            RaycastHit2D hit;
            //Ray2D inSight = new Ray2D(transform.position, Vector2.right);
            hit = Physics2D.Raycast(currentControl.transform.position, drawDirection, maxDist);
            Debug.DrawRay(currentControl.transform.position, drawDirection, Color.magenta);
            //if (hit.collider != null && (hit.collider.GetComponent<Unit>().currentFaction != Unit.Faction.CONTROLLABLE || hit.collider.GetComponent<Unit>().currentFaction != Unit.Faction.UNCONTROLLABLE))
            //    Debug.Log(hit.collider.name);

            if (hit.collider.gameObject.GetComponent<Unit>() != null)
            {
                    lightOn = true;
                if (hit.collider.gameObject.GetComponent<Unit>().isControlled == false && hit.collider.gameObject.GetComponent<Unit>().currentFaction == Unit.Faction.CONTROLLABLE)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        currentControl.GetComponent<Unit>().isControlled = false;
                        currentControl.layer = 0;
                        currentControl = hit.collider.gameObject;
                        currentControl.GetComponent<Unit>().isControlled = true;
                        Debug.Log("player controlled");
                        //lightOn = false;      
                    }
                }
            }
        }
            else
            {
                lightOn = false;
            }
    }
}