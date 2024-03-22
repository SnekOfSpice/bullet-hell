using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Shoot(Transform player)
    {
        GameObject newBullet = Instantiate(bullet, transform);
        newBullet.transform.position = player.transform.position;
        newBullet.transform.rotation = player.transform.rotation;
        return newBullet;
    }
}
