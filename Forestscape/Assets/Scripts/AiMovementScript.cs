using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        System.Console.Write("isWalking false");
    }

    // Update is called once per frame
    void Update()
    {
        if(isWandering == false){
            StartCoroutine(Wander());
        }

        if(isRotatingRight) 
        {
            //rigidBodyComponent.AddForce(Vector3.right * Time.deltaTime * rotationSpeed, ForceMode.Force);
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            animator.SetBool("IsWalking", false);

        }
        if(isRotatingLeft) 
        {
            //rigidBodyComponent.AddForce(Vector3.left * Time.deltaTime * -rotationSpeed, ForceMode.Force);
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            animator.SetBool("IsWalking", false);
        }

        

        if(isWalking)
        {
        
            rigidBodyComponent.AddForce(transform.forward * movementSpeeed); 
            animator.SetBool("IsWalking", true);
            System.Console.Write("isWalking true");

        }

        if(!isWalking) {
            animator.SetBool("IsWalking", false);
            System.Console.Write("isWalking false");
        }
    }

    IEnumerator Wander(){
        int rotationTime = Random.Range(1, 3);
        int rotationWait = Random.Range(1, 3);
        int rotationDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1,3);
        int walkTime = Random.Range(1,5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        
        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        yield return new WaitForSeconds(rotationWait);


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

        isWandering = false;

    }
}
