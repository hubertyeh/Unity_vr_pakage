using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    //[SerializeField]
    public Transform view;
    public CharacterController controller;
    public float speed = 5;

    public bool HasPointer { set; private get; }



    // Update is called once per frame
    void Update()
    {
        
        if (this.controller.isGrounded)
        {
            if (Input.GetMouseButton(0) && !this.HasPointer)
            {
                this.controller.SimpleMove(this.view.forward * this.speed);
            }
        }
        else
        {
            this.controller.SimpleMove(Vector3.zero);
        }
 
        

    }
}
