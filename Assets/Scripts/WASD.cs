using UnityEngine;

public class WASD : MonoBehaviour {
    //移動速度
    private float _speed = 3.0f;

    //x軸方向の入力を保存
    private float _input_x;
    //z軸方向の入力を保存
    private float _input_z;

    private Animator _animator;
    void Start() {
        _animator = GetComponent<Animator>();
    }

    void Update() {
        //x軸方向、z軸方向の入力を取得
        //Horizontal、水平、横方向のイメージ
        _input_x = Input.GetAxis("Horizontal");
        //Vertical、垂直、縦方向のイメージ
        _input_z = Input.GetAxis("Vertical");

        //移動の向きなど座標関連はVector3で扱う
        Vector3 velocity = new Vector3(_input_x, 0, _input_z);
        
        // 入力の大きさ（0〜1）
        float speed = velocity.magnitude;
        
        if (speed > 0.01f)
        {
            Vector3 direction = velocity.normalized;
            float distance = _speed * Time.deltaTime;

            Vector3 destination = transform.position + direction * distance;

            transform.LookAt(destination);
            transform.position = destination;
        }

        // ★ Animatorに速度を渡す（これが核心）
        _animator.SetFloat("Speed", speed);
        
        // //ベクトルの向きを取得
        // Vector3 direction = velocity.normalized;

        // //移動距離を計算
        // float distance = _speed * Time.deltaTime;
        // //移動先を計算
        // Vector3 destination = transform.position + direction * distance;

        // //移動先に向けて回転
        // transform.LookAt(destination);
        // //移動先の座標を設定
        // transform.position = destination;
    }
}