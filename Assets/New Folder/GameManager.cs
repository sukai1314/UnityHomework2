using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    public int score ;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI screenText;
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
        if (scoreText != null&&screenText!=null)
        {

            scoreText.text = ($"press 'Enter'to make Item \nPress 'Esc' Back StartScene \nScore:{score}");
            screenText.text = ($"Score:{score}");
        }
    }
}
