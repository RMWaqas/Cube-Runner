using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameCode : MonoBehaviour
{
    new Rigidbody rigidbody;

    // Fields
    public float force = 1000f;
    public float speed = 10f;

    public float maxX;
    public float minX;

    // Cached Refrences
    public ParticleSystem collectingEffect;
    PlayerScore playerScore;
    public GameObject GameOverPanel;
    public GameObject tapToStartText;
    public GameObject score;
    public GameCode gameCode;
    
    // Sound Effects
    public AudioSource collectingSoundEffect;
    public AudioSource gameOverSoundEffect;

    // Start & Update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerScore = FindObjectOfType<PlayerScore>();
        PauseGame();
    }
    void Update()
    {
        PlayerMovement();
        StructPlayerInRoad();
        ResumeGame();
    }

    // Player Movement z-axis
    private void FixedUpdate()
    {
        rigidbody.AddForce(0, 0, force * Time.deltaTime);
    }

    // Player Movement x-axis
    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
    private void StructPlayerInRoad()
    {
        Vector3 playerPosition = transform.position;
        if (playerPosition.x > maxX)
        {
            playerPosition.x = maxX;
        }
        transform.position = playerPosition;

        if (playerPosition.x < minX)
        {
            playerPosition.x = minX;
        }
        transform.position = playerPosition;
    }

    // Collision & Trigger Events
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            collectingEffect.Play();
            Destroy(other.gameObject);
            collectingSoundEffect.Play();
            playerScore.UpdateScore();
        }            
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            gameCode.enabled = false;
            gameOverSoundEffect.Play();
            GameOverPanel.SetActive(true);
            score.SetActive(false);
        }
    }

    // Game Pause & Resume
    void PauseGame()
    {
        Time.timeScale = 0f;
        score.SetActive(false);
    }

    void ResumeGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            tapToStartText.SetActive(false);
            score.SetActive(true);
        }
    }
}