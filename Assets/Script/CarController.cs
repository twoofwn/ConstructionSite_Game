using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 10f;
    public float turnSpeed = 2f;
    private int currentWaypoint = 0;
    void Update()
    {
        if (waypoints.Length == 0) return;
        Transform target = waypoints[currentWaypoint];
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) < 2f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }
}