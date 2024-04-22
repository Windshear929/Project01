using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothTime;

    float maxX = 56;
    float minX = 0;
    float maxY = 0;
    float minY = -3;

    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
                targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothTime);
            }
        }
    }
}
