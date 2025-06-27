using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanim : MonoBehaviour
{
    public Transform door;
    public bool open;

    public Transform closedMarker, openedMarker;

    public float speed = 1;

    private void Update()
    {
        if (open)
            door.position = Vector3.MoveTowards(door.position, openedMarker.position, speed * Time.deltaTime);
        else
            door.position = Vector3.MoveTowards(door.position, closedMarker.position, speed *Time.deltaTime);
    }

}
