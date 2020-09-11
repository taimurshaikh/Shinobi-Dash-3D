using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float delay = 1f; 
    bool gameEnded = false;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (GameObject.FindWithTag("Player").transform.position.y < -1)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        if (!gameEnded)
        {   
            gameEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", delay);
        }
        
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
