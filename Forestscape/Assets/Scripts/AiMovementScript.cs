using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//https://youtu.be/Zjlg9F3FRJs

public class AiMovementScript : MonoBehaviour
{
    private Animator animator;

    private Rigidbody rigidBodyComponent;
    public float movementSpeeed = 20f;
    public float rotationSpeed = 100f;

    private bool isWandering =false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private bool isEating = false;

    private NavMeshAgent agent;

    public GameObject middleOfarea;
    public float roamRadius;
    private float distanceRemain;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AiMovementScript start");
        rigidBodyComponent = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        System.Console.Write("isWalking false");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        distanceRemain = agent.remainingDistance;


        if (isWandering == false && animator.GetBool("IsRunning") == false){
            StartCoroutine(FreeRoam());
        }

        /*
        if(isRotatingRight && animator.GetBool("IsRunning") == false) 
        {
            //rigidBodyComponent.AddForce(Vector3.right * Time.deltaTime * rotationSpeed, ForceMode.Force);
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            //animator.SetBool("IsWalking", false);

        }
        if(isRotatingLeft && animator.GetBool("IsRunning") == false) 
        {
            //rigidBodyComponent.AddForce(Vector3.left * Time.deltaTime * -rotationSpeed, ForceMode.Force);
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            //animator.SetBool("IsWalking", false);
        }
        */
        
        if(isWalking && animator.GetBool("IsRunning") == false)
        {
        
            //rigidBodyComponent.AddForce(transform.forward * movementSpeeed); 
            animator.SetBool("IsWalking", true);
           
           // Debug.Log("isWalking true");

        }

        if(!isWalking) {
            animator.SetBool("IsWalking", false);
         
           // Debug.Log("isWalking false");
        }

        if(isEating){
            animator.SetBool("IsEating", true);
        } else {
            animator.SetBool("IsEating", false);
        }


    }

    void Wander2()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += middleOfarea.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        Vector3 finalPosition = hit.position;
        agent.destination = finalPosition;

    }

    IEnumerator FreeRoam()
    {
        int eatWait = Random.Range(1, 5);
        int walkWait = Random.Range(1, 20);

        isWandering = true;
        
        int eatOrNot = Random.Range(1, 3);
        if (eatOrNot == 1)
        {
            isEating = true;
        }
        yield return new WaitForSeconds(eatWait);
        isEating = false;
        yield return new WaitForSeconds(walkWait);

        
        isWalking = true;
        
        Wander2();
        yield return new WaitForSeconds(1);
        //float distanceRemain = agent.remainingDistance;
        Debug.Log(distanceRemain);
        yield return new WaitUntil(() => distanceRemain == 0);
        if (distanceRemain == 0)
        {
          isWalking = false;  
        }

        Debug.Log(distanceRemain + "ss");

        isWandering = false;

    }

    IEnumerator waitUntilEndWalk()
    {
        yield return new WaitUntil(() => distanceRemain == 0);
    }
     

    IEnumerator Wander(){
        int rotationTime = Random.Range(1, 3);
        int rotationWait = Random.Range(1, 3);
        int rotationDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1,20);
        int eatWait = Random.Range(1,5);
        int walkTime = Random.Range(3,10);

        isWandering = true;
        int eatOrNot = Random.Range(1, 3);
        if(eatOrNot == 1){
            isEating = true;
        }
        yield return new WaitForSeconds(eatWait);
        isEating =false;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        //Debug.Log("isWalking true");

        //animator.SetBool("IsWalking", true);
        yield return new WaitForSeconds(walkTime);
        if(rotationDirection == 1){
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        

        if(rotationDirection == 2){
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isWalking = false;
        Debug.Log("isWalking false");
        animator.SetBool("IsWalking", false);
        
        
        //yield return new WaitForSeconds(rotationWait);


        
        isWandering = false;

    }
}
