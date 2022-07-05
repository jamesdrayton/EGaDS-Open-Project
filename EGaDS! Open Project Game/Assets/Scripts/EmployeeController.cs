using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour {

    [SerializeField] private Transform[] waypoints;
    // controls the movespeed of the employee
    [SerializeField] private float moveSpeed = 10;
    // true if the employee loops waypoints, false if it stops at the last waypoint 
    [SerializeField] private bool looping = true;
    // controls the amount of damage dealt to the player upon touching the employee
    [SerializeField] private int damage = 1;
    private int nextWaypoint = 1;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        // Sets the tired employee enemy to begin at the first waypoint
        transform.position = waypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update() {
        checkWaypoint();
        transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);
    }

    // Checks if Employee has reached nextWaypoint and updates nextWaypoint
    void checkWaypoint() {
        // change the checks to trigger on touching the waypoint objects
        if (Vector2.Distance(transform.position, waypoints[nextWaypoint].position) < 1) {
            // if the employee should do something after reaching each waypoint, do that here
            if (waypoints.Length - 1 > nextWaypoint) {
                nextWaypoint++;
            } else if (looping) {
                nextWaypoint = 0;
            }
        }
    }

    // Damages the player when they touch this enemy. Leaves room for other effects to occur.
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            // deals damage to the player equal to the serialized damage int
            Debug.Log(damage + " damage dealt to player");
            // applies other effects to the player if relevant (e.g. knockback)
        }
    }
}
