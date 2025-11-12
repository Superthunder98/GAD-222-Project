using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSpawn : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    // TESTING
    //[SerializeField] GameObject testBurgerPrefab;


    [SerializeField] float leftLimit = -5f;
    [SerializeField] float rightLimit = 5f;

    [SerializeField] float minSpawnInterval = 1f;
    [SerializeField] float maxSpawnInterval = 3f;
    [SerializeField] float startDelay = 10f;
    private float spawnTimer;

    public List<GameObject> productionQueue = new List<GameObject>();

    [SerializeField] float randomizerMinTime = 5f;
    [SerializeField] float randomizerMaxTime = 15f;

    private void Awake()
    {
        StartCoroutine(MakeBurgur());
        StartCoroutine(randomizer());
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
                if (productionQueue.Count < 4)
                {
                    SpawnBurger(productionQueue[0]);
                    productionQueue.RemoveAt(0);
                }
                else
                { 
                    int i = Random.Range(0, productionQueue.Count / 4);
                    SpawnBurger(productionQueue[i]);
                    productionQueue.RemoveAt(i);
                }

                yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            }
        }
    }

    IEnumerator randomizer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(randomizerMinTime, randomizerMaxTime));
            productionQueue.Add(gameManager.productList[Random.Range(0, gameManager.productList.Count)]);
        }
    }

     void SpawnBurger(GameObject burgerPrefab)
    {
        float randomX = Random.Range(leftLimit, rightLimit);
        float randomY = Random.Range(2.4f, 4f);
        Vector3 spawnPosition = new Vector3(randomX, randomY, this.transform.position.z);
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
