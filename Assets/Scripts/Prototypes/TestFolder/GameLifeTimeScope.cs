using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.TestFolder
{
    class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private HelloScreen _helloScreen;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<DITestService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GamePresenter>();
            builder.RegisterComponent(_helloScreen);
        }
    }
}
