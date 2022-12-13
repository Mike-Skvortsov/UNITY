using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureSystem : MonoBehaviour
{
    public static int treasure;
    public GameObject Treasure1, Treasure2, Treasure3;
    void Start()
    {
        Treasure1.SetActive(false);
        Treasure2.SetActive(false);
        Treasure3.SetActive(false);
        treasure = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(treasure)
		{
            case 3:
                Treasure1.SetActive(true);
                Treasure2.SetActive(true);
                Treasure3.SetActive(true);
                break;
            case 2:
                Treasure1.SetActive(true);
                Treasure2.SetActive(true);
                Treasure3.SetActive(false);
                break;
            case 1:
                Treasure1.SetActive(true);
                Treasure2.SetActive(false);
                Treasure3.SetActive(false);
                break;
            case 0:
                Treasure1.SetActive(false);
                Treasure2.SetActive(false);
                Treasure3.SetActive(false);
                break;
        }
    }
}
