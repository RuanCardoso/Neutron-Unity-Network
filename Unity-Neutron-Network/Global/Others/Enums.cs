﻿using System;

public enum SendTo {
    /// <summary>
    /// Broadcast data to all Players, including you.
    /// </summary>
    All,
    /// <summary>
    /// Broadcast data only you.
    /// </summary>
    Only,
    /// <summary>
    /// Broadcast data to all Players, except you.
    /// </summary>
    Others,
}

public enum Packet {
    Connected,
    DisconnectedByReason,
    Login,
    RPC,
    APC,
    RCC,
    ACC,
    JoinChannel,
    JoinRoom,
    LeaveRoom,
    LeaveChannel,
    CreateRoom,
    SendChat,
    SendInput,
    GetChannels,
    GetChached,
    GetRooms,
    Fail,
    DestroyPlayer,
    VoiceChat,
    Disconnected,
    SyncBehaviour,
    Database,
    Nickname,
    OnCustomPacket,
    ServerObjectInstantiate,
    StressTest,
    SetPlayerProperties,
    //======================================================
    // - CUSTOM PACKETS ADD HERE
    //======================================================
}

public enum CachedPacket {
    /// <summary>
    /// Used to instantiate other players on this client.
    /// </summary>
    RCC = 121,
    RPC = 122,
    APC = 123,
    ACC = 124,
    //======================================================
    // - CUSTOM PACKETS ADD HERE
    //======================================================
}

[Flags]
public enum WhenChanging {
    Position = 1,
    Rotation = 2,
    Velocity = 4,
}

public enum Compression {
    /// <summary>
    /// Compress data using deflate mode.
    /// </summary>
    Deflate,
    /// <summary>
    /// Compress data using GZip mode.
    /// </summary>
    GZip,
    /// <summary>
    /// Disable data compression.
    /// </summary>
    None,
}

public enum Broadcast {
    /// <summary>
    /// Broadcast data on the server.
    /// </summary>
    All,
    /// <summary>
    /// Broadcast data on the channel.
    /// </summary>
    Channel,
    /// <summary>
    /// Broadcast data on the room.
    /// </summary>
    Room,
    /// <summary>
    /// Broadcast data on the room, except for those in the lobby/waiting room.
    /// that is only for players who are instantiated and in the same room.
    /// </summary>
    Instantiated,
    /// <summary>
    /// Broadcast data on the same group.
    /// </summary>
    Group,
    /// <summary>
    /// None broadcast. Used to SendTo.Only.
    /// </summary>
    None,
}

public enum ClientType
{
    MainPlayer,
    Bot,
    VirtualPlayer,
}