using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // AudioSource src;
    // public AudioClip sound;
    public TMP_Text objectiveText;

    void Start () 
    {
        // src = GetComponent<AudioSource>();
        objectiveText.text = "Objective: Give the mannequin the three items";
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collectible")) 
        {
            GameData.points++;
            // src.PlayOneShot(sound);
            Destroy(other.gameObject);
        }
        if (GameData.points == 3 && other.CompareTag("NPC")) {
            objectiveText.text = "";
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        }
        if (other.CompareTag("AI")) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }
    }
}