using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const string V = "";
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;
    public Text portText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    private int port;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        port = 0;
        winText.text = "";
        loseText.text = "";
        SetCountText();
        SetLivesText();
        SetPortText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
        if (count == 12)
        {
            transform.position = new Vector2(-100f, 0f);
        }
        if (other.gameObject.CompareTag("TeleportPortal"))
        {
            other.gameObject.SetActive(false);
            port = port + 1;
            SetPortText();
        }
        if (port == 1)
        {
            transform.position = new Vector2(-111f, -10f);
        }
        if (port == 3)
        {
            transform.position = new Vector2(-103f, 10.5f);
        }       
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You Win! Game created by David Kingsley!";
            transform.position = new Vector2(-100f, 100f);
        }
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            Destroy(this);
            loseText.text = "You Lose!!";
            transform.position = new Vector2(50f, 0f);
        }
    }

    void SetPortText()
    {
        portText.text = "Port: " + port.ToString();
    }

void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
}