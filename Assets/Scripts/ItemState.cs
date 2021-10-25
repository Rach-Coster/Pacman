using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemState : MonoBehaviour
{
    private List<GameObject> pellet;

    [SerializeField]
    GameObject cherry;

    [SerializeField]
    GameObject remainingLives;

    private GameObject gameBoard;
    private GameObject mapBottomLeft;
    private GameObject mapTopLeft;

    private GameObject pelletAudioSource; 

    public AudioClip[] audioClip;
    AudioSource audioSource;

    const int lives = 3; 
    Vector2 pacmanPos;
    // Start is called before the first frame update
    void Start()
    {
        pellet = new List<GameObject>();
        pelletAudioSource = new GameObject();
        audioSource = pelletAudioSource.AddComponent<AudioSource>();
        pelletAudioSource.name = "PelletAudioSource";
        audioSource.clip = audioClip[0]; 

        pacmanPos = new Vector2();

        CreateItems();  
    }

    // Update is called once per frame
    void Update()
    {
        pellet = gameObject.GetComponent<LevelGenerator>().GetPellets();
        gameBoard = gameObject.GetComponent<LevelGenerator>().GetGameboard();
     
        pacmanPos = gameObject.GetComponent<PacmanMovement>().GetPacmanPosition();

        if (pacmanPos.x == -10.4f && pacmanPos.y == 1.7f)
        {
            mapBottomLeft = gameBoard.transform.Find("MapBottomLeft").gameObject;
            GameObject dot = mapBottomLeft.transform.Find("Dot 14 6(Clone)").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }

        if (pacmanPos.x == -10.4f && Math.Round(pacmanPos.y) == 3)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 14 6").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (pacmanPos.x == -10.4f && Math.Round(pacmanPos.y) == 6)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 13 6").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (pacmanPos.x == -10.4f && Math.Round(pacmanPos.y) == 8)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 12 6").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (pacmanPos.x == -10.4f && Math.Round(pacmanPos.y) == 11)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 11 6").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (pacmanPos.x == -10.4f && Math.Round(pacmanPos.y) == 14)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 10 6").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (pacmanPos.x == -10.4f && Math.Round(pacmanPos.y) == 16)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 9 6").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (pacmanPos.x == -10.4f && pacmanPos.y == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 6").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f); 
        }
        if (Math.Round(pacmanPos.x) == -13 && pacmanPos.y == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 5").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -14 && pacmanPos.y == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 4").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -15 && pacmanPos.y == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 3").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -16 && pacmanPos.y == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 2").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -17 && pacmanPos.y == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 2").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -17 && pacmanPos.y == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 1").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -17 && Math.Round(pacmanPos.y) == 20)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 7 1").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -17f && Math.Round(pacmanPos.y) == 23)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 6 1").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -17f && Math.Round(pacmanPos.y) == 26)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 5 1").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -17f && Math.Round(pacmanPos.y) == 28)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 4 1").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -17f && Math.Round(pacmanPos.y) == 30)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject pellet = mapTopLeft.transform.Find("Pellet(Clone)").gameObject;
            pellet.SetActive(false);
            audioSource.clip = audioClip[1];
            audioSource.PlayDelayed(0.03f);
        }

        if (Math.Round(pacmanPos.x) == -17f && Math.Round(pacmanPos.y) == 33)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 2 1").gameObject;
            dot.SetActive(false);
            audioSource.clip = audioClip[0];
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -17 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -17 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 1").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -16 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 2").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 3").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -13 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 4").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -12 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 5").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -11 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 6").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -9 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 7").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -8 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 8").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -6 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 9").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -5 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 10").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -4 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 11").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -2 && Math.Round(pacmanPos.y) == 35 || Math.Round(pacmanPos.x) == -15 && Math.Round(pacmanPos.y) == 36)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 1 12").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        } 
        if (Math.Round(pacmanPos.x) == -2 && Math.Round(pacmanPos.y) == 32)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 2 12").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -2 && Math.Round(pacmanPos.y) == 30)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 3 12").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -2 && Math.Round(pacmanPos.y) == 28)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 4 12").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -2 && Math.Round(pacmanPos.y) == 26)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 5 12").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -3 && Math.Round(pacmanPos.y) == 26)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 5 11").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -4 && Math.Round(pacmanPos.y) == 26)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 5 10").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -6 && Math.Round(pacmanPos.y) == 26)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 5 9").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -7 && Math.Round(pacmanPos.y) == 23)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 6 9").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -7 && Math.Round(pacmanPos.y) == 21)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 7 9").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -6 && Math.Round(pacmanPos.y) == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 9").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -6 && Math.Round(pacmanPos.y) == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 10").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -4 && Math.Round(pacmanPos.y) == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 11").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
        if (Math.Round(pacmanPos.x) == -3 && Math.Round(pacmanPos.y) == 18)
        {
            mapTopLeft = gameBoard.transform.Find("MapTopLeft").gameObject;
            GameObject dot = mapTopLeft.transform.Find("Dot 8 12").gameObject;
            dot.SetActive(false);
            audioSource.PlayDelayed(0.03f);
        }
    }

    void CreateItems()
    {
        float xPos = -15.8f; 
        Instantiate(cherry);
        cherry.transform.position = new Vector2(-17.8f, -35.5f);

        for (var i = 0; i < lives; i++)
        {
            Instantiate(remainingLives);
            remainingLives.transform.position = new Vector2(xPos += 2, -35.5f);
        }
    }

}
