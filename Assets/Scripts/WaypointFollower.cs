using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int _currentWaypointIndex = 0;
    [SerializeField] private float speed;
    private void Update()
    {
        // Check distance between platform and waypoint
        if (Vector2.Distance(waypoints[_currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            _currentWaypointIndex++;
            // If all waypoints have been passed, reset index of waypoint
            if (_currentWaypointIndex >= waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }
        // Move platform
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[_currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
