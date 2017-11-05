using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;

    private int score;

    public Text scoreText;

    public Text winnerText;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winnerText.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHoriz,0, moveVert);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            ++score;
            SetScoreText();
        }
        if (3 == score)
        {
            winnerText.gameObject.SetActive(true);
        }
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
