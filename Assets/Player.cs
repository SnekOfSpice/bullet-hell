using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 20;
    public GameObject gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        transform.position += MoveDir * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, AngleFromMouseToPlayer() + 90));

    }

    void Shoot()
    {
        GameObject newBullet = gameLogic.GetComponent<GameLogic>().Shoot(this.transform);
        newBullet.GetComponent<Bullet>().isPlayerOwned = true;
        newBullet.GetComponent<Bullet>().direction = AngleFromMouseToPlayer() + 90;
    }

    float AngleFromMouseToPlayer()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        return angle;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
