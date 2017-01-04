using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {


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
            Go();
        }
        else
        {

        }

    }

    public void NoseHit()
    {
        if (!isDead)
        {
            //NoseHit.SetActive(true);
            //anim.Play("NoseHit");
            anim.Stop();
            noseCollider.SetActive(false);
            navMeshAgent.enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            isDead = true;
            lateDestroy = StartCoroutine(LateDestroy());


            print("NoseHit " + name + ":" + id);
        }
    }

    public void RespawnHeroController(Vector3 pos)
    {
        if (isDead)
        {
            anim.Play();
            noseCollider.SetActive(true);
            navMeshAgent.enabled = true;
            GetComponent<SphereCollider>().enabled = true;
            isDead = false;
            transform.position = pos;
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
        destination = GameObject.FindGameObjectWithTag("Destination").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        name = name.Remove(name.IndexOf("(Clone)"), 7);
    }

    public void Go()
    {
        navMeshAgent.SetDestination(destination.position);

        //navMeshAgent.Move();
    }

    public void Respawn()
    {

    }

    IEnumerator LateDestroy()
    {
        yield return new WaitForSeconds(respawnTime);
        UnitController.Instance.Respawn(id);
        //Destroy(this.gameObject);
    }
}
