using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //duration = 継続時間　magnitude = 震度　
    public IEnumerator Shake (float duration, float magnitude)
    {
        //元々のカメラ位置を記録する
        Vector3 originalPos = transform.localPosition;

        //経過された時間
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            //時間を加算する
            timeElapsed += Time.deltaTime;

            //UPDATE()と同時に行う
            yield return null;
        }
    }
}
