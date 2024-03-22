using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 20;
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

        MoveDir = MoveDir.normalized;
        transform.position += MoveDir * moveSpeed * Time.deltaTime;
    }
}
