using UnityEngine;

[ExecuteAlways]
public class SpringArm : MonoBehaviour
{
    [SerializeField] private Transform mAttachTransform;
    [SerializeField] private float mArmLength = 3f;
    [SerializeField] private float mCameraCollisionOffset = 0.1f;
    [SerializeField] private bool mDoCollisionTest = true;
    [SerializeField] private LayerMask mCollisionLayerMask;

    void LateUpdate()
    {
        Vector3 endPosition = transform.position - transform.forward * mArmLength;
        if (Physics.Raycast(transform.position, -transform.forward, out RaycastHit hitInfo, mArmLength, mCollisionLayerMask))
        {
            endPosition = hitInfo.point + transform.forward * mCameraCollisionOffset;
        }

        mAttachTransform.position = endPosition;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, mAttachTransform.position);
    }
}
