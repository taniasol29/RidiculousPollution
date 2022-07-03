using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatCollisionIntro : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2.0f;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem bubblesParticle;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Finish")
        {
            StartSuccessSequence();
        }  
    }

    void StartSuccessSequence()
    {
        Debug.Log("Go next level");
        
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticle.Play();
        GetComponent<PathFollower>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
