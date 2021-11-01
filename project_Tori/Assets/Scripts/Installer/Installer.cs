using Connector.Player;
using UnityEngine;
using Virtuality.Player;
using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        // Zenject���g�����߂ɕK�v�ȓz
        // ���O�����I�ȓz

        Container.BindInterfacesAndSelfTo<PlayerTransformChange>()
            .AsSingle();
    }
}