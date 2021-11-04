using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Connector.Player;


namespace Reality
{
    namespace Player
    {
        public class PlayerMover : MonoBehaviour
        {
            // Player�̈ړ�����

            [Inject] private IPlayerInfoStateSentable _playerInfoStateSentable;

            [SerializeField] private GameObject _avater;

            private Rigidbody rb;

            // Start is called before the first frame update
            void Start()
            {

                rb = GetComponent<Rigidbody>();

                // ��]
                _playerInfoStateSentable.GetPlayerRotObservable()
                    .Subscribe(r => _avater.transform.rotation = r);

                // �ړ�
                _playerInfoStateSentable.GetPlayerPosObservable()
                    .Subscribe(v => rb.velocity = v);

            }
        }

    }
}
