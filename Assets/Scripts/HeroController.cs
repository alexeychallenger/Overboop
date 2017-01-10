using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //контроллер героя

    [Header ("References")]
    public SpriteRenderer sprite;   
    public GameObject blush;    
    public GameObject noseCollider; 
    public Animation anim; // по хорошему нужен контроллер, но мне пока покуй
    public Transform destination;

    

    [Header("Stats")]
    public UnitController.Heroes heroType;
    public int id;
    public float movementSpeed = 2f;
    public bool isDead;
    public float respawnTime = 5f;

    // private
    private Coroutine lateDestroy;
    private bool walk = false;
    private NavMeshAgent navMeshAgent;




    void Update()
    {
        if (!isDead)
        {
            Go();       //функция определения пункта назначения
        }
        else
        {

        }

    }

    public void NoseHit()       //функция удара по носу
    {
        if (!isDead)            //если не трупик
        {
            //NoseHit.SetActive(true);
            //anim.Play("NoseHit");
            anim.Stop();                                    //остановка анимации танцулек
            noseCollider.SetActive(false);                  //выкл носового коллайдера
            navMeshAgent.enabled = false;                   //отключение NavMeshAgent
            GetComponent<SphereCollider>().enabled = false; //выкл коллайдера
            isDead = true;                                  //статус трупик
            lateDestroy = StartCoroutine(LateDestroy());    //какая-то дичь с отсрочкой
            
            print("NoseHit " + name + ":" + id);
        }
    }

    public void RespawnHero(Vector3 pos)            //функция респауна героя
    {
        if (isDead)
        {
            anim.Play();                                    //вкл анимация 
            noseCollider.SetActive(true);                   //вкл носового коллайдера 
            navMeshAgent.enabled = true;                    //вкл NavMeshAgent
            navMeshAgent.transform.position = pos;
            GetComponent<SphereCollider>().enabled = true;  //вкл коллайдера
            isDead = false;                                 //статус "не трупик"
           // transform.position = pos;                       //место респауна
            print(name + ":" + id + " is respawned.");
        }
    }

    /*
    private void Walking()
    {
        if (walk)
        {

        }

    }*/

   

    public void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Destination").transform;    //определение пункта назначения
        navMeshAgent = GetComponent<NavMeshAgent>();                                //определения ссылки на NavMeshAgent
        name = name.Remove(name.IndexOf("(Clone)"), 7);                             //чистка мусора из имени объекта героя
    }

    public void Go()                                                //функция определения пункта назначения
    {
        navMeshAgent.SetDestination(destination.position);          

        //navMeshAgent.Move();
    }

    public void Respawn()
    {

    }

    IEnumerator LateDestroy()                                   //продолжение дичич с отсрочкой выполнения
    {   
        yield return new WaitForSeconds(respawnTime);           //ожидание времени респауна
        UnitController.Instance.Respawn(id);                    //вызов функции респауна героя в контроллере героев на сцене
        //Destroy(this.gameObject);
    }
}
