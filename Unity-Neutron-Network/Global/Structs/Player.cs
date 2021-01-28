﻿using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class Player : IEquatable<Player>, INotify, ISerializable, IEqualityComparer<Player>
{
    public int ID { get; set; }
    /// <summary>
    /// nickname of player.
    /// </summary>
    [ReadOnly] public string Nickname;
    /// <summary>
    /// current channel of player.
    /// </summary>
    [ReadOnly] public int currentChannel = -1;
    /// <summary>
    /// current room of player.
    /// </summary>
    [ReadOnly] public int currentRoom = -1;
    /// <summary>
    /// Check if player is a bot.
    /// </summary>
    [ReadOnly] public bool isBot;
    /// <summary>
    /// state of player;
    /// </summary>
    [NonSerialized] public ServerView serverView;
    /// <summary>
    /// Properties of channel.
    /// </summary>
    [SerializeField, TextArea, ReadOnly] private string properties = "{\"\":\"\"}";
    /// <summary>
    /// Properties of channel.
    /// </summary>
    [NonSerialized] public Dictionary<string, object> Properties;
    /// <summary>
    /// queue of data TCP.
    /// returns null on the client.
    /// not serialized over the network.
    /// </summary>
    [NonSerialized] public NeutronQueueData qDataTCP = new NeutronQueueData();
    /// <summary>
    /// queue of data UDP.
    /// returns null on the client.
    /// not serialized over the network.
    /// </summary>
    [NonSerialized] public NeutronQueueData qDataUDP = new NeutronQueueData();
    /// <summary>
    /// id of database.
    /// </summary>
    public int databaseID;
    /// <summary>
    /// Remote EndPoint of player.
    /// returns null on the client.
    /// not serialized over the network.
    /// </summary>
    [NonSerialized] public IPEndPoint rPEndPoint;
    /// <summary>
    /// Local EndPoint of player.
    /// returns null on the client.
    /// not serialized over the network.
    /// </summary>
    [NonSerialized] public IPEndPoint lPEndPoint;
    /// <summary>
    /// Socket.
    /// returns null on the client.
    /// not serialized over the network.
    /// </summary>
    [NonSerialized] public TcpClient tcpClient;
    /// <summary>
    /// Socket.
    /// returns null on the client.
    /// not serialized over the network.
    /// </summary>
    [NonSerialized] public UdpClient udpClient;
    /// <summary>
    /// Buffer of client.
    /// </summary>
    [NonSerialized] public TCPBuffer buffer = new TCPBuffer();

    public Player() { }// the default constructor is important for deserialization and serialization.(only if you implement the ISerializable interface or JSON.Net).

    public Player(int ID, TcpClient tcpClient)
    {
        this.ID = ID;
        this.Nickname = "Unknown";
        this.tcpClient = tcpClient;
        this.udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, Utils.GetFreePort(ProtocolType.Udp)));
        this.lPEndPoint = (IPEndPoint)udpClient.Client.LocalEndPoint;

        Utils.Logger(udpClient.Client.DontFragment);
        Utils.Logger(udpClient.DontFragment);
    }

    public Player(SerializationInfo info, StreamingContext context)
    {
        ID = (int)info.GetValue("ID", typeof(int));
        Nickname = (string)info.GetValue("Nickname", typeof(string));
        currentChannel = (int)info.GetValue("currentChannel", typeof(int));
        currentRoom = (int)info.GetValue("currentRoom", typeof(int));
        isBot = (bool)info.GetValue("isBot", typeof(bool));
        properties = (string)info.GetValue("properties", typeof(string));
        int code = Utils.ValidateAndDeserializeJson(properties, out Dictionary<string, object> _properties);
        switch (code)
        {
            case 1:
                Properties = _properties;
                break;
            case 2:
                Utils.LoggerError($"Properties is empty -> Player: [{ID}]");
                break;
            case 0:
                Utils.LoggerError($"Invalid JSON error -> Player: [{ID}]");
                break;
        }
    }

    public Boolean Equals(Player other)
    {
        return this.ID == other.ID;
    }

    public Boolean Equals(Player x, Player y)
    {
        if (object.ReferenceEquals(x, y))
        {
            return true;
        }
        if (object.ReferenceEquals(x, null) ||
            object.ReferenceEquals(y, null))
        {
            return false;
        }
        return x.ID == y.ID;
    }

    public Int32 GetHashCode(Player obj)
    {
        return obj.ID.GetHashCode();
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("ID", ID, typeof(int));
        info.AddValue("Nickname", Nickname, typeof(string));
        info.AddValue("currentChannel", currentChannel, typeof(int));
        info.AddValue("currentRoom", currentRoom, typeof(int));
        info.AddValue("isBot", isBot, typeof(bool));
        info.AddValue("properties", properties, typeof(string));
    }

    public void Dispose()
    {
        tcpClient.Close();
        udpClient.Close();
    }
}