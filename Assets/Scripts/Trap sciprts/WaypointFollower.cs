using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoint;
    private int _Currentwaypointindex = 0;
    [SerializeField] private float speedwaypoint = 2f;

  
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(Waypoint[_Currentwaypointindex].transform.position,transform.position) < .1f)
        {
            _Currentwaypointindex++;
            if(_Currentwaypointindex >=  Waypoint.Length)
            {
                _Currentwaypointindex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Waypoint[_Currentwaypointindex].transform.position, Time.deltaTime * speedwaypoint);

    }
}
