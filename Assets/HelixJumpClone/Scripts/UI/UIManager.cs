using UnityEngine;

namespace HelixJump.UI
{
    public class UIManager : MonoBehaviour
    {
        #region Variables
        public delegate void PanelActive();
        public PanelActive FailedPanelActive;
        public PanelActive FinishPanelActive;

        [SerializeField] private GameObject[] _panels;
        private const byte FAILED = 0, FINISH = 1;
        #endregion

        private void Awake()
        {
            FailedPanelActive += FailedPanel;
            FinishPanelActive += FinishPanel;
        }

        private void FailedPanel()
        {
            _panels[FAILED].SetActive(true);
        }
        private void FinishPanel()
        {
            _panels[FINISH].SetActive(true);
        }
    }
}