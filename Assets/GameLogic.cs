using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject bullet;
    public GameObject GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Shoot(Vector2 from, Vector2 to)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.GetComponent<Bullet>().SetDirection(from, to);
        return newBullet;
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
