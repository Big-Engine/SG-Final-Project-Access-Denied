using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform playerTransform = null;
    [SerializeField] GameObject mainCamera = null;
    [SerializeField] GameObject background = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerTransform.position = new Vector3(44.5f, 113, 0);

            mainCamera.GetComponent<Follow>().enabled = false;
            background.GetComponent<Follow>().enabled = false;

            mainCamera.transform.position = new Vector3(44.45f, 105, -10);
            background.transform.position = new Vector3(44, 105, .25f);

            mainCamera.GetComponent<Camera>().orthographicSize = 8.75f;
        }
    }
}
