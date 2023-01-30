using Movement;
using UnityEngine;

namespace ManualTest
{
#if UNITY_EDITOR
    public class TestButton : MonoBehaviour
    {
        [SerializeField] private BallMovement ball;
    
        public void TestMethod()
        {
            // write here anything you want to test
        }
    }
#endif
}