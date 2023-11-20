using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Speed in which the ball wil move can be change in Unity
    public float speed;
    public int health = 5;
    private Rigidbody rb;
    private int score = 0;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public Image WinLoseBG;
    public GameObject winOrLose;
    public bool isflat = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }
    void FixedUpdate()
    {
        #if UNITY_ANDROID
        {

        Vector3 tilt = Input.acceleration;

        if(isflat)
            // tilt = Quaternion.Euler(90,0,0) * tilt;
        rb.AddForce(tilt.x * speed,0,tilt.y * speed);
        }
        // #endif
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

        // # if UNITY_STANDALONE_WIN
        # else
        {

        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        // Get info from User to move in the X and Y axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (horizontalInput, 0.0f, verticalInput);
        
        rb.AddForce(movement * speed);
        }
        #endif
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
            // Debug.Log("Score: " + score.ToString());
        }
        if(other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
            other.gameObject.SetActive(true);
            // Debug.Log("Health: " + health.ToString());
        }
        if(other.gameObject.CompareTag("Goal"))
        {
            Setwintext();
            other.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            // Debug.Log("You win!");
        }
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        if(health == 0)
        {
            // Debug.Log("Game Over!");
            StartCoroutine(LoadScene(3));
            Setloosetext();
            // SceneManager.LoadScene(0);
        }
    }
    
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
    void Setwintext()
    {
        winOrLose.SetActive(true);
        WinLoseBG.color = Color.green;
        WinLoseText.color = Color.black;
        WinLoseText.text = "You Win!";

    }
    void Setloosetext()
    {
        winOrLose.SetActive(true);
        WinLoseBG.color = Color.red;
        WinLoseText.color = Color.white;
        WinLoseText.text = "Game Over!";

    }
}
