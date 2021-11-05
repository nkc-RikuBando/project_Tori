using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ring : MonoBehaviour
{
    [SerializeField] string ringName;
    [SerializeField] private AudioClip sound_1;

    int passRingNum = 0;

    float distance;

    float findDistance = 60;

    bool appearRingFlg = false; //近づいたかのフラグ
    bool passRingFlg = false;   //くぐったかのフラグ

    private GameObject player;
    private AudioSource audioSource;
    //private GameObject ringObject;

    private RingAnimation ringAnimation;
    private RuleManager ruleManager;
    //private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //ringObject = gameObject.transform.GetChild(0).gameObject;
        player = GameObject.Find("Player");
        ruleManager = GameObject.Find("RuleManager").GetComponent<RuleManager>();
        ringAnimation = GetComponent<RingAnimation>();
        audioSource = GetComponent<AudioSource>();

        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistance();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (passRingFlg) return; //リングを通っていたらそもそも検知する必要がない
        var ToPlayerGoThrough = collider.gameObject.GetComponent<Reality.Player.PlayerMover>(); //このスクリプトを持っているオブジェクトが触れたかを検知
        if (ToPlayerGoThrough != null)
        {
            GoThroughToRing();
        }
    }

    public void PlayerDistance()
    {
        Vector3 playerPos = player.transform.position;   //プレイヤーの座標
        Vector3 ringPos = gameObject.transform.position; //リングの座標

        distance = Vector3.Distance(playerPos, ringPos); //プレイヤーの座標　-　リングの座標　=　distance

        //近いか遠いかで変わる処理
        if (!appearRingFlg)
        {
            if (!(distance < findDistance && distance >= -(findDistance))) return; //範囲内にいたら
            appearRingFlg = true; //何回もアニメーションしないようにする
            ApproachToRing();
        }

        if (appearRingFlg)
        {
            if (!(distance > findDistance || distance < -(findDistance))) return; //範囲外にいたら
            appearRingFlg = false; //何回もアニメーションしないようにする
            DepartToRing();
        }
    }

    public void ApproachToRing() //近づいた処理
    {
        if (appearRingFlg)
        {
            //animator.SetBool("isAppear", true);
            ringAnimation.AppearAnimstion();
            Debug.Log("大きくなるアニメーション");
        }
    }

    public void DepartToRing() //遠ざかった処理
    {
        if (!appearRingFlg)
        {
            //animator.SetBool("isAppear", false);
            ringAnimation.DisappearAnimation();
            Debug.Log("小さくなるアニメーション");
        }
    }

    public void GoThroughToRing() //くぐった処理
    {
        passRingFlg = true; //通ったリングを再度検知しないようにする
        //animator.SetBool("isPassing", true);
        audioSource.PlayOneShot(sound_1);
        ringAnimation.PassingAnimation();
        Debug.Log("消える");
        ruleManager.PassRing();
        ruleManager.RingNameSet(ringName);
    }

}
