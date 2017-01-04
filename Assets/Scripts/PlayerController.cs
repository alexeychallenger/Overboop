using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
	void Start () {
	
	}
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, 200f, 1 << LayerMask.NameToLayer("Nose")))
            {
                HeroController port = hit.collider.GetComponent<Nose>().selfHeroController;
                port.NoseHit();
            }


        }
	}
}
