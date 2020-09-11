using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Transform player;
    private float offset = 0f;
    public float extraPoints = 0f;

    void Awake()
    {
        offset = player.position.z;
    }

    void Update()
    {
        float temp = ((player.position.z - offset) / 5) + extraPoints;
        scoreText.text = temp.ToString("0");
        //extraPoints = 0;    
    }
}
