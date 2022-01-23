using UnityEngine;

namespace MonoBehaviors.UI
{
    public interface IMainMenuInteractions
    {
        public void StartGame();
        public void ViewSource();
        public void TestBed();
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
        public void ViewSource() => Interactions.ViewSource();
        public void TestBed() => Interactions.TestBed();
    }

    public class FakeMainMenuInteractions : IMainMenuInteractions
    {
        public void StartGame() {}
        public void ViewSource() {}
        public void TestBed() {}
    }
}