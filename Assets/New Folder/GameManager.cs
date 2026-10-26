using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    public int score ;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(score);
        }
        if (scoreText != null)
        {

            scoreText.text = ($"press 'Enter'to make Item \n'C' change Scene \nScare:{score}");
        }
    }
}
