using UnityEngine;
using System.Collections.Generic;

public class DoubleDoorController : MonoBehaviour
{
    [Tooltip("Player or camera transform")]
    public Transform player;

    [Tooltip("All the doors you want this script to manage")]
    public List<Door> doors = new List<Door>();

    [Tooltip("Distance within which doors open")]
    [SerializeField] private float openDistance;

    void Update()
    {
        foreach (var door in doors)
        {
            float dist = Vector3.Distance(door.doorTransform.position, player.position);

            if (dist <= openDistance && !door.isOpen)
                ToggleDoor(door, true);
            else if (dist > openDistance && door.isOpen)
                ToggleDoor(door, false);
        }
    }

    private void ToggleDoor(Door door, bool open)
    {
        door.isOpen = open;

        string trigger = open ? "Open" : "Close";
        door.topDoorAnimator.SetTrigger(trigger);
        door.bottomDoorAnimator.SetTrigger(trigger);

        if (door.doorSound != null)
            door.doorSound.Play();
    }
}