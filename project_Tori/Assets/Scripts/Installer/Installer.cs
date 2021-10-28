using Connector.Player;
using UnityEngine;
using Virtuality.Player;
using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        // Zenjectを使うために必要な奴
        // 事前準備的な奴

        Container.BindInterfacesAndSelfTo<PlayerTransformChange>()
            .AsSingle();
    }
}