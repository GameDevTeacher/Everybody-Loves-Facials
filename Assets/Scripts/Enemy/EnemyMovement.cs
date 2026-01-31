using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour 
{

  public float wanderRadius;
  public float wanderTimer;
  public float waitTimer;

  private Transform target;
  private NavMeshAgent agent;
  private float timer;

  // Use this for initialization
  void OnEnable ()
  {
    agent = GetComponent<NavMeshAgent> ();
    timer = wanderTimer;
    timer = waitTimer;
    StartCoroutine(wander());
  }

  IEnumerator wander()
  {
    yield return new WaitForSeconds (2);
    Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
    agent.SetDestination(newPos);
    yield return new WaitForSeconds (5);
    agent.ResetPath ();
    StartCoroutine (wander());
  }
  
  // Update is called once per frame
  void Update ()
  {
   /* timer += Time.deltaTime;

    if (timer >= wanderTimer)
    {
      Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
      agent.SetDestination(newPos);
      timer = 0;
      
    }*/
  }

  public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
  {
    Vector3 randDirection = Random.insideUnitSphere * dist;

    randDirection += origin;

    NavMeshHit navHit;

    NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

    timer = wanderTimer + Time.time;

    return navHit.position;
  }
}