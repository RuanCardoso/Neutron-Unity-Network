﻿using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NeutronNetwork
{
    public class NeutronNonDynamicBehaviour : MonoBehaviour
    {
        public static Dictionary<int, RemoteProceduralCall> NonDynamics = new Dictionary<int, RemoteProceduralCall>();

        private void OnEnable()
        {
            GetAttributes();
        }

        protected void NonDynamic(int nonDynamicID, bool isCached, bool isServer, NeutronWriter parameters, Player sender, SendTo sendTo, Broadcast broadcast, Protocol protocol, Neutron instance)
        {
            if (isServer)
                Neutron.Server.NonDynamic(sender, nonDynamicID, isCached, parameters, sendTo, broadcast, protocol);
            else instance.NonDynamic(nonDynamicID, parameters, isCached, sendTo, broadcast, protocol);
        }

        private void GetAttributes()
        {
            NeutronNonDynamicBehaviour mInstance = this;
            if (mInstance != null)
            {
                var mType = mInstance.GetType();
                MethodInfo[] mInfos = mType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                for (int y = 0; y < mInfos.Length; y++)
                {
                    NonDynamic NeutronNonDynamicAttr = mInfos[y].GetCustomAttribute<NonDynamic>();
                    if (NeutronNonDynamicAttr != null)
                    {
                        RemoteProceduralCall remoteProceduralCall = new RemoteProceduralCall(mInstance, mInfos[y]);
                        NonDynamics.Add(NeutronNonDynamicAttr.ID, remoteProceduralCall);
                    }
                    else continue;
                }
            }
        }
    }
}