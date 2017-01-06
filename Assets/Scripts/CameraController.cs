using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {

    //контроллер игровой камеры

    private Camera camera;  //ссылка камеру
    
    [Header ("Stats")]
    public int speed;       //скорость перемещения камеры

	// Use this for initialization
	void Start ()
    {
        camera = Camera.FindObjectOfType<Camera>();     //определение ссылки на камеру
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveAD();       //вызов функции движения по оси Х
        MoveWS();       //вызов функции движения по оси У
    }
    

    private void MoveAD()                       //перемешение влево-вправо (ось Х)
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

    private void MoveWS()                       //перемешение вверх-вниз  (ось У)
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
