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
  }
  
  // Update is called once per frame
  void Update ()
  {
    timer += Time.deltaTime;

    if (timer >= wanderTimer)
    {
      Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
      agent.SetDestination(newPos);
      timer = 0;
    }
  }

  public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
  {
    Vector3 randDirection = Random.insideUnitSphere * dist;

    randDirection += origin;

    NavMeshHit navHit;

    NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

    return navHit.position;
  }
}