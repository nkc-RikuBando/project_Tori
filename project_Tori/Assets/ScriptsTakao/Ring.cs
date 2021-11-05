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

    bool appearRingFlg = false; //�߂Â������̃t���O
    bool passRingFlg = false;   //�����������̃t���O

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
        if (passRingFlg) return; //�����O��ʂ��Ă����炻���������m����K�v���Ȃ�
        var ToPlayerGoThrough = collider.gameObject.GetComponent<Reality.Player.PlayerMover>(); //���̃X�N���v�g�������Ă���I�u�W�F�N�g���G�ꂽ�������m
        if (ToPlayerGoThrough != null)
        {
            GoThroughToRing();
        }
    }

    public void PlayerDistance()
    {
        Vector3 playerPos = player.transform.position;   //�v���C���[�̍��W
        Vector3 ringPos = gameObject.transform.position; //�����O�̍��W

        distance = Vector3.Distance(playerPos, ringPos); //�v���C���[�̍��W�@-�@�����O�̍��W�@=�@distance

        //�߂����������ŕς�鏈��
        if (!appearRingFlg)
        {
            if (!(distance < findDistance && distance >= -(findDistance))) return; //�͈͓��ɂ�����
            appearRingFlg = true; //������A�j���[�V�������Ȃ��悤�ɂ���
            ApproachToRing();
        }

        if (appearRingFlg)
        {
            if (!(distance > findDistance || distance < -(findDistance))) return; //�͈͊O�ɂ�����
            appearRingFlg = false; //������A�j���[�V�������Ȃ��悤�ɂ���
            DepartToRing();
        }
    }

    public void ApproachToRing() //�߂Â�������
    {
        if (appearRingFlg)
        {
            //animator.SetBool("isAppear", true);
            ringAnimation.AppearAnimstion();
            Debug.Log("�傫���Ȃ�A�j���[�V����");
        }
    }

    public void DepartToRing() //��������������
    {
        if (!appearRingFlg)
        {
            //animator.SetBool("isAppear", false);
            ringAnimation.DisappearAnimation();
            Debug.Log("�������Ȃ�A�j���[�V����");
        }
    }

    public void GoThroughToRing() //������������
    {
        passRingFlg = true; //�ʂ��������O���ēx���m���Ȃ��悤�ɂ���
        //animator.SetBool("isPassing", true);
        audioSource.PlayOneShot(sound_1);
        ringAnimation.PassingAnimation();
        Debug.Log("������");
        ruleManager.PassRing();
        ruleManager.RingNameSet(ringName);
    }

}
