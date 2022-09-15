using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
 private void Update()
    {
        // Get player's X and Y position, but keep camera default Z position
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
    }
}
