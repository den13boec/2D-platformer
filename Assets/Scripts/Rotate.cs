using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Rotate(0,0,360*speed*Time.deltaTime);
    }
}
