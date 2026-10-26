using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Transform target;
    public Transform spawnPoint;
    public int spawnCount = 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    target = GameObject.Find("target").transform;   
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
        StartCoroutine(MakeItem());
        }

    }
    IEnumerator MakeItem()
    {
        float range=Random.Range(-5.0f,5.0f);
        float zrange = Random.Range(-5.0f, 5.0f);
        Vector3 spnPos =new Vector3(target.position.x + range,0.5f,target.position.z+zrange);

        GameObject spownPrefab = Resources.Load<GameObject>("Buff Variant");
        GameObject item1 = Resources.Load<GameObject>("item1");

            //特效盒
            GameObject prefabDetroy = null;
        if (target != null && spawnCount < 5)
        {

            spawnCount++;
            if (spownPrefab != null)
            {
                Quaternion rot = (spawnPoint != null) ? spawnPoint.rotation : Quaternion.identity;
                prefabDetroy = Instantiate(spownPrefab, spnPos, rot);
            }
            else { Debug.Log("nofind"); }




            yield return new WaitForSeconds(1f);
            if (item1 != null)
            {
                Quaternion rot = (spawnPoint != null) ? spawnPoint.rotation : Quaternion.identity;
                GameObject itemObj = Instantiate(item1, spnPos, rot);
                //將特效塞入另一個腳本的物件，讓他可以一起摧毀
                itemDetroy detrotScript = itemObj.GetComponent<itemDetroy>();
                if (detrotScript != null)
                {
                    detrotScript.prefabDetroy = prefabDetroy;
                }
            }
        }

        yield break;

    }
}
