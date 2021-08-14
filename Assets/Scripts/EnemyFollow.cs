using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    //ref the navmesh
    public NavMeshAgent Enemy;
    //ref the player
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //set the enemies destination towards the player
        Enemy.SetDestination(Player.position);
    }

}
