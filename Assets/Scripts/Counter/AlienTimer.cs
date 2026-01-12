using UnityEngine;
using System.Collections;

public class AlienTimer : MonoBehaviour
{
    [SerializeField] private GameObject AlienPrefab;
    public float eventInterval = 10f; 
    public float moveDuration = 3f;   // 移動にかける時間（秒）
    public float waitAtCenter = 2f;   // (0,0,5)に到着してからの待ち時間
    
    private float currentTime = 0f;
    private bool isEventActive = false;

    void Update()
    {
        if (isEventActive) return;

        currentTime += Time.deltaTime;
        if (currentTime >= eventInterval)
        {
            SoundManager.Instance.PlaySE(0, 5f); // 必要に応じてコメントアウト解除
            StartCoroutine(AlienSequence());
            currentTime = 0f; 
        }
    }

    IEnumerator AlienSequence()
{
    isEventActive = true;
    
    // 1. 初期位置と回転の設定
    Vector3 startPos = new Vector3(5f, 0f, 5f);
    Vector3 centerPos = new Vector3(0f, 0f, 5f);
    
    // Quaternion.Euler(x, y, z) を使って y方向に270度回転させた向きを作る
    Quaternion startRotation = Quaternion.Euler(0, 270f, 0);
    
    // 生成時に startRotation を渡す
    GameObject alien = Instantiate(AlienPrefab, startPos, startRotation);
    
    // 2. (0, 0, 5) まで移動
    yield return StartCoroutine(MoveTo(alien, startPos, centerPos, moveDuration));

    // 3. (0, 0, 5)に到着後、-90度回転（合計 180度になる）して少し待つ
    alien.transform.Rotate(0, -90f, 0);
    Debug.Log("イベント発生中...");
    yield return new WaitForSeconds(waitAtCenter);

    // 4. さらに -90度回転（合計 90度になり、背中を向ける）
    alien.transform.Rotate(0, -90f, 0);
    
    // 5. 元の位置 (5, 0, 5) まで戻る
    yield return StartCoroutine(MoveTo(alien, centerPos, startPos, moveDuration));

    // 6. 削除
    Destroy(alien);
    isEventActive = false;
}

    // 座標Aから座標Bへ、指定時間で滑らかに移動させる関数
    IEnumerator MoveTo(GameObject target, Vector3 start, Vector3 end, float duration)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            if (target == null) yield break;
            
            // elapsed / duration は 0から1へ変化する値
            target.transform.position = Vector3.Lerp(start, end, elapsed / duration);
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        target.transform.position = end; // 最後に目的地にピタッと合わせる
    }
}