using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//inspiré de https://youtu.be/Zjlg9F3FRJs

public class AiMovementScript : MonoBehaviour
{
    private Animator animator;

    private Rigidbody rigidBodyComponent;
    public float movementSpeeed = 1f;
    public float rotationSpeed = 100f;

    private bool isWandering =false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private bool isEating = false;

    private NavMeshAgent agent;

    public GameObject middleOfarea;
    private Vector3 position;
    public float roamRadius;
    private float distanceRemain;
    
    void Start()
    {
        
        rigidBodyComponent = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0.5f;

        position = transform.position;
       
    }

    
    void Update()
    {
        //retourne la distance qu'il reste à l'animal à parcourir
        distanceRemain = agent.remainingDistance;

        if(distanceRemain == 0){
            isWalking = false;
        }
        //si l'animal n'est pas en train de courir, commencer le processus de Freeroam (marcher + idle + manger) si pas déja activé
        if (isWandering == false && animator.GetBool("IsRunning") == false){
            StartCoroutine(FreeRoam());
        }

        //Ancien code utilisé avec la première version de "Wander"
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
        
        //commence à faire l'animation de "walk" s'il est en train de marcher et n'est pas en train de courir
        if(isWalking && animator.GetBool("IsRunning") == false)
        {
            animator.SetBool("IsWalking", true);
           
        }

        //ne fait pas l'animation "walk" s'il ne marche pas
        if(!isWalking) {
            animator.SetBool("IsWalking", false);
        
        }

        //fait l'animation "eat" s'il est en train de manger
        if(isEating){
            animator.SetBool("IsEating", true);
        } else {
            animator.SetBool("IsEating", false);
        }

        if (isWalking || animator.GetBool("IsRunning")){
            CheckIfStuck();
        }
        

    }

    ///Deuxième version de "wander" avec l'utilisation de NavMesh
    /// Déplace l'animal dans un milieu restrain
    void Wander2()
    {
        
        //hit une position à l'interieur d'un rayon défini (avec l'objet middleOfarea comme centre du cercle) et crée un path vers la position qui a été hit
        agent.speed = movementSpeeed;
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += middleOfarea.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        Vector3 finalPosition = hit.position;
        agent.destination = finalPosition;
        

    }


    ///Fait bouger l'animal d'une façon naturelle et alèatoire
    IEnumerator FreeRoam()
    {
        //déclaration du nombres de secondes que peut prendre l'animal pour faire une action
        int eatOrIdleWait = Random.Range(1, 5);
        int walkWait = Random.Range(1, 20);
        int walkTime = Random.Range(10, 20);

        //début du wandering
        isWandering = true;
        
        //décide si l'animal fait l'animation de "eat" ou non (une chance sur deux)
        int eatOrNot = Random.Range(1, 3);
        if (eatOrNot == 1)
        {
            //fait l'animation de "eat"
            isEating = true;
        }
        //attend un nombres de seconde aléatoire "eatOrIdleWait" pour l'execution de l'action ou l'animal ne se déplace pas (manger ou idle)
        yield return new WaitForSeconds(eatOrIdleWait);
        isEating = false;
        yield return new WaitForSeconds(walkWait);
        
        agent.isStopped = false;
        //animal commence à marcher
        isWalking = true;
        
        //donne un chemin à suivre à l'animal
        Wander2();
        yield return new WaitForSeconds(walkTime);
        isWalking = false; 
        agent.isStopped = true;

        /*
        yield return new WaitForSeconds(1);
        //isWalking tant que l'animal n'a pas fini son chemin (path) vers son point d'arrivé
        yield return new WaitUntil(() => distanceRemain <= 5);
        if (distanceRemain <= 5)
        {
          isWalking = false;  
          agent.destination = rigidBodyComponent.transform.position;
        }
        */

        //arrete de marcher quand il a fini son chemin aléatoire
        isWandering = false;

    }

    IEnumerator waitUntilEndWalk()
    {
        yield return new WaitUntil(() => distanceRemain == 0);
    }
     
     /*
     ///Première version de "wander" sans l'utilisation de NavMesh
    IEnumerator Wander(){
        //déclaration du nombres de secondes que peut prendre l'animal pour se déplacer
        int rotationTime = Random.Range(1, 3);
        int rotationWait = Random.Range(1, 3);
        int rotationDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1,20);
        int eatWait = Random.Range(1,5);
        int walkTime = Random.Range(3,10);

        
        isWandering = true;
        //décide si l'animal fait l'animation de "eat" ou non 
        int eatOrNot = Random.Range(1, 3);
        if(eatOrNot == 1){
            isEating = true;
        }
        yield return new WaitForSeconds(eatWait);
        isEating =false;

        //animal marche
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        
        //animal tourne vers la gauche pour un temps aléatoire
        yield return new WaitForSeconds(walkTime);
        if(rotationDirection == 1){
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }

        //animal tourne vers la droite pour un temps aléatoire
        if(rotationDirection == 2){
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        //animal arréte de marcher
        animator.SetBool("IsWalking", false);
        isWandering = false;

    }
    */

    IEnumerator CheckIfStuck(){
        position = transform.position;
        yield return new WaitForSeconds(5);
        if(transform.position == position || 
        ((int)transform.position.y == (int)position.y && (int)transform.position.z == (int)position.z && (int)transform.position.x == (int)position.x) ) {
            agent.destination = rigidBodyComponent.transform.position;
            Debug.Log("yes");
        }
    }
}
