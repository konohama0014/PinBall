using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private float visiblePosZ = -6.5f;

    private GameObject gameoverText;

    //���W�ۑ�X�R�A
    private int score = 0;
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");

        //���W�ۑ�X�R�A
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o�[��\��
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }

    }

    void OnCollisionEnter(Collision other)
    {
        // �^�O�ɂ���ăe�L�X�g��ς���
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 30;
        }

        this.scoreText.GetComponent<Text>().text = "SCORE: " + this.score;
    }


}
