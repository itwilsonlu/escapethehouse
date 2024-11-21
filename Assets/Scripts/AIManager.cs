using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != Vector3.zero) {
            agent.destination = player.transform.position;
        }
    }
}
