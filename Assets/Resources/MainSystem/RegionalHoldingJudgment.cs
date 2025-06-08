using UnityEngine;

public class RegionalHoldingJudgment : MonoBehaviour
{
    private void FixedUpdate()
    {
        foreach (Transform region in transform)//掛在台南地圖上時，會取得台南地圖的子物件，也就是11個區域
        {
            bool isOwned = region.CompareTag("Player");//儲存該區域是否是Player這個TAG

            foreach (Transform child in region)//抓取各區域下的子物件
            {
                if (child.CompareTag("Flag"))//判斷各區域下的子物件是否有Flag這個TAG
                {
                    child.gameObject.SetActive(isOwned);//子物件將根據該區域是否屬於玩家進行顯示或隱藏
                }
            }
        }
    }
}
