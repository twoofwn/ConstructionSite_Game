using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints;

    public float speed = 7f;
    public float turnSpeed = 2f;
    public float waypointDistance = 1f;

    private int currentWaypoint = 0;
    private bool goingForward = true;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        Transform target = waypoints[currentWaypoint];

        Vector3 direction = target.position - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime
            );
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < waypointDistance)
        {
            if (goingForward)
            {
                if (currentWaypoint < waypoints.Length - 1)
                {
                    currentWaypoint++;
                }
                else
                {
                    goingForward = false;
                    currentWaypoint--;
                }
            }
            else
            {
                if (currentWaypoint > 0)
                {
                    currentWaypoint--;
                }
                else
                {
                    goingForward = true;
                    currentWaypoint++;
                }
            }
        }
    }
}