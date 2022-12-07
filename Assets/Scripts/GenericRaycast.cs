using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]

public class IntEvent : UnityEvent<int> { }

public class GenericRaycast : MonoBehaviour
{
    private Ray g_ray = new Ray(); // Define a ray for this check 
    private RaycastHit g_hitObject; // Use the RaycastHit type to get an object hit 
    public bool g_isHit = false;
    public LayerMask g_layerToHit; // Defining a layer that will be detected with our raycast
    public float g_rayLength = 5f; // Length of the ray 
    public IntEvent g_onObjectClicked;
    public KeyCode g_boundKey; // store the key that executes raycast

    public bool g_keyPressed; // a flag to show if a key is currently being pressed.
    public bool g_allowPickUp;
    public bool destructible;
    public bool objectPickedup;

    public GameObject Scrap1;
    public GameObject Scrap2;
    public GameObject Scrap3;
    public GameObject Scrap4;
    public GameObject Scrap5;

    void Update()
    {
        CastRay();

        if (Input.GetKeyDown(g_boundKey))
        {
            g_keyPressed = true;
            Debug.Log(g_boundKey.ToString() + " is being pressed.");
        }
        else
        {
            g_keyPressed = false;
            
        }

        if (g_keyPressed && g_isHit)
        {
            Debug.Log("Raycast Valid");
            GetTheThing();
            g_allowPickUp = true; // DT suggests this is less necessary, if g_boundKey is meant to be the pickup key, then just actually do the things you want AFTER pickup :)
        }
    }

    public void GetTheThing()
    {
        objectPickedup = true; // Make a boolean true for HAVING the object OR just update a thing on the UI (or both!)
        
        if (destructible)  // Destroy the g_hitObject object
        {
            Destroy(g_hitObject.transform.gameObject);
        }
    }

    private void CastRay()
    {
        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Creates a ray from the camera at the X & Y point of the mouse position 
        // Only really gets the direction of the ray - 'point to' <thing> 

        // Raycast function returns a boolean - returns an object hit to g_hitObject  
        if (Physics.Raycast(g_ray, out g_hitObject, g_rayLength, g_layerToHit))
        {
            if (g_isHit == false)
            {
               // g_onObjectClicked.Invoke(g_hitObject.transform.GetComponent<WorldItem>().ID);

                g_isHit = true;
            }
            
        }
        else if  (!(Physics.Raycast(g_ray, out g_hitObject, g_rayLength, g_layerToHit)))
        {
            g_isHit = false;
        }
    }
}

//if (Input.GetKeyDown(g_boundKey))
  //  CastRay();
//else if (Input.GetKeyUp(g_boundKey))
  //  g_isHit = false;