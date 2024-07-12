using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float offSet;
    
    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 cameraPosition = transform.position;
            cameraPosition.z = playerTransform.position.z + offSet;
            transform.position = cameraPosition;
        }
        
    }

}