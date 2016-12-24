using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PayloadController : MonoBehaviour {


    //private int heroesNear = 0;

    public List<int> heroesList;

	// Use this for initialization
	void Start ()
    {
        heroesList = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    
    void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "Hero")
        {
            //heroesNear++;
            if (!hit.GetComponent<Portrait>().isDead)
            {
                heroesList.Add(hit.GetComponent<Portrait>().id);
                Debug.Log(hit.transform.tag + " near payload");
            }
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.transform.tag == "Hero")
        {

            //heroesNear--;
            RemoveHero(hit.GetComponent<Portrait>().id);
            Debug.Log(hit.transform.tag + " leave payload");
        }
    }

    public void RemoveHero (int heroId)
    {
        heroesList.Remove(heroId);
    }
}
