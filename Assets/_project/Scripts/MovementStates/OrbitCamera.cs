using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance; 
    [SerializeField] private float orbitSpeed;  
    [SerializeField] private float verticalAngle; 

    private float currentAngle = 0f;

    void LateUpdate()
    {
        if (!target) return;

        currentAngle += orbitSpeed * Time.deltaTime;
        if (currentAngle > 360f) currentAngle -= 360f;

        float radH = currentAngle * Mathf.Deg2Rad;
        float radV = verticalAngle * Mathf.Deg2Rad;

        float x = target.position.x + distance * Mathf.Cos(radV) * Mathf.Cos(radH);
        float y = target.position.y + distance * Mathf.Sin(radV);
        float z = target.position.z + distance * Mathf.Cos(radV) * Mathf.Sin(radH);

        transform.position = new Vector3(x, y, z);
        transform.LookAt(target);
    }
}