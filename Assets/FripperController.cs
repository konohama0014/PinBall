using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;

    //�e�������̌X��
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //Hingejoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        
        //���W�ۑ�@�^�b�`���ꂽ��
        if (Input.touchCount > 0)
        {

            //�w�P�{�̏ꍇ
            //�^�b�`���擾��
            Touch touch0 = Input.GetTouch(0);

            //���^�b�`�����獶�t���b�p�[�𓮂���
            if( (touch0.position.x < 540) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //�E�^�b�`������E�t���b�p�[�𓮂���
            if( ( touch0.position.x >= 540) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            // �����ɂȂ�����E������
            if( (touch0.position.x >= 540) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

            // �E���ɂȂ����獶�����낷
            if( (touch0.position.x < 540) && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }


            //�w�Q�{�ڂ̏���
            //�Q�{�ڂ��^�b�`�ł����ꍇ
            if (Input.touchCount > 1)
            {
                Touch touch1 = Input.GetTouch(1);

                //���^�b�`�����獶�t���b�p�[�𓮂���
                if (( (touch1.position.x < 540)) && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //�E�^�b�`������E�t���b�p�[�𓮂���
                if (( (touch1.position.x >= 540)) && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                // ���������ɂȂ�����E�����낷
                if (((touch0.position.x >= 540) && (touch1.position.x >= 540)) && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }

                // �����E���ɂȂ����獶�����낷
                if (((touch0.position.x < 540) && (touch1.position.x < 540)) && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }


                //�w�R�{�ڂ̏���
                //�R�{�ڂ��^�b�`�ł����ꍇ
                if (Input.touchCount > 2)
                {
                    Touch touch2 = Input.GetTouch(2);

                    //���^�b�`�����獶�t���b�p�[�𓮂���
                    if (((touch2.position.x < 540)) && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                    //�E�^�b�`������E�t���b�p�[�𓮂���
                    if (((touch2.position.x >= 540)) && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                    // ���������ɂȂ�����E�����낷
                    if (((touch0.position.x >= 540) && (touch1.position.x >= 540) && (touch2.position.x >= 540)) && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }

                    // �����E���ɂȂ����獶�����낷
                    if (((touch0.position.x < 540) && (touch1.position.x < 540) && (touch2.position.x < 540)) && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
        else // �^�b�`�𗣂�����t���b�p�[��߂�
        {
            SetAngle(this.defaultAngle);
        }
        

        //�����L�[�A������A�������������t���b�p�[�𓮂���
        if (( Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //�E���L�[�A������D�����������E�t���b�p�[�𓮂���
        if (( Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) ) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //S�����������A�t���b�p�[�𓮂���
        if (Input.GetKey(KeyCode.S))
        {
            SetAngle(this.flickAngle);
        }

        //���L�[�������ꂽ���t���b�p�[�����ɖ߂�
        if (( Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S)) && tag == "LeftFripperTag") 
        {
            SetAngle(this.defaultAngle);
        }

        if (( Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S)) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //�t���b�p�[������
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
