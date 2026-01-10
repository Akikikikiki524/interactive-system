using UnityEngine;

public class AlienTimer : MonoBehaviour
{
    [SerializeField] private GameObject Alien;
    public float eventInterval = 10f; // 次のイベントまでの間隔
    public float eventDuration = 5f;  // 宇宙人が消えるまでの時間（イベントの長さ）
    
    private float currentTime = 0f;
    private bool isEventActive = false; // イベント中かどうか
    private GameObject currentAlien;    // 生成した宇宙人を保持する変数

    void Update()
    {
        // イベント中（isEventActiveがtrue）なら、これ以降の処理（タイマー）を無視する
        if (isEventActive) return;

        // 時間を加算
        currentTime += Time.deltaTime;
        Debug.Log("出現まであと: " + (eventInterval - currentTime).ToString("F1"));

        // 指定した時間を超えたらイベント発生
        if (currentTime >= eventInterval)
        {
            TriggerAlienEvent();
            currentTime = 0f; 
        }
    }

    void TriggerAlienEvent()
    {
        if (Alien != null)
        {
            isEventActive = true; // タイマーをストップ
            Debug.Log("宇宙人襲来！タイマー停止");

            // 宇宙人を生成し、変数に保存しておく
            currentAlien = Instantiate(Alien, Vector3.zero, Quaternion.identity);

            // 指定秒数（eventDuration）後にイベントを終わらせる
            Invoke("EndEvent", eventDuration);
        }
        else
        {
            Debug.LogWarning("物体がアタッチされていません！");
        }
    }

    void EndEvent()
    {
        Debug.Log("イベント終了。宇宙人を消去してタイマー再開");

        // 宇宙人が存在していれば消す
        if (currentAlien != null)
        {
            Destroy(currentAlien);
        }

        isEventActive = false; // タイマー再開
    }
}