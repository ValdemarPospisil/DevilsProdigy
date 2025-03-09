using System;
using UnityEngine;

namespace Prodigy.EventChannels
{
    [CreateAssetMenu(fileName = "newTriggerChannel", menuName = "Event Channels/Trigger")]
    public class TriggerEventChannel : EventChannelsSO<EventArgs>
    {
    }
}