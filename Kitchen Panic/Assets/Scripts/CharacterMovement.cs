using UnityEngine;
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using System;
// Verarbeitet die Charaktersteuerung
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    private NavMeshAgent agent;
    private Vector3 agentTarget;
    private float speed;

    // Kitchentools will be saved in a List
    // All Kitchentools have to be tagged with "Kitchentool"
    [SerializeField]
=======
// Verarbeitet die Charaktersteuerung
public class CharacterMovement : MonoBehaviour
{
    private GameObject Player;

    // Kitchentools will be saved in a List
    // All Kitchentools have to be tagged with "Kitchentool"
>>>>>>> refs/remotes/origin/master
    private List<GameObject> LKitchentools;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
            Debug.Log("Find Player");

<<<<<<< HEAD
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
            Debug.Log("Agentname: " + agent.name);

        LKitchentools = new List<GameObject>();
        agentTarget = Vector3.zero;
=======
        LKitchentools = new List<GameObject>();
>>>>>>> refs/remotes/origin/master
    }

    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
        AddKtichentoolsToTheList();
=======

>>>>>>> refs/remotes/origin/master
    }

    // Update is called once per frame
    void Update()
    {

    }
<<<<<<< HEAD

    public void Move(Vector3 targetPosition)
    {
        agentTarget = targetPosition;

        if(agent.transform.position != agentTarget)
            Debug.Log("Target moved to: " + agentTarget); 

        agent.SetDestination(agentTarget);
        transform.LookAt(agentTarget);
        Debug.DrawRay(transform.position, agentTarget - transform.position, Color.red );
    }

    private void AddKtichentoolsToTheList()
    {
        foreach (GameObject c in GameObject.FindGameObjectsWithTag("Kitchentool"))
        {
            LKitchentools.Add(c);
        }
        Debug.Log("Anzahl der Kitchentools in der Liste:" + LKitchentools.Count);
    }
=======
>>>>>>> refs/remotes/origin/master
}
