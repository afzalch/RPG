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
        UpdateAnimator();
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

    private void UpdateAnimator(){
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
    }
}
