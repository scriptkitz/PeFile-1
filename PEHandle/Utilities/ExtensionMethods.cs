using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEHandle
{
    public static class ExtensionMethods
    {

        /// <summary>
        ///     Convert to bytes to an 16 bit unsigned integer.
        ///     将两个字节转为16位无符号整数型
        /// </summary>
        /// <param name="b1">High byte.</param>
        /// <param name="b2">Low byte.</param>
        /// <returns>UInt16 of the input bytes.</returns>
        private static ushort BytesToUInt16(byte b1, byte b2)
        {
            return BitConverter.ToUInt16(new[] { b1, b2 }, 0);
        }

        /// <summary>
        ///     Convert a two bytes in a byte array to an 16 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Position of the high byte. Low byte is i+1.</param>
        /// <returns>UInt16 of the bytes in the buffer at position i and i+1.</returns>
        public static ushort BytesToUInt16(this byte[] buff, ulong offset)
        {
            return BytesToUInt16(buff[offset], buff[offset + 1]);
        }


        
        /// <summary>
        ///     Convert up to 2 bytes out of a buffer to an 16 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <param name="numOfBytes">Number of bytes to read.</param>
        /// <returns>UInt16 of numOfBytes bytes.</returns>
        public static uint BytesToUInt16(this byte[] buff, uint offset, uint numOfBytes)
        {
            var bytes = new byte[2];
            for (var i = 0; i < numOfBytes; i++)
                bytes[i] = buff[offset + i];

            return BitConverter.ToUInt16(bytes, 0);
        }

        /// <summary>
        ///     Convert 4 bytes to an 32 bit unsigned integer.
        /// </summary>
        /// <param name="b1">Highest byte.</param>
        /// <param name="b2">Second highest byte.</param>
        /// <param name="b3">Second lowest byte.</param>
        /// <param name="b4">Lowest byte.</param>
        /// <returns>UInt32 representation of the input bytes.</returns>
        private static uint BytesToUInt32(byte b1, byte b2, byte b3, byte b4)
        {
            return BitConverter.ToUInt32(new[] {b1, b2, b3, b4}, 0);
        }

        /// <summary>
        ///     Convert 4 consecutive bytes out of a buffer to an 32 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <returns>UInt32 of 4 bytes.</returns>
        public static uint BytesToUInt32(this byte[] buff, uint offset)
        {
            return BytesToUInt32(buff[offset], buff[offset + 1], buff[offset + 2], buff[offset + 3]);
        }

        /// <summary>
        ///     Convert up to 4 bytes out of a buffer to an 32 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <param name="numOfBytes">Number of bytes to read.</param>
        /// <returns>UInt32 of numOfBytes bytes.</returns>
        public static uint BytesToUInt32(this byte[] buff, uint offset, uint numOfBytes)
        {
            var bytes = new byte[4];
            for (var i = 0; i < numOfBytes; i++)
                bytes[i] = buff[offset + i];

            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        ///     Convert up to 4 bytes out of a buffer to an 32 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <param name="numOfBytes">Number of bytes to read.</param>
        /// <param name="count">Gets increased by numOfBytes.</param>
        /// <returns>UInt32 of numOfBytes bytes.</returns>
        public static uint BytesToUInt32(this byte[] buff, uint offset, uint numOfBytes, ref uint count)
        {
            var bytes = new byte[4];
            for (var i = 0; i < numOfBytes; i++)
                bytes[i] = buff[offset + i];

            count += numOfBytes;
            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        ///     Convert 4 bytes to an 32 bit signed integer.
        /// </summary>
        /// <param name="b1">Highest byte.</param>
        /// <param name="b2">Second highest byte.</param>
        /// <param name="b3">Second lowest byte.</param>
        /// <param name="b4">Lowest byte.</param>
        /// <returns>UInt32 representation of the input bytes.</returns>
        private static int BytesToInt32(byte b1, byte b2, byte b3, byte b4)
        {
            return BitConverter.ToInt32(new[] {b1, b2, b3, b4}, 0);
        }

        /// <summary>
        ///     Convert 4 consecutive bytes out of a buffer to an 32 bit signed integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <returns>UInt32 of 4 bytes.</returns>
        public static int BytesToInt32(this byte[] buff, uint offset)
        {
            return BytesToInt32(buff[offset], buff[offset + 1], buff[offset + 2], buff[offset + 3]);
        }

        /// <summary>
        ///     Convert up to 4 bytes out of a buffer to an 32 bit signed integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <param name="numOfBytes">Number of bytes to read.</param>
        /// <returns>UInt32 of numOfBytes bytes.</returns>
        public static int BytesToInt32(this byte[] buff, uint offset, uint numOfBytes)
        {
            var bytes = new byte[4];
            for (var i = 0; i < numOfBytes; i++)
                bytes[i] = buff[offset + i];

            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        ///     Convert up to 4 bytes out of a buffer to an 32 bit signed integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <param name="numOfBytes">Number of bytes to read.</param>
        /// <param name="count">Gets increased by numOfBytes.</param>
        /// <returns>UInt32 of numOfBytes bytes.</returns>
        public static int BytesToInt32(this byte[] buff, uint offset, uint numOfBytes, ref uint count)
        {
            var bytes = new byte[4];
            for (var i = 0; i < numOfBytes; i++)
                bytes[i] = buff[offset + i];

            count += numOfBytes;
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        ///     Converts 8 bytes to an 64 bit unsigned integer.
        /// </summary>
        /// <param name="b1">Highest byte.</param>
        /// <param name="b2">Second byte.</param>
        /// <param name="b3">Third byte.</param>
        /// <param name="b4">Fourth byte.</param>
        /// <param name="b5">Fifth byte.</param>
        /// <param name="b6">Sixth byte.</param>
        /// <param name="b7">Seventh byte.</param>
        /// <param name="b8">Lowest byte.</param>
        /// <returns>UInt64 of the input bytes.</returns>
        private static ulong BytesToUInt64(byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8)
        {
            return BitConverter.ToUInt64(new[] {b1, b2, b3, b4, b5, b6, b7, b8}, 0);
        }

        /// <summary>
        ///     Convert 8 consecutive byte in a buffer to an
        ///     64 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <returns>UInt64 of the byte sequence at offset i.</returns>
        public static ulong BytesToUInt64(this byte[] buff, ulong offset)
        {
            return BytesToUInt64(buff[offset], buff[offset + 1], buff[offset + 2], 
                buff[offset + 3], buff[offset + 4], buff[offset + 5], buff[offset + 6],
                buff[offset + 7]);
        }

        /// <summary>
        ///     Convert up to 8 bytes out of a buffer to an 64 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <param name="numOfBytes">Number of bytes to read.</param>
        /// <returns>UInt64 of numOfBytes bytes.</returns>
        public static ulong BytesToUInt64(this byte[] buff, uint offset, uint numOfBytes)
        {
            var bytes = new byte[8];
            for (var i = 0; i < numOfBytes; i++)
                bytes[i] = buff[offset + i];

            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <summary>
        ///     Convert an UIn16 to an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Two byte array of the input value.</returns>
        private static byte[] UInt16ToBytes(ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Set an UInt16 value at an offset in an byte array.
        /// </summary>
        /// <param name="buff">Buffer in which the value is set.</param>
        /// <param name="offset">Offset where the value is set.</param>
        /// <param name="value">The value to set.</param>
        public static void SetUInt16(this byte[] buff, ulong offset, ushort value)
        {
            var x = UInt16ToBytes(value);
            buff[offset] = x[0];
            buff[offset + 1] = x[1];
        }

        /// <summary>
        ///     Convert an UInt32 value into an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>4 byte array of the value.</returns>
        private static byte[] UInt32ToBytes(uint value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Convert an UIn64 value into an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>8 byte array of the value.</returns>
        private static byte[] UInt64ToBytes(ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Sets an UInt32 value at an offset in a buffer.
        /// </summary>
        /// <param name="buff">Buffer to set the value in.</param>
        /// <param name="offset">Offset in the array for the value.</param>
        /// <param name="value">Value to set.</param>
        public static void SetUInt32(this byte[] buff, uint offset, uint value)
        {
            var x = UInt32ToBytes(value);
            buff[offset] = x[0];
            buff[offset + 1] = x[1];
            buff[offset + 2] = x[2];
            buff[offset + 3] = x[3];
        }

        /// <summary>
        ///     Sets an UInt64 value at an offset in a buffer.
        /// </summary>
        /// <param name="buff">Buffer to set the value in.</param>
        /// <param name="offset">Offset in the array for the value.</param>
        /// <param name="value">Value to set.</param>
        public static void SetUInt64(this byte[] buff, ulong offset, ulong value)
        {
            var x = UInt64ToBytes(value);
            buff[offset] = x[0];
            buff[offset + 1] = x[1];
            buff[offset + 2] = x[2];
            buff[offset + 3] = x[3];
            buff[offset + 4] = x[4];
            buff[offset + 5] = x[5];
            buff[offset + 6] = x[6];
            buff[offset + 7] = x[7];
        }

        internal static ushort GetOrdinal(this byte[] buff, uint ordinal)
        {
            return BitConverter.ToUInt16(new[] {buff[ordinal], buff[ordinal + 1]}, 0);
        }

        /// <summary>
        ///     Get a name (C string) at a specific position in a buffer.
        /// </summary>
        /// <param name="buff">Containing buffer.</param>
        /// <param name="stringOffset">Offset of the string.</param>
        /// <returns>The parsed C string.</returns>
        public static string GetCString(this byte[] buff, ulong stringOffset)
        {
            var length = GetCStringLength(buff, stringOffset);
            var tmp = new char[length];
            for (ulong i = 0; i < length; i++)
            {
                tmp[i] = (char) buff[stringOffset + i];
            }

            return new string(tmp);
        }

        /// <summary>
        ///     For a given offset in an byte array, find the next
        ///     null value which terminates a C string.
        /// </summary>
        /// <param name="buff">Buffer which contains the string.</param>
        /// <param name="stringOffset">Offset of the string.</param>
        /// <returns>Length of the string in bytes.</returns>
        public static ulong GetCStringLength(this byte[] buff, ulong stringOffset)
        {
            var offset = stringOffset;
            ulong length = 0;
            while (buff[offset] != 0x00)
            {
                length++;
                offset++;
            }
            return length;
        }

        /// <summary>
        ///     Get a unicode string at a specific position in a buffer.
        /// </summary>
        /// <param name="buff">Containing buffer.</param>
        /// <param name="stringOffset">Offset of the string.</param>
        /// <param name="length">Lengh of the string to parse.</param>
        /// <returns>The parsed unicode string.</returns>
        public static string GetUnicodeString(this byte[] buff, ulong stringOffset, int length)
        {
            var bytes = new byte[length];
            Array.Copy(buff, (int)stringOffset, bytes, 0, length);
            return Encoding.Unicode.GetString(bytes);
        }

        /// <summary>
        /// Computes the number of bits needed by an MetaData Table index 
        /// based on the number of fields which the enum of the index has.
        /// </summary>
        /// <param name="indexEnum">MetaData tables index.</param>
        /// <returns>Size if index in bits.</returns>
        public static uint MetaDataTableIndexSize(this Type indexEnum)
        {
            var numOfTags = Enum.GetNames(indexEnum).Length;
            return (uint) Math.Ceiling(Math.Log(numOfTags, 2));
        }

  

    }
}
