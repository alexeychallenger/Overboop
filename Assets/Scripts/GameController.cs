using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [Header ("References")]

    public Transform spawnPoint;

    // privates



    private static GameController _instance;
    
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
            }
            return _instance;
        }
    }

   

    void Start ()
    {
       
    }



	void Update ()
    {
        
    }
}
