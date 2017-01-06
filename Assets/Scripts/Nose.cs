using UnityEngine;
using System.Collections;

public class Nose : MonoBehaviour {
    // SUPER KOSTIL
    public HeroController selfHeroController;

    void Start ()
    {
        selfHeroController = gameObject.GetComponentInParent<HeroController>();     //определение ссылки на объект носа
    }
}
