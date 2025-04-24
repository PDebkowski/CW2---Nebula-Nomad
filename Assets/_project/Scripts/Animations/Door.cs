using UnityEngine;

public class Door : MonoBehaviour
{
    [Tooltip("Root transform of this door (used for distance checks)")]
    public Transform doorTransform;
    public Animator topDoorAnimator;
    public Animator bottomDoorAnimator;
    public AudioSource doorSound;

    [HideInInspector] public bool isOpen = false;
}