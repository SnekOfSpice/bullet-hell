using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isPlayerOwned;
    public float speed = 10;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = isPlayerOwned ? 1.2f : 0.9f;

        Vector2 objPos = transform.position;//gets player position
        Vector2 mousePos = Input.mousePosition;//gets mouse postion
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        direction = mousePos - objPos;
    }

    private void Update()
    {
        transform.position += new Vector3(direction.x, direction.y).normalized * Time.deltaTime * speed;

        if (Mathf.Abs(transform.position.x) > 11 || Mathf.Abs(transform.position.y) > 7)
        {
            Destroy(this.gameObject);
        }

    }
}
