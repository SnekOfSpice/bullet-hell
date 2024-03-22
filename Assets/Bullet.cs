using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isPlayerOwned;
    public float speed = 10;
    public float direction;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = isPlayerOwned ? 1.2f : 0.9f;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Debug.Log(transform.rotation.eulerAngles);
    //    Debug.Log(transform.position);
    //    Vector3 a = new Vector3(1,0, 0);
    //    Vector2 b = new Vector2((float)Mathf.Cos(Mathf.Deg2Rad(direction), (float)Mathf.Sin(radians));
    //    //transform.position += a * speed * Time.deltaTime;
    //    transform.position += transform.forward * Time.deltaTime * speed;
    //}

    private void Update()
    {
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x, y);
    }
}
