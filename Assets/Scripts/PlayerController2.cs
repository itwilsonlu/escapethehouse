using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
     public TMP_Text objectiveText;


    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = "Objective: Solve the puzzles";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        // if ()) {
        //     Destroy(other.gameObject);
        // }
        if (other.CompareTag("WallTrigger")) 
        {
            objectiveText.text = "Objective: Solve the puzzle";
        }
        if (GameData.points == 3 && other.CompareTag("NPC")) {
            objectiveText.text = "";
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
        }
    }
}
