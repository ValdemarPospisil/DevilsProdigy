using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prodigy
{
    public class ConfirmPopUpMenu : MonoBehaviour
    {
        [SerializeField] private Button cancelButton;

        private void OnEnable() {
            cancelButton.Select();
        }
    }

}
