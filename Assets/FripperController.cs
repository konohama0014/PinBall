using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //Hingejointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        
        //発展課題　タッチされたら
        if (Input.touchCount > 0)
        {

            //指１本の場合
            //タッチを取得し
            Touch touch0 = Input.GetTouch(0);

            //左タッチしたら左フリッパーを動かす
            if( (touch0.position.x < 540) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //右タッチしたら右フリッパーを動かす
            if( ( touch0.position.x >= 540) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            // 左側になったら右を下ろ
            if( (touch0.position.x >= 540) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

            // 右側になったら左を下ろす
            if( (touch0.position.x < 540) && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }


            //指２本目の処理
            //２本目がタッチできた場合
            if (Input.touchCount > 1)
            {
                Touch touch1 = Input.GetTouch(1);

                //左タッチしたら左フリッパーを動かす
                if (( (touch1.position.x < 540)) && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //右タッチしたら右フリッパーを動かす
                if (( (touch1.position.x >= 540)) && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                // 両方左側になったら右を下ろす
                if (((touch0.position.x >= 540) && (touch1.position.x >= 540)) && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }

                // 両方右側になったら左を下ろす
                if (((touch0.position.x < 540) && (touch1.position.x < 540)) && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }


                //指３本目の処理
                //３本目がタッチできた場合
                if (Input.touchCount > 2)
                {
                    Touch touch2 = Input.GetTouch(2);

                    //左タッチしたら左フリッパーを動かす
                    if (((touch2.position.x < 540)) && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                    //右タッチしたら右フリッパーを動かす
                    if (((touch2.position.x >= 540)) && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                    // 両方左側になったら右を下ろす
                    if (((touch0.position.x >= 540) && (touch1.position.x >= 540) && (touch2.position.x >= 540)) && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }

                    // 両方右側になったら左を下ろす
                    if (((touch0.position.x < 540) && (touch1.position.x < 540) && (touch2.position.x < 540)) && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
        else // タッチを離したらフリッパーを戻す
        {
            SetAngle(this.defaultAngle);
        }
        

        //左矢印キー、或いはAを押した時左フリッパーを動かす
        if (( Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //右矢印キー、或いはDを押した時右フリッパーを動かす
        if (( Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) ) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //Sを押した時、フリッパーを動かす
        if (Input.GetKey(KeyCode.S))
        {
            SetAngle(this.flickAngle);
        }

        //矢印キーが離された時フリッパーを元に戻す
        if (( Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S)) && tag == "LeftFripperTag") 
        {
            SetAngle(this.defaultAngle);
        }

        if (( Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S)) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパー動かす
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
