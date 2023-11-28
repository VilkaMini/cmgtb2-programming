using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeLogic : MonoBehaviour
{
    [SerializeField] private float speedOfGame;

    [SerializeField] private GameObject coinPowerUp;
    // Update is called once per frame

    private void Start()
    {
        float rndInt = Random.Range(0f, 5f);
        if (rndInt > 4)
        {
            coinPowerUp.SetActive(true);
        }
    }

    void Update()
    {
        transform.position += new Vector3(-speedOfGame, 0, 0);
    }
}
