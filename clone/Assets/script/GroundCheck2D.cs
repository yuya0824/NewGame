using UnityEditor;
using UnityEngine;

public class WireArcExample : MonoBehaviour
{
    public float shieldArea;
}
public class GroundCheck2D : MonoBehaviour
{

    [SerializeField]
    float groundCheckRadius = 0.4f;
    [SerializeField]
    float groundCheckOffsetY = 0.45f;
    [SerializeField]
    float groundCheckDistance = 0.2f;
    [SerializeField]
    LayerMask groundLayers = 0;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + groundCheckOffsetY * Vector2.up, groundCheckRadius);
    }
    //void OnSceneGUI()
    //{
    //    Handles.color = Color.red;
    //    WireArcExample myObj = (WireArcExample)target;
    //    Handles.DrawWireArc(myObj.transform.position, myObj.transform.up, -myObj.transform.right, 180, myObj.shieldArea);
    //    myObj.shieldArea = (float)Handles.ScaleValueHandle(myObj.shieldArea, myObj.transform.position + myObj.transform.forward * myObj.shieldArea, myObj.transform.rotation, 1, Handles.ConeHandleCap, 1);
    //}
    public RaycastHit2D CheckGroundStatus()
    {
        return Physics2D.CircleCast((Vector2)transform.position + groundCheckOffsetY * Vector2.up, groundCheckRadius, Vector2.down, groundCheckDistance, groundLayers);
    }

}