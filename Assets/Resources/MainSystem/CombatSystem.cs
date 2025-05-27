using UnityEngine;
using System.Collections;

public class CoroutineExample : MonoBehaviour
{
    void Start()
    {
        // �Ұʨ�{
        StartCoroutine(Fighting());
    }

    IEnumerator Fighting()
    {
        while (true)
        {
            int res = Random.Range(0, 15);
            Debug.Log(res);

            // ����1.5��
            yield return new WaitForSeconds(1.5f);
        }
    }
}
