using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform playerBody;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerBody.transform.position;
    }
}
