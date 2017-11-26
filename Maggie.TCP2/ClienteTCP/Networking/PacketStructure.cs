﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteTCP.Networking
{
    public abstract class PacketStructure
    {
        byte[] _buffer;
        public PacketStructure(ushort lenght, ushort type)
        {
            _buffer = new byte[lenght];
            WriteUShort(lenght, 0);
            WriteUShort(type, 2);
        }
        public PacketStructure(byte[] packet)
        {
            _buffer = packet;
        }
        public void WriteUShort(ushort value, int offset)
        {
            byte[] tempBuf = new byte[2];
            tempBuf = BitConverter.GetBytes(value);
            Array.Copy(tempBuf, 0, _buffer, offset, 2);

            Buffer.BlockCopy(tempBuf, 0, _buffer, offset, 2);
        }
        public ushort ReadUShort(int offset)
        {
            return BitConverter.ToUInt16(_buffer, offset);
        }
        public void WriteUInt(uint value, int offset)
        {
            byte[] tempBuf = new byte[4];
            tempBuf = BitConverter.GetBytes(value);
            Buffer.BlockCopy(tempBuf, 0, _buffer, offset, 4);
        }
        public void WriteString(string value, int offset)
        {
            byte[] temBuf = new byte[value.Length];
            temBuf = Encoding.UTF8.GetBytes(value);
            Buffer.BlockCopy(temBuf, 0, _buffer, offset, value.Length);

        }
        public string ReadString(int offset, int count)
        {
            return Encoding.UTF8.GetString(_buffer, offset, count);
        }
        public byte[] Data { get { return _buffer; } }
    }
}
