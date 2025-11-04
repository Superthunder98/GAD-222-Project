using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSpawn : MonoBehaviour
{

    // TESTING
    //[SerializeField] GameObject testBurgerPrefab;



    [SerializeField] float leftLimit = -5f;
    [SerializeField] float rightLimit = 5f;

    [SerializeField] float minSpawnInterval = 1f;
    [SerializeField] float maxSpawnInterval = 3f;
    [SerializeField] float startDelay = 10f;
    private float spawnTimer;

    public List<GameObject> productionQueue = new List<GameObject>();


    private void Awake()
    {
        StartCoroutine(MakeBurgur());
    }


    IEnumerator MakeBurgur()
    {
        while (true) // Link to game manager game state
        {

            if (productionQueue.Count == 0)
            {
                Debug.Log("No burgers in the production queue.");
                yield return new WaitForSeconds(startDelay);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
                int i = Random.Range(0, productionQueue.Count);
                SpawnBurger(productionQueue[i]);
                productionQueue.RemoveAt(i);
            }
        }
    }


     void SpawnBurger(GameObject burgerPrefab)
    {
        float randomX = Random.Range(leftLimit, rightLimit);
        Vector3 spawnPosition = new Vector3(randomX, this.transform.position.y, this.transform.position.z);
        Instantiate(burgerPrefab, spawnPosition, Quaternion.identity);
    }

    // TESTING
    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine(MakeBurgur());
    //    }
    //}


}
