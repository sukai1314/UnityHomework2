using UnityEngine;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour
{
    private GameObject act;
    private GameObject camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    act = GameObject.Find("acter");
    camera = GameObject.Find("Main Camera");    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            LoadNewScene();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
  
            if (act != null && camera != null)
            {
                Destroy(act);
                Destroy(camera);
            }
            else { Debug.Log("none"); }
          StartScene();
        }
    }
    public void LoadNewScene()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("startScene");
    }
}
