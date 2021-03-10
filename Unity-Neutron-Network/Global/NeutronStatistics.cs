﻿using System;
using System.Collections;
using System.Threading;
using NeutronNetwork.Internal;
using NeutronNetwork.Internal.Attributes;
using NeutronNetwork.Internal.Wrappers;
using UnityEngine;

public class NeutronStatistics : MonoBehaviour
{
    public static int clientBytesSent, clientBytesRec, serverBytesSent, serverBytesRec;
    [SerializeField] private float perSeconds = 1;

    [Header("Client Statistics")]
    [SerializeField] [ReadOnly] private string _BytesSent;
    [SerializeField] [ReadOnly] private string _BytesRec;

    [Header("Server Statistics")]
    [SerializeField] [ReadOnly] private string BytesSent;
    [SerializeField] [ReadOnly] private string BytesRec;

    private void Awake()
    {
#if UNITY_SERVER || UNITY_EDITOR
        StartCoroutine(UpdateStatistics());
#endif
    }

    private void Start()
    {
#if UNITY_SERVER || UNITY_EDITOR
        StartCoroutine(ClearStatistics());
#endif
    }

    private IEnumerator UpdateStatistics()
    {
        while (true)
        {
            _BytesSent = $"{Utils.SizeSuffix(clientBytesSent)} | [{Utils.SizeSuffixMB(clientBytesSent)}]";
            _BytesRec = $"{Utils.SizeSuffix(clientBytesRec)} | [{Utils.SizeSuffixMB(clientBytesRec)}]";
            BytesSent = $"{Utils.SizeSuffix(serverBytesSent)} | [{Utils.SizeSuffixMB(serverBytesSent)}]";
            BytesRec = $"{Utils.SizeSuffix(serverBytesRec)} | [{Utils.SizeSuffixMB(serverBytesRec)}]";
            yield return new WaitForSeconds(perSeconds);
        }
    }

    private IEnumerator ClearStatistics()
    {
        while (true)
        {
            Interlocked.Exchange(ref clientBytesSent, 0);
            Interlocked.Exchange(ref clientBytesRec, 0);
            Interlocked.Exchange(ref serverBytesSent, 0);
            Interlocked.Exchange(ref serverBytesRec, 0);
            yield return new WaitForSeconds(perSeconds);
        }
    }
}