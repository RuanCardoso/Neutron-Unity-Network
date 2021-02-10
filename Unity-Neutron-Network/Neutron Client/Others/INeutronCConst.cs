﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace NeutronNetwork.Internal.Client
{
    public class NeutronCConst : MonoBehaviour
    {   // It inherits from MonoBehaviour because it is an instance of GameObject.
        protected Compression COMPRESSION_MODE = Compression.None; // OBS: Compression.None change to BUFFER_SIZE in StateObject to 4092 or 9192.
        //-------------------------------------------------------------------------------------------------------------
        public ConcurrentQueue<Action> mainThreadActions;
        public ConcurrentQueue<Action> monoBehaviourRPCActions;
        //-------------------------------------------------------------------------------------------------------------
        protected TcpClient _TCPSocket;
        protected UdpClient _UDPSocket;
        //-------------------------------------------------------------------------------------------------------------
        protected float tInputDelay = 0f;
        protected float tNetworkStatsDelay = 0f;
        //-------------------------------------------------------------------------------------------------------------
        public const float navMeshTolerance = 15f;
        //-------------------------------------------------------------------------------------------------------------
        protected long ping = 0;
        protected double packetLoss = 0;
        protected int pingAmount = 0;
        //-------------------------------------------------------------------------------------------------------------
        protected Dictionary<int, float> timeRPC;
        //-------------------------------------------------------------------------------------------------------------
        public ConcurrentDictionary<int, NeutronView> playersObjects;
        public ConcurrentDictionary<int, object[]> properties;
        //-------------------------------------------------------------------------------------------------------------
        protected IPEndPoint endPointUDP;

        protected IData IData;

        public void Internal()
        {
            mainThreadActions = new ConcurrentQueue<Action>();
            monoBehaviourRPCActions = new ConcurrentQueue<Action>();
            //-------------------------------------------------------------------------------------------------------------
            _TCPSocket = new TcpClient(new IPEndPoint(IPAddress.Any, Utils.GetFreePort(Protocol.Tcp)));
            _UDPSocket = new UdpClient(new IPEndPoint(IPAddress.Any, Utils.GetFreePort(Protocol.Udp)));
            //-------------------------------------------------------------------------------------------------------------
            timeRPC = new Dictionary<int, float>();
            //-------------------------------------------------------------------------------------------------------------
            playersObjects = new ConcurrentDictionary<int, NeutronView>();
            properties = new ConcurrentDictionary<int, object[]>();
        }

        public void Dispose()
        {
            _TCPSocket.Close();
            _UDPSocket.Close();
        }

        private void OnApplicationQuit()
        {
            Dispose();
        }
    }
}