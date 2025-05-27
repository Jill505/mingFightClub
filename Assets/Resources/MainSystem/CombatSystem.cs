using UnityEngine;
using System.Collections;

public class CoroutineExample : MonoBehaviour
{
    void Start()
    {
        // 啟動協程
        StartCoroutine(Fighting());
    }

    IEnumerator Fighting()
    {
        while (true)
        {
            int res = Random.Range(0, 15);
            Debug.Log(res);

            // 等待1.5秒
            yield return new WaitForSeconds(1.5f);
        }
    }
}
