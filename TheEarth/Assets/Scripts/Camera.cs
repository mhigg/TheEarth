using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public CameraShake cameraShake;
    public GameObject player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(cameraShake.Shake(3f,.1f));
            Vector3 playerPos = player.transform.position;
            playerPos.x -= .3f;
            playerPos.y -= .3f;
            var particle = Instantiate(Resources.Load("Explosion loop_2 soft", typeof(GameObject)), playerPos, player.transform.rotation);
            Destroy(particle, 4f);
        }
    }
}
