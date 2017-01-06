using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PayloadController : MonoBehaviour {

    //контроллер телеги


    //private 

    private float payloadSpeed = 0f;
    private NavMeshAgent navMeshAgent;

    [Header ("Stats")]

    public float speedCoefficient = 0.5f;   //коэффициент увеличения скорости в завасимости от количества героев рядом с телегой
    public List<int> heroesList;            //список героев рядом с телегой
    public Transform destination;           //точка назначения движения телеги

	// Use this for initialization
	void Start ()
    {
        heroesList = new List<int>();
        navMeshAgent = GetComponent<NavMeshAgent>();                //определение ссылки на NavMeshAgent
        navMeshAgent.destination = destination.position;            //задание пункта назначения
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpeedUpdate();              //вызов функции обновление скорости
	}

    
    void OnTriggerEnter(Collider hit)           //вызывается при заходе в триггер телеги другого коллайдера
    {
        if (hit.transform.tag == "Hero")            //проверка тега "Hero" на попавшемся коллайдере
        {
            //heroesNear++;
            if (!hit.GetComponent<HeroController>().isDead)         //проверка статуса смерти у героя
            {
                heroesList.Add(hit.GetComponent<HeroController>().id);  //добавление героя в список героев рядом с телегой
                Debug.Log(hit.transform.tag + " near payload");
            }
        }
        if (hit.transform.tag == "Navigation Point")            //проверка тега "Navigation Point" на попавшемся коллайдере
        {
            navMeshAgent.destination = hit.transform.GetComponent<PayloadNavigationPointController>().nextPoint.position; //смена пункта назначения на следующий
        }
    }

    void OnTriggerExit(Collider hit)        //вызыветься при выхооде коллайдера с триггера
    {
        if (hit.transform.tag == "Hero")        //проверка тега "Hero" на попавшемся коллайдере
        {

            //heroesNear--;
            RemoveHero(hit.GetComponent<HeroController>().id);      //вызов функции удаления героя из списка
            Debug.Log(hit.transform.tag + " leave payload");        
        }
    }

    public void RemoveHero (int heroId)                 //функция удаления героя из списка
    {
        heroesList.Remove(heroId);
    }

    private void SpeedUpdate ()               //функция расчета текущей скорости телеги
    {
        payloadSpeed = speedCoefficient * heroesList.Count;     //коэфициент на кол-во героев рядом с телегой
        navMeshAgent.speed = payloadSpeed;
    }

}
