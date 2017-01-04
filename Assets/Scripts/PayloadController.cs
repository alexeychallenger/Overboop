using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PayloadController : MonoBehaviour {


    //private 

    private float payloadSpeed = 0f;
    private NavMeshAgent navMeshAgent;

    [Header ("Stats")]

    public float speedCoefficient = 0.5f;
    public List<int> heroesList;
    public Transform destination;

	// Use this for initialization
	void Start ()
    {
        heroesList = new List<int>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = destination.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpeedUpdate();
	}

    
    void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "Hero")
        {
            //heroesNear++;
            if (!hit.GetComponent<HeroController>().isDead)
            {
                heroesList.Add(hit.GetComponent<HeroController>().id);
                Debug.Log(hit.transform.tag + " near payload");
            }
        }
        if (hit.transform.tag == "Navigation Point")
        {
            navMeshAgent.destination = hit.transform.GetComponent<PayloadNavigationPointController>().nextPoint.position;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.transform.tag == "Hero")
        {

            //heroesNear--;
            RemoveHero(hit.GetComponent<HeroController>().id);
            Debug.Log(hit.transform.tag + " leave payload");
        }
    }

    public void RemoveHero (int heroId)
    {
        heroesList.Remove(heroId);
    }

    private void SpeedUpdate ()
    {
        payloadSpeed = speedCoefficient * heroesList.Count;
        navMeshAgent.speed = payloadSpeed;
    }

}
