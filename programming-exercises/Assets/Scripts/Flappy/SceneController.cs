using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private float speedOfGame;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField] private GameObject parentGameObject;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject groundPrefab;

    private bool gameEnded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningWorld());
    }

    private IEnumerator SpawningWorld()
    {
        while (!gameEnded)
        {
            yield return new WaitForSeconds(1);
            float random = Random.Range(-1, 3);
            Instantiate(obstaclePrefab, new Vector3(spawnPoint.position.x, random, spawnPoint.position.y), UnityEngine.Quaternion.identity, parentGameObject.transform);
        }
    }
}
