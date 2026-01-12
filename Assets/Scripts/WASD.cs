using UnityEngine;

public class WASD : MonoBehaviour
{
    //移動速度
    private float _speed = 3.0f;

    //x軸方向の入力を保存
    private float _input_x;
    //z軸方向の入力を保存
    private float _input_z;

    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _input_x = Input.GetAxis("Horizontal");
        _input_z = Input.GetAxis("Vertical");

        // ★ 自分の向き基準で移動
        Vector3 velocity =
            transform.right * _input_x +
            transform.forward * _input_z;

        float speed = Mathf.Clamp01(velocity.magnitude);

        if (speed > 0.01f)
        {
            Vector3 direction = velocity.normalized;
            transform.position += direction * _speed * Time.deltaTime;
        }

        _animator.SetFloat("Speed", speed);
    }
}