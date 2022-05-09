using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        CameraController();
    }

    private void CameraController()
    {
        //Up
        if (Input.GetKeyDown(KeyCode.DownArrow) && animator.GetInteger("Side") == 1)
        {
            //ToFront
            animator.SetInteger("Side", 2);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && animator.GetInteger("Side") == 1)
        {
            //ToSide
            animator.SetInteger("Side", 3);
        }

        //Front
        if (Input.GetKeyDown(KeyCode.UpArrow) && animator.GetInteger("Side") == 2)
        {
            //ToUp
            animator.SetInteger("Side", 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && animator.GetInteger("Side") == 2)
        {
            //ToSide
            animator.SetInteger("Side", 3);
        }

        //Side
        if (Input.GetKeyDown(KeyCode.UpArrow) && animator.GetInteger("Side") == 3)
        {
            //ToUp
            animator.SetInteger("Side", 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && animator.GetInteger("Side") == 3)
        {
            //ToFront
            animator.SetInteger("Side", 2);
        }
    }
}
