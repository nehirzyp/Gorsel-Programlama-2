using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 45, -45);

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.LookAt(player);
        }
    }
}
