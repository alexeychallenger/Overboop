using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

    private static UnitController _instance;
    public static UnitController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UnitController>();
            }
            return _instance;
        }
    }

    public enum Heroes
    {
        Ana = 0,
        Bastion = 1,
        Dva = 2,
        Genji = 3,
        Hanzo = 4,
        Junkrat = 5,
        Lucio = 6,
        Mccree = 7,
        Mei = 8,
        Mercy = 9,
        Pharah = 10,
        Reaper = 11,
        Reinhardt = 12,
        Roadhog = 13,
        Soldier = 14,
        Sombra = 15,
        Symmetra = 16,
        Tornjorn = 17,
        Tracer = 18,
        Widowmaker = 19,
        Winston = 20,
        Zarya = 21,
        Zenyatta = 22
    };


    [Header("References")]

    public GameObject[] heroesPrefabs;
    public Transform unitContainer;
    public PayloadController payloadController;

    // privates
    private GameObject[] heroesPick;


    void Start()
    {
        Init();
    }
    
    public void Init ()
    {
        heroesPick = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            CreateUnit(i);
        }
    }
    private void CreateUnit(int unitId)
    {
        int unitType = Random.Range(0, heroesPrefabs.Length);

        GameObject hero;
        hero = (GameObject)Instantiate(heroesPrefabs[unitId], Vector3.zero, Quaternion.Euler(new Vector3(90, 0, 0)));
        hero.tag = "Hero";
        hero.GetComponent<Portrait>().id = unitId;
        hero.GetComponent<Portrait>().heroType = (Heroes)unitType;
        hero.transform.SetParent(unitContainer);
        hero.transform.position = GameController.Instance.spawnPoint.position;
        heroesPick[unitId] = hero;

        Debug.Log(heroesPick[unitId].name + " was picked.");
    }

    public void Dead(int heroId)
    {
        payloadController.RemoveHero(heroId);
    }

    public void Respawn(int heroId )
    {
        print(heroId + " in Respawn");

        Portrait respPortrait = heroesPick[heroId].GetComponent<Portrait>();
        heroesPick[heroId].GetComponent<Portrait>().RespawnPortrait(GameController.Instance.spawnPoint.position);
        payloadController.GetComponent<PayloadController>().RemoveHero(heroId);
      //  heroesPick[heroId].transform.position = ;
    }
}
