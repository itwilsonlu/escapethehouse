using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLevel3 : MonoBehaviour
{
    public Camera cam; 
    public UnityEngine.AI.NavMeshAgent monster;
    // Start is called before the first frame update
    void Start()
    {
       GameData.points = 0;
        Cursor.visible = true;
        monster = GameObject.FindGameObjectWithTag("AI").GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);   
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            if (objectHit.name == "Skeleton") {
                monster.speed = 0;
            } else {
                monster.speed = 3.5f;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collectible")) {
            Destroy(other.gameObject);
            GameData.points++;
            if (GameData.points == 3) {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
            }
        }
        if (other.CompareTag("AI")) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }
    }
}
