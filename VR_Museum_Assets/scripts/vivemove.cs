using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using HTC.UnityPlugin.Vive;


public class vivemove : MonoBehaviour
{

    //[SerializeField]
    public Transform view;
    public CharacterController controller;
    public float speed = 5;

public SteamVR_Input_Sources handType;
public SteamVR_Behaviour_Pose controllerPose;
public SteamVR_Action_Boolean grabAction;

private GameObject collidingObject; // 1
private GameObject objectInHand; // 2




    // Update is called once per frame
    void Update()
    {
        //this.controller.SimpleMove(this.view.forward * this.speed);

        if (this.controller.isGrounded)
        {

                if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger))
                {
                    this.controller.SimpleMove(this.view.forward * this.speed);
                    Debug.Log("oooooooooooooooo");
                }

        }
        else
        {
            this.controller.SimpleMove(Vector3.zero);
        }



            if (ViveInput.GetPadTouchAxis(HandRole.RightHand).x > 0.1 || ViveInput.GetPadTouchAxis(HandRole.RightHand).x < -0.1)
            {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + ViveInput.GetPadTouchAxis(HandRole.RightHand).x * 0.25f, 0);
            //this.controller.SimpleMove(this.view.forward * this.speed);
            //this.transform.localEulerAngles = new Vector3(0, 13f, 0);
            //transform.localEulerAngles = new Vector3(0, same.localEulerAngles.y + 30f, 0);
            Debug.Log("oooooooooooooooo");
            }



        if (ViveInput.GetPadTouchAxis(HandRole.RightHand).y > 0.2 || ViveInput.GetPadTouchAxis(HandRole.RightHand).y < -0.2)
        {
            this.controller.SimpleMove(this.view.forward * ViveInput.GetPadTouchAxis(HandRole.RightHand).y * 6f);
            //this.controller.SimpleMove(this.view.forward * this.speed);
            //this.transform.localEulerAngles = new Vector3(0, 13f, 0);
            //transform.localEulerAngles = new Vector3(0, same.localEulerAngles.y + 30f, 0);
            Debug.Log("oooooooooooooooo");
        }



        Debug.Log(ViveInput.GetPadTouchAxis(HandRole.RightHand).x);

    }
}


