using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Birb : MonoBehaviour
{
    // Define variables
    [SerializeField] private int jumpForce;
    [SerializeField] private TextMeshProUGUI scoreText;

    private List<Coroutine> coroutines = new List<Coroutine>();
    private int score = 0;
    private Rigidbody rb;
    private bool coinIsPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        print("Death");
        SceneManager.LoadScene("FlappyBirb");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //Power Up picked
            if (coroutines.Count > 1)
            {
                coroutines.RemoveAt(0);
            }
            coroutines.Add(StartCoroutine(PowerUpDuration()));
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("PillarScore"))
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            Vector3 forceVector = new Vector3(0, jumpForce, 0);
            rb.AddForce(forceVector, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpDuration()
    {
        
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(2);
        transform.localScale = Vector3.one;
    }
}
