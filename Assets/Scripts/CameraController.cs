using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {

    //контроллер игровой камеры

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

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
        MoveX();       //вызов функции движения по оси Х
        MoveY();       //вызов функции движения по оси У
    }
    

    private void MoveX()                       //перемешение влево-вправо (ось Х)
    {
        if (Input.GetKey(leftKey))
        {
            camera.transform.Translate(new Vector3(-speed, 0, 0));
        }
        else if (Input.GetKey(rightKey))
        {
            camera.transform.Translate(new Vector3(speed, 0, 0));
        }
    }

    private void MoveY()                       //перемешение вверх-вниз  (ось У)
    {
        if (Input.GetKey(upKey))
        {
            camera.transform.Translate(new Vector3(0, speed, 0));
        }
        else if (Input.GetKey(downKey))
        {
            camera.transform.Translate(new Vector3(0, -speed, 0));
        }
    }

   


}
