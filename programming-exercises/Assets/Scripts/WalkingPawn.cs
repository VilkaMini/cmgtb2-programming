using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class WalkingPawn : MonoBehaviour
{
    [SerializeField] private int coinScore = 0;
    
    [SerializeField] private float speedAmount;
    private Rigidbody character;
    
    void Start()
    {
        character = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinScore++;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.MovePosition(character.position + movement * speedAmount * Time.deltaTime);
    }
}
