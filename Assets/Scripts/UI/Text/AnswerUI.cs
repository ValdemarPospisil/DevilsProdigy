using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prodigy
{
    public class AnswerUI : MonoBehaviour
    {
        private void OnDisable() {
            Destroy(this.gameObject);
        }
    }
}
