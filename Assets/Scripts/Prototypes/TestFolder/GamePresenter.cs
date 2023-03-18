using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer.Unity;

namespace Assets.Scripts.TestFolder
{
    public class GamePresenter : IStartable
    {
        readonly DITestService _dITestService;
        readonly HelloScreen _helloSceen;

        public GamePresenter(
            DITestService dITestService,
            HelloScreen helloScreen
            )
        {
            _dITestService = dITestService;
            _helloSceen = helloScreen;
        }

        public void Start()
        {
            _helloSceen.HelloButton.onClick.AddListener(() =>
            {
                _dITestService.HelloWorld();
            });
        }

    }
}
