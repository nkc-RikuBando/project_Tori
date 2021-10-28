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


            // Start is called before the first frame update
            void Start()
            {
                // �ړ�
                _playerInfoStateSentable.GetPlayerPosObservable()
                    .Subscribe(x => transform.position += Vector3.Scale(x, transform.forward));

                

                // ��]
                _playerInfoStateSentable.GetPlayerRotObservable()
                    .Subscribe(x => transform.Rotate(x));

            }

            private void Update()
            {
            }
        }

    }
}
