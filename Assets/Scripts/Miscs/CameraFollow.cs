using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothTime;

    [SerializeField] float maxX = 56;
    [SerializeField] float minX = 0;
    [SerializeField] float maxY = 0;
    [SerializeField] float minY = -3;

    void Update()
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
