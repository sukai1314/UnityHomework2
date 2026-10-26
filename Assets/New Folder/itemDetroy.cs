using Unity.VisualScripting;
using UnityEngine;

public class itemDetroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject prefabDetroy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (prefabDetroy != null)
            {
                Destroy(prefabDetroy);
            }
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            SpawnManager spawn = FindAnyObjectByType<SpawnManager>();
            if (gameManager!=null)
            {
                gameManager.score++;
                spawn.spawnCount--;
                Destroy(gameObject);   
            }
     
        }
    }
}
