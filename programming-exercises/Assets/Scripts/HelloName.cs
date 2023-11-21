using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HelloName : MonoBehaviour
{
    [SerializeField]
    private string namePerson;
    private List<int> listOfNumbers = new List<int>();

    [SerializeField]
    private float speedAmount;
    private Rigidbody character;

    void Start()
    {
        character = GetComponent<Rigidbody>();
        // Say hello
        Debug.Log($"Hello {namePerson}");

        //PrintListOfNumbers();

        
    }

    private void PrintListOfNumbers()
    {
        // List of 100
        for (int i = 0; i <= 100; i++)
        {
            listOfNumbers.Add(i);
        }
        for (int i = 0; i < listOfNumbers.Count; i++)
        {
            Debug.Log($"Number: {listOfNumbers[i]}");
        }
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        character.MovePosition(character.position + movement * Time.deltaTime * speedAmount);
    }
}
