using UnityEngine;
using HTC.UnityPlugin.Vive;
public class hand_things : MonoBehaviour
{
    private void Update()
    {
        // get trigger 
        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
        {
            Debug.Log("oooooooooooooooo");
        }
    }
}