using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isPlayerOwned;
    public float speed = 10;
    public Vector2 direction;

    public void SetIsPlayerOwned(bool value)
    {
        isPlayerOwned = value;
        GetComponent<CircleCollider2D>().radius = isPlayerOwned ? 0.12f : 0.09f;
    }

    public void SetDirection(Vector2 from, Vector2 to)
    {
        transform.position = new Vector3(from.x, from.y);
        direction = to - from;
    }

    private void Update()
    {
        
        transform.position += new Vector3(direction.x, direction.y).normalized * Time.deltaTime * speed;

        if (Mathf.Abs(transform.position.x) > 11 || Mathf.Abs(transform.position.y) > 7)
        {
            this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == this.gameObject.layer)
        {
            collision.gameObject.GetComponent<IDamagable>().HandleHit();
            this.gameObject.SetActive(false);
        }
        
    }
}
