using UnityEngine;
using System.Collections;

public class Portrait : MonoBehaviour {


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
        /*
        if (!isBlushed)
        {
            transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
        }*/
        //Debug.DrawLine(transform.position, transform.position + navMeshAgent. );

    }

    public void Blush() {
        if (!isDead) {
            //blush.SetActive(true);
            //anim.Play("blush");
            noseCollider.SetActive(false);

            navMeshAgent.speed = 0;
            //navMeshAgent.enabled = false;
            GetComponent<SphereCollider>().enabled = false;


            isDead = true;
            lateDestroy = StartCoroutine(LateDestroy());


            print("blush " + sprite.sprite.name);
        }
    }
    
    public void RespawnPortrait(Vector3 pos)
    {
        noseCollider.SetActive(true);
        navMeshAgent.speed = 7;
        GetComponent<SphereCollider>().enabled = true;
        isDead = false;
        transform.position = pos;
        print(name + " is respawned.");
    }

    private void Walking()
    {
        if (walk)
        {

        }

    }

   

    public void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Destination").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        yield return new WaitForSeconds(5f);
        UnitController.Instance.Respawn(id);
        //Destroy(this.gameObject);
    }
}
