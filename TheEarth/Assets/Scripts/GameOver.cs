using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public CameraShake cameraShake;
    public GameObject player;
    private AudioSource ExplosionSE;

    // test
    bool flag;
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        ExplosionSE = audioSources[0];
        flag = false;
    }

    void Update()
    {
        
        if (mainEndMng.EndFlag)
        {
            if (!flag)
            {
                GameOverNow();
                flag = true;
            }
        }
    }

    public void GameOverNow()
    {
        StartCoroutine(cameraShake.Shake(4f, 10f));
        Vector3 playerPos = player.transform.position;
        playerPos.x -= .3f;
        playerPos.y -= .3f;
        StartCoroutine(Particle(15, 150f, 4f, playerPos, player.transform.rotation));
        ExplosionSE.PlayOneShot(ExplosionSE.clip);
    }

    IEnumerator Particle(int count, float randomRange, float duration, Vector3 pos, Quaternion rotation)
    {
        int spawnedCount = 0;
        while (spawnedCount < count)
        {
            var particle = Instantiate(Resources.Load("Explosion loop_2 soft", typeof(GameObject)), 
                new Vector3 (pos.x + Random.Range(-randomRange, randomRange),
                pos.y + Random.Range(-randomRange, randomRange),
                pos.z + Random.Range(-randomRange, randomRange)), 
                rotation) as GameObject;
            particle.transform.localScale = new Vector3(100, 100, 100);
            Destroy(particle, duration + (float)count / 10);

            //数を加算する
            spawnedCount++;

            //UPDATE()と同時に行う
            yield return null;
        }
    }
}
