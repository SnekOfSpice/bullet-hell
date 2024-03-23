using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour, IDamagable
{
    public float moveSpeed = 20;
    public GameObject gameLogic;
    public int health = 3;

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDir = new Vector2();
        if (Input.GetKey(KeyCode.W))
        {
            MoveDir.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDir.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveDir.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveDir.x += 1;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        

        MoveDir = MoveDir.normalized;
        Vector2 newPos = transform.position + MoveDir * moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -8.88f, 8.88f);
        newPos.y = Mathf.Clamp(newPos.y, -5f, 5f);
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, AngleFromMouseToPlayer() + 90));
    }

    void Shoot()
    {
        Vector2 objPos = transform.position;//gets player position
        Vector2 mousePos = Input.mousePosition;//gets mouse postion
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        GameObject newBullet = gameLogic.GetComponent<GameLogic>().Shoot(transform.position, mousePos);
        newBullet.GetComponent<Bullet>().SetIsPlayerOwned(true);
        newBullet.layer = LayerMask.NameToLayer("Enemy Hittable");
    }

    float AngleFromMouseToPlayer()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = transform.position;// Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        return angle;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void HandleHit()
    {
        print("player hit " + health);
        health -= 1;
        if (health <= 0)
        {
            gameLogic.GetComponent<GameLogic>().GameOver();
        }
        
    }
}
