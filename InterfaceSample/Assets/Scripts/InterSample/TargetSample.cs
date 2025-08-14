using System.Collections;
using UnityEngine;

public class TargetSample : MonoBehaviour
{
    public bool isAttacked;
    void Update()
    {
        if (isAttacked)
            StartCoroutine(Damaged());
        else
            StopAllCoroutines();
    }

   IEnumerator Damaged()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1.0f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        isAttacked = false;
    }
}
