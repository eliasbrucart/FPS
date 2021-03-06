using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ghost : MonoBehaviour
{
    public enum GhostState
    {
        Idle,
        GoingToTarget,
        GoAway,
        Last
    }

    [SerializeField] private GhostState state;

    [SerializeField] private float speed = 10;
    [SerializeField] private float distanceStop = 6;
    [SerializeField] private float distanceRestart = 20;

    [SerializeField] private Transform target;

    [SerializeField] private float time;
    [SerializeField] private float timeSpawn;

    private void Start()
    {
        target = FindObjectOfType<FirstPersonController>().transform;
    }

    private void Update()
    {
        MoveGhost();
    }

    public void MoveGhost()
    {
        time += Time.deltaTime;
        switch (state)
        {
            case GhostState.Idle:
                if (time > 10)
                {
                    NextState();
                }
                break;
            case GhostState.GoingToTarget:
                if(target != null)
                {
                    Vector3 direction = target.position - transform.position;
                    transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
                    if (Vector3.Distance(transform.position, target.position) < distanceStop)
                        NextState();
                }
                break;
            case GhostState.GoAway:
                if(target != null)
                {
                    Vector3 direction2 = transform.position - target.position;
                    transform.Translate(direction2.normalized * speed * Time.deltaTime, Space.World);
                    if (Vector3.Distance(transform.position, target.position) > distanceRestart)
                        NextState();
                }
                break;
        }
    }

    private void NextState()
    {
        time = 0;
        int nextState = (int)state;
        nextState++;
        nextState = nextState % ((int)GhostState.Last);
        SetState((GhostState)nextState);
    }
    
    private void SetState(GhostState newState)
    {
        state = newState;
    }
}
