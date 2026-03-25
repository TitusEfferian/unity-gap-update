
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Vector3 offset;
    void LateUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }

}
