using UnityEngine;

public class AlienTimer : MonoBehaviour
{
    public float eventInterval = 30f; // 何秒ごとに来るか
    private float currentTime = 0f;   // 現在のタイマー値

    void Update()
    {
        // 時間を加算
        currentTime += Time.deltaTime;

        // 指定した時間を超えたらイベント発生
        if (currentTime >= eventInterval)
        {
            TriggerAlienEvent();
            currentTime = 0f; // タイマーをリセット
        }
    }

    void TriggerAlienEvent()
    {
        Debug.Log("宇宙人襲来イベント発生！");
        // ここに宇宙人を出す処理を書く
    }

    // UIなどに残り時間を表示したい場合に便利
    public float GetRemainingTime()
    {
        return Mathf.Max(0, eventInterval - currentTime);
    }
}