﻿using NeutronNetwork.Internal.Attributes;
using System;
using System.ComponentModel;

#region Byte

[Network]
public enum ClientPacket : byte
{
    [Obsolete("Do not use this packet, it is only for testing (:")] CustomTest,
}

[Network]
public enum SendTo : byte
{
    /// <summary>
    /// Broadcast data to all Players, including you.
    /// </summary>
    All,
    /// <summary>
    /// Broadcast data only you.
    /// </summary>
    Me,
    /// <summary>
    /// Broadcast data to all Players, except you.
    /// </summary>
    Others,
    /// <summary>
    /// Broadcast data to server.
    /// </summary>
    Server,
}

[Network]
public enum SystemPacket : byte
{
    Handshake,
    NewPlayer,
    Disconnection,
    iRPC,
    gRPC,
    JoinChannel,
    JoinRoom,
    Leave,
    CreateRoom,
    Chat,
    GetChannels,
    GetChached,
    GetRooms,
    Fail,
    DestroyPlayer,
    Nickname,
    SetPlayerProperties,
    SetRoomProperties,
    Heartbeat,
    ClientPacket,
    SerializeView,
}

[Network]
public enum MatchmakingPacket : byte
{
    Room,
    Channel,
    Group
}

[Network]
public enum ChatPacket : byte
{
    Global,
    Private,
}

[Network]
public enum CachedPacket : byte
{
    gRPC = 121,
    iRPC = 122,
}

[Network]
public enum Broadcast : byte
{
    /// <summary>
    /// None broadcast. Used to SendTo.Only.
    /// </summary>
    Me,
    /// <summary>
    /// Broadcast data on the server.
    /// </summary>
    Server,
    /// <summary>
    /// Broadcast data on the channel.
    /// </summary>
    Channel,
    /// <summary>
    /// Broadcast data on the room.
    /// </summary>
    Room,
    /// <summary>
    /// Broadcast data on the same group.
    /// </summary>
    Group,
    /// <summary>
    /// Broadcast data on the same room or channel.
    /// </summary>
    Auto,
    //======================================================
    // - CUSTOM PACKETS ADD HERE.
    //======================================================
    [Obsolete("Do not use this packet, it is only for testing (:")] CustomTest,
}

[Network]
public enum Protocol : byte
{
    Tcp = 6,
    Udp = 17,
}

[Network]
public enum CacheMode : byte
{
    None, Overwrite, Append
}
#endregion

#region Int

public enum Compression : int
{
    /// <summary>
    /// Disable data compression.
    /// </summary>
    None,
    /// <summary>
    /// Compress data using deflate mode.
    /// </summary>
    Deflate,
    /// <summary>
    /// Compress data using GZip mode.
    /// </summary>
    Gzip,
}

public enum ClientType : int
{
    MainPlayer,
    VirtualPlayer,
}

public enum Serialization : int
{
    BinaryFormatter,
    Json,
}

public enum Statistics : int
{
    ClientSent,
    ClientRec,
    ServerSent,
    ServerRec
}

public enum AuthorityMode : int
{
    Server,
    Owner,
    OwnerAndServer,
    MasterClient,
    IgnoreExceptServer,
    Ignore,
}

[Flags]
public enum ComponentMode : int
{
    IsMine = 2, IsServer = 4
}
public enum SmoothMode : int
{
    Lerp,
    MoveTowards,
    SmoothDamp,
}
public enum ParameterMode : int
{
    Sync,
    NonSync
}
public enum Ambient : int
{
    Server,
    Client,
    Both
}

#endregion