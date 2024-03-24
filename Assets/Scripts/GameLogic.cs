using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GameLogic : MonoBehaviour
{
    public static GameLogic SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public GameObject GameOverScreen;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        GameOverScreen.SetActive(false);

        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject Shoot(Vector2 from, Vector2 to)
    {
        GameObject newBullet = GetPooledObject();
        if (newBullet != null)
        {
            newBullet.SetActive(true);
            newBullet.GetComponent<Bullet>().SetDirection(from, to);
            return newBullet;
        }
        return null;
        
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
