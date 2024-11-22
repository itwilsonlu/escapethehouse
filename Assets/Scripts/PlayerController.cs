using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // AudioSource src;
    // public AudioClip sound;

    void Start () 
    {
        // src = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collectible")) 
        {
            GameData.points++;
            // src.PlayOneShot(sound);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("AI")) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }
    }
}
