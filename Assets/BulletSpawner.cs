using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float TimeBetweenShots = 2;
    public float BulletSpeed = 10;
    private float cooldown = 0;

    private GameObject player;
    private GameObject gameLogic;
    private void Awake()
    {
        player = GameObject.Find("Player");
        gameLogic = GameObject.Find("GameLogic");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }
        Vector3 playerPosition = player.transform.position;
        cooldown = TimeBetweenShots;
        GameObject newBullet = gameLogic.GetComponent<GameLogic>().Shoot(transform.position, playerPosition);
        newBullet.GetComponent<Bullet>().speed = BulletSpeed;
        newBullet.GetComponent<Bullet>().SetIsPlayerOwned(false);
        newBullet.layer = LayerMask.NameToLayer("Player Hittable");
    }
}
