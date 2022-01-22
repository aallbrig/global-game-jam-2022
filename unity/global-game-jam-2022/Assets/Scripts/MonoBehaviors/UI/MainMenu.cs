using UnityEngine;

namespace MonoBehaviors.UI
{
    public interface IMainMenuInteractions
    {
        public void StartGame();
    }
    public class MainMenu : MonoBehaviour
    {
        public IMainMenuInteractions Interactions;
        public void Start()
        {
            Interactions ??= GetComponent<IMainMenuInteractions>();
            Interactions ??= new FakeMainMenuInteractions();
        }

        public void StartGame() => Interactions.StartGame();
    }

    public class FakeMainMenuInteractions : IMainMenuInteractions
    {
        public void StartGame() {}
    }
}