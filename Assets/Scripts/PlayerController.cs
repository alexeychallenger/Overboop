using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    // скрипт для действий игрока

	void Start () {
	
	}
	void Update ()
    {
        TryBoop();    
	}

    private static void TryBoop ()                      //функция проверки попадания по носу
    {
        if (Input.GetMouseButtonDown(0))               
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);   //содание луча

            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, 200f, 1 << LayerMask.NameToLayer("Nose")))   //проверка попадания 
            {
                HeroController port = hit.collider.GetComponent<Nose>().selfHeroController;     //получение ссылки на объект носа
                port.NoseHit();                                                                 //вызов функции удара по носу
            }


        }
    }
}
