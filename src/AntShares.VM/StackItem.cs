﻿using AntShares.VM.Types;
using System;
using System.Linq;
using System.Numerics;
using Array = AntShares.VM.Types.Array;
using Boolean = AntShares.VM.Types.Boolean;

namespace AntShares.VM
{
    public abstract class StackItem : IEquatable<StackItem>
    {
        public virtual bool IsArray => false;

        public abstract bool Equals(StackItem other);

        public static StackItem FromInterface(IInteropInterface value)
        {
            return new InteropInterface(value);
        }

        public virtual StackItem[] GetArray()
        {
            throw new NotSupportedException();
        }

        public virtual BigInteger GetBigInteger()
        {
            return new BigInteger(GetByteArray());
        }

        public virtual bool GetBoolean()
        {
            return GetByteArray().Any(p => p != 0);
        }

        public abstract byte[] GetByteArray();

        public virtual T GetInterface<T>() where T : class, IInteropInterface
        {
            throw new NotSupportedException();
        }

        public static implicit operator StackItem(int value)
        {
            return (BigInteger)value;
        }

        public static implicit operator StackItem(uint value)
        {
            return (BigInteger)value;
        }

        public static implicit operator StackItem(long value)
        {
            return (BigInteger)value;
        }

        public static implicit operator StackItem(ulong value)
        {
            return (BigInteger)value;
        }

        public static implicit operator StackItem(BigInteger value)
        {
            return new Integer(value);
        }

        public static implicit operator StackItem(bool value)
        {
            return new Boolean(value);
        }

        public static implicit operator StackItem(byte[] value)
        {
            return new ByteArray(value);
        }

        public static implicit operator StackItem(StackItem[] value)
        {
            return new Array(value);
        }
    }
}
