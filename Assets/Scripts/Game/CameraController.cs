using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float sensitivity = 10;
    [SerializeField] private float limit = 80;
    private float xInput;
    private float yInput;

    Touch touch;


    private void Update()
    {
        

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;
                case TouchPhase.Moved:
                    //Debug.Log("Viewport Point: " + Camera.main.ScreenToViewportPoint(touch.position));
                    var touchAxisX = touch.deltaPosition.normalized.x;
                    var touchAxisY = touch.deltaPosition.normalized.y;
                    touchAxisX = Mathf.Clamp(touchAxisX, -1, 1);
                    touchAxisY = Mathf.Clamp(touchAxisY, -1, 1);


                    xInput = transform.localEulerAngles.y + touchAxisX * Time.deltaTime * sensitivity;
                    yInput -= touchAxisY * Time.deltaTime * sensitivity;
                    yInput = Mathf.Clamp(yInput, -80, 80);

                    transform.localEulerAngles = new Vector3(-yInput, xInput);
                    transform.position = transform.localRotation * new Vector3(1, 1, 1) + new Vector3(0, 0);

                    //xInput = transform.localEulerAngles.y + touch.deltaPosition
                    break;
            }
        
        }

        //xInput = transform.localEulerAngles.y + -Input.GetAxis("Horizontal") * sensitivity;
        //Debug.Log("Input " + Input.GetAxis("Horizontal"));
        //yInput += Input.GetAxis("Vertical") * sensitivity;
        //yInput = Mathf.Clamp(yInput, -limit, limit);

        //transform.localEulerAngles = new Vector3(-yInput, xInput, 0);
        //transform.position = transform.localRotation * new Vector3(1, 1, 1) + new Vector3(0, 0);
    }
}