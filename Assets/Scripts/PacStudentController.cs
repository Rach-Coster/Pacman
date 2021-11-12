using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PacStudentController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem pacmanParticleEffect;

    private ParticleSystem pacmanParticles; 

    private GameObject GameManager;
    private GameObject pacman;

    public AudioClip[] audioClips;

    private AudioSource audioSource;
    private TileGenerator tileGenerator;


    private string lastInput;
    private string currentInput;

    private bool pacmanMoving;
 

    // Start is called before the first frame update
    void Start()
    {
        //Getting tile lists for specific checks 
        GameManager = GameObject.Find("GameManager");
        tileGenerator = GameManager.GetComponent<TileGenerator>();


        pacman = GameObject.Find("PacmanMouthOpen(Clone)");


        audioSource = pacman.GetComponent<AudioSource>();

        //Particle effects for pacman while moving
        pacmanParticles = Instantiate(pacmanParticleEffect, new Vector2(pacman.transform.position.x, pacman.transform.position.y - 1), Quaternion.identity);
        pacmanParticles.Pause(); 


        lastInput = " ";
        currentInput = " ";
        pacmanMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Checking if pacman is moving
        if (!pacmanMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                lastInput = KeyCode.W.ToString();
                currentInput = KeyCode.W.ToString();
                pacman.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                pacman.transform.localScale = new Vector3(1, 1, 1);
                pacmanMoving = true;

            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                lastInput = KeyCode.S.ToString();
                currentInput = KeyCode.S.ToString();
                pacman.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                pacman.transform.localScale = new Vector3(1, 1, 1);
                pacmanMoving = true;
            }


            else if (Input.GetKeyDown(KeyCode.A))
            {
                lastInput = KeyCode.A.ToString();
                currentInput = KeyCode.A.ToString();
                pacman.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                pacman.transform.localScale = new Vector3(1, -1, 1); 
                pacmanMoving = true;
            }


            else if (Input.GetKeyDown(KeyCode.D))
            {
                lastInput = KeyCode.D.ToString();
                currentInput = KeyCode.D.ToString();
                pacman.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                pacman.transform.localScale = new Vector3(1, 1, 1);
                pacmanMoving = true;
            }

            pacmanParticles.Pause();
            pacmanParticles.Clear(); 
            pacman.GetComponent<Animator>().StartPlayback();
        }

        //Checking when pacman is moving
        if (pacmanMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                lastInput = KeyCode.W.ToString();
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                lastInput = KeyCode.S.ToString();

            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                lastInput = KeyCode.A.ToString();
            }


            else if (Input.GetKeyDown(KeyCode.D))
            {
                lastInput = KeyCode.D.ToString();
            }

            
            //Stopping the pacman animator so it is on the half-open sprite
            pacman.GetComponent<Animator>().StopPlayback(); 
        }

        //Checking if pacman has hit a wall
        if (lastInput == "W" && tileGenerator.cellList.Contains(pacman.transform.position) && !tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, pacman.transform.position.y + 3)))
        {
            currentInput = lastInput;
            pacman.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            pacman.transform.localScale = new Vector3(1, 1, 1);
            StopAllCoroutines();
        }

        if (lastInput == "S" && tileGenerator.cellList.Contains(pacman.transform.position) && !tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, pacman.transform.position.y - 3)))
        {
            currentInput = lastInput;
            pacman.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
            pacman.transform.localScale = new Vector3(1, 1, 1);
            StopAllCoroutines();
        }

        if (lastInput == "A" && tileGenerator.cellList.Contains(pacman.transform.position) && !tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x - 3, pacman.transform.position.y)))
        {
            currentInput = lastInput;
            pacman.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            pacman.transform.localScale = new Vector3(1, -1, 1);

            StopAllCoroutines();
        }

        if (lastInput == "D" && tileGenerator.cellList.Contains(pacman.transform.position) && !tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x + 3, pacman.transform.position.y)))
        {
            currentInput = lastInput;
            pacman.transform.rotation = Quaternion.Euler(new Vector3 (0, 0, 0));
            pacman.transform.localScale = new Vector3(1, 1, 1);
            StopAllCoroutines();
        }

        
        //Coroutines that correpsond with movement
        if (currentInput == "W")
        {
            pacmanParticles.Play();
            pacmanParticles.transform.position = new Vector2(pacman.transform.position.x, pacman.transform.position.y - 2);

            StartCoroutine(LerpUp());
        }

        else if (currentInput == "S")
        {
            pacmanParticles.Play();
            pacmanParticles.transform.position = new Vector2(pacman.transform.position.x, pacman.transform.position.y + 2);

            StartCoroutine(LerpDown());
        }

        else if (currentInput == "A")
        {
            pacmanParticles.Play();
            pacmanParticles.transform.position = new Vector2(pacman.transform.position.x, pacman.transform.position.y - 1);

            StartCoroutine(LerpLeft());
        }

        else if (currentInput == "D")
        {
            pacmanParticles.Play();
            pacmanParticles.transform.position = new Vector2(pacman.transform.position.x, pacman.transform.position.y - 1);

            StartCoroutine(LerpRight());
        }


        if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, pacman.transform.position.y + 3)))
        {
            StopAllCoroutines();
            pacmanMoving = false;
        }

        else if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, pacman.transform.position.y - 3)))
        {
            StopAllCoroutines();
            pacmanMoving = false;
        }

        else if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x - 3, pacman.transform.position.y)))
        {
            StopAllCoroutines();
            pacmanMoving = false;
        }

        else if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x + 3, pacman.transform.position.y)))
        {
            StopAllCoroutines();
            pacmanMoving = false;
        }

        if (tileGenerator.dotList.Contains(new Vector2(Mathf.Round(pacman.transform.position.x), Mathf.Round(pacman.transform.position.y))) && !audioSource.isPlaying && pacmanMoving)
        {

            audioSource.clip = audioClips[0];
            audioSource.enabled = true;
            audioSource.Play();

        }

        else if (tileGenerator.pelletList.Contains(new Vector2(Mathf.Round(pacman.transform.position.x), Mathf.Round(pacman.transform.position.y))) && !audioSource.isPlaying && pacmanMoving)
        {
            audioSource.clip = audioClips[1];
            audioSource.enabled = true;
            audioSource.Play();

        }

        else if (tileGenerator.cellListEstimate.Contains(new Vector2(Mathf.Round(pacman.transform.position.x), Mathf.Round(pacman.transform.position.y))) && !audioSource.isPlaying && pacmanMoving)
        {
            audioSource.clip = audioClips[2];
            audioSource.enabled = true;
            audioSource.Play();
        }

    }

    IEnumerator LerpUp()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;

        float currentYPosition = pacman.transform.position.y;


        while (timeElapsed < lerpDuration)
        {
            if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, currentYPosition + 3)))
            {
                break;
            }

            else
            {
                timeElapsed += Time.deltaTime;

                pacman.transform.position = Vector2.Lerp(new Vector2(pacman.transform.position.x, currentYPosition), new Vector2(pacman.transform.position.x, currentYPosition + 3), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }
    IEnumerator LerpDown()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;

        float currentYPosition = pacman.transform.position.y;


        while (timeElapsed < lerpDuration)
        {
            if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, currentYPosition - 3)))
            {
                break;
            }

            else
            {
                timeElapsed += Time.deltaTime;

                pacman.transform.position = Vector2.Lerp(new Vector2(pacman.transform.position.x, currentYPosition), new Vector2(pacman.transform.position.x, currentYPosition - 3), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }
    IEnumerator LerpLeft()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;

        float currentXPosition = pacman.transform.position.x;

        while (timeElapsed < lerpDuration)
        {
            if (tileGenerator.edgeList.Contains(new Vector2(currentXPosition - 3, pacman.transform.position.y)))
            {
                break;
            }

            else
            {
                timeElapsed += Time.deltaTime;

                pacman.transform.position = Vector2.Lerp(new Vector2(currentXPosition, pacman.transform.position.y), new Vector2(currentXPosition - 3, pacman.transform.position.y), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }
    IEnumerator LerpRight()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;

        float currentXPosition = pacman.transform.position.x;

        while (timeElapsed < lerpDuration)
        {
            if (tileGenerator.edgeList.Contains(new Vector2(currentXPosition + 3, pacman.transform.position.y)))
            {
                break;
            }
            else
            {
                timeElapsed += Time.deltaTime;

                pacman.transform.position = Vector2.Lerp(new Vector2(currentXPosition, pacman.transform.position.y), new Vector2(currentXPosition + 3, pacman.transform.position.y), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }

}


