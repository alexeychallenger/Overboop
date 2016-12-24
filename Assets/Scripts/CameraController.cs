using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {


    private Camera camera;
    
    [Header ("Stats")]
    public int speed;

	// Use this for initialization
	void Start ()
    {
        camera = Camera.FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveAD();
        MoveWS();  
    }
    

    private void MoveAD()                       //перемешение влево-вправо
    {
        if (Input.GetKey(KeyCode.A))
        {
            camera.transform.Translate(new Vector3(-speed, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            camera.transform.Translate(new Vector3(speed, 0, 0));
        }
    }

    private void MoveWS()                       //перемешение вверх-вниз
    {
        if (Input.GetKey(KeyCode.W))
        {
            camera.transform.Translate(new Vector3(0, speed, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            camera.transform.Translate(new Vector3(0, -speed, 0));
        }
    }

   


}
