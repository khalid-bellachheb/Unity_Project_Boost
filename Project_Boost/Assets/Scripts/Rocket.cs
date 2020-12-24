using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[DisallowMultipleComponent]

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust=100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float LoadLevelDelay = 2f;

    [SerializeField] AudioClip MainEngine;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip NextLevelSound;

    [SerializeField] ParticleSystem MainEngineParticale;
    [SerializeField] ParticleSystem deathParticale;
    [SerializeField] ParticleSystem NextLevelParticle;

    Rigidbody rigidbody;
    AudioSource audioSource;

    [SerializeField] bool CollisionsDisabled = true;

    // create a new variable type : State
    enum State { Alive,Dying,Transcending} 
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state==State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
        if(Debug.isDebugBuild)
        {
            RespondToDebugKeys(); // to do only if debug is on
        }
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            // toggle collision
            CollisionsDisabled = !CollisionsDisabled;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //ignore collision when dead
        if (state != State.Alive || !CollisionsDisabled) { return; } 

        print("collided");
        //collision.gameObject : is thr thing we are colliding with.
        switch (collision.gameObject.tag) 
        {
            case "Friendly":
                //do nothing
                break;
            case "Finish":
                // delaying level load
                // call the string name function after 1 second 
                StartTranscendingSquence();
                break;
            default:
                StartDyingSquence();
                // kill the player
                break;
        }
    }

    private void StartDyingSquence()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound);
        deathParticale.Play();
        Invoke("LoadFirstlevel", LoadLevelDelay);
    }

    private void StartTranscendingSquence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(NextLevelSound);
        NextLevelParticle.Play();
        Invoke("LoadNextLevel", LoadLevelDelay); 
    }

    private  void LoadFirstlevel()
    {
        SceneManager.LoadScene(0);
    }

    private  void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene+1;
        if(nextScene==SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }

    private void RespondToThrustInput()
    {
        /*
        if (UnityEngine.Input.GetMouseButton(0))
        {
            ApplyThrust();
            MainEngineParticale.Play();

        }
        else
        {
            audioSource.Stop();
            MainEngineParticale.Stop();
        }
        */
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ApplyThrust();
            MainEngineParticale.Play();
            print("UpArriw is pressed");

        }
        else
        {
            audioSource.Stop();
            MainEngineParticale.Stop();
        }
    }

    private void ApplyThrust()
    {
        print("Pressed Light click");
        rigidbody.AddRelativeForce(Vector3.up * mainThrust*Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(MainEngine);
        }
        
    }

    private void RespondToRotateInput()
    {
        // take manual control of rotation
        rigidbody.freezeRotation = true;  
        float rotateThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q))
        {
            print("Pressed Right click");
            transform.Rotate(-Vector3.forward *rotateThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward *rotateThisFrame);
        }
        // resume physics control of rotation
        rigidbody.freezeRotation = false; 
    }
}
