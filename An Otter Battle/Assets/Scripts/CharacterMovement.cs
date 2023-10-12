using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class CharacterMovement : MonoBehaviour
{
    Camera cam;
    PlayerMotor motor;
    public LayerMask movementMask;

    void Start ()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update () 
    {
        // Left Mouse button to move to location
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                // stop focusing any objects
            }
        }
        
        // Right Click Interaction
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check if we hit an interactable, 
                // if so set it as focus
            }
        }
    }
}