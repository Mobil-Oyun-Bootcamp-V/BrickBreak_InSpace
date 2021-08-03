using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SupportClass  
{
   public static IEnumerator LerpMove(GameObject Object,Vector2 currentPos,Vector2 targetPos,float totalTime)
    {
        float time = 0;
        while (time < totalTime)
        {
            Object.transform.position = Vector2.Lerp(currentPos, targetPos, time / totalTime);
            time += Time.deltaTime;
            yield return null;
        }
        Object.transform.position = targetPos;
    }
}
