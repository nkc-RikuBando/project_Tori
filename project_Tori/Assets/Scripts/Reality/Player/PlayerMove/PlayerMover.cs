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
            // Playerの移動処理

            [Inject] private IPlayerInfoStateSentable _playerInfoStateSentable;

            [SerializeField] private GameObject _avater;

            private Rigidbody rb;

            // Start is called before the first frame update
            void Start()
            {

                rb = GetComponent<Rigidbody>();

                // 回転
                _playerInfoStateSentable.GetPlayerRotObservable()
                    .Subscribe(r => _avater.transform.rotation = r);

                // 移動
                _playerInfoStateSentable.GetPlayerPosObservable()
                    .Subscribe(v => rb.velocity = v);

            }
        }

    }
}
