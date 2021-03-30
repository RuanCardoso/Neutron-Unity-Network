﻿using System;

/// <summary>
/// <para>PT: Este atributo é usado para a comunicação entre servidor e clientes, este attributo só pode ser usado em objetos que possuem o componente NeutronView.</para>
/// <para>EN: This attribute is used for communication between server and clients, this attribute can only be used on objects that have the NeutronView component.</para>
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class Dynamic : Attribute
{
    public int ID;
    /// <summary>
    /// <para>PT: Marca o metódo com um ID, este ID será usado para invocar o metódo entre os clientes e servidor.</para>
    /// <para>EN: Marks the method with an ID, this ID will be used to invoke the method between the clients and the server.</para>
    /// </summary>
    /// <param name="ID">
    /// <para>PT: Este ID Deve ser exclusivo por classe, você pode ter uma Classe A e uma Classe B com o mesmo ID, mas não pode ter duas Classes A com o mesmo ID.</para><br/>
    /// <para>EN: This ID must be unique by class, you can have a Class A and a Class B with the same ID, but you cannot have two Classes A with the same ID.</para>
    /// </param>
    public Dynamic(int ID)
    {
        this.ID = ID;
    }
}