using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

    //контроллер героев на сцене

    //статический метод определения ссылки на компонент
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


    //перечисление существующих героев и их индексы
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

    public GameObject[] heroesPrefabs;  //массив префабов всех существующих героев
    public Transform heroContainer;     //контейнер содержащий героев на сцене
    public PayloadController payloadController; 

    // privates
    private GameObject[] heroesPick; //массив выбранных героев на сцене


    void Start()
    {
        Init();
    }
    
    public void Init ()             //инициализация пика героев на сцене
    {
        heroesPick = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            CreateHero(i); //вызов функции создания героя где i является id героя
        }
    }
    private void CreateHero(int heroId) //функция создания героя
    {
        int heroType = Random.Range(0, heroesPrefabs.Length);           //рандломное определение типа героя из префабов

        GameObject hero;
        hero = (GameObject)Instantiate(heroesPrefabs[heroId], GameController.Instance.spawnPoint.position, Quaternion.Euler(new Vector3(90, 0, 0)));   //помещение префаба на сцену в точке спауна
        hero.tag = "Hero";                                                      //присваивания тега
        hero.layer = 11;                                                        //присваивания слоя с героями
        hero.GetComponent<HeroController>().id = heroId;                        //присваивание id героя
        hero.GetComponent<HeroController>().heroType = (Heroes)heroType;        //присваивание индекса героя 
        hero.transform.SetParent(heroContainer);                                //перемещение героя в контейнев в иерархии сцены
        //hero.transform.position = GameController.Instance.spawnPoint.position;
        heroesPick[heroId] = hero;                //занесение созданого героя в массив с пиком героев

        Debug.Log(heroesPick[heroId].name + " was picked.");
    }

    public void Dead(int heroId)
    {
        payloadController.RemoveHero(heroId);       
    }

    public void Respawn(int heroId )                //функция респауна героя
    {
        print(heroId + " in Respawn");

        HeroController respHeroController = heroesPick[heroId].GetComponent<HeroController>();      //определение ссылки на компонент контроллера героя
        respHeroController.RespawnHero(GameController.Instance.spawnPoint.position);   //вызов функции респауна в контроллере героя на месте спауна
        payloadController.GetComponent<PayloadController>().RemoveHero(heroId);        //вызов функции удаление героя из списка героев рядом с телегой
      //  heroesPick[heroId].transform.position = ;     
    }
}
