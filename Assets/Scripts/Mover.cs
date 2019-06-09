using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           MoveToCursor();
        }
    }


    private void MoveToCursor(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // hit stores location of mouseClick
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit) {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = hit.point;
        }
    }
}
