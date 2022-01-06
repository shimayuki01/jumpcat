using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkForce = 10.0f;
    float maxWalkSpeed = 0.5f;
    Animator animator;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v����
        if (Input.GetKeyDown(KeyCode.UpArrow) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //�ړ�����
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //���x�擾
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //���x����
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //���������ŉ摜���]
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //���x�ɉ����ăA�j���[�V�����̑��x��ύX
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //��������ŏ�����
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //�S�[������
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�S�[��");
        SceneManager.LoadScene("ClearScene");
    }
}
