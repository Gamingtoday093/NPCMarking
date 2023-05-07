using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NPCMarking.Services
{
    public static class FlagConvertor
    {
        public static float LevelSize { get; } = (float)(Level.size - (Level.border * 2)) / 2f;

        public static void ToSignedBytes(short Value, out sbyte ByteX, out sbyte ByteY)
        {
            ByteX = (sbyte)((Value & 0x00FF));
            ByteY = (sbyte)((Value & 0xFF00) >> 8);
        }

        public static short ToFlagValue(sbyte ByteX, sbyte ByteY)
        {
            return (short)((byte)ByteX | ((byte)ByteY << 8));
        }

        public static Vector3 GetLocation(short Value)
        {
            ToSignedBytes(Value, out sbyte ByteX, out sbyte ByteY);
            return new Vector3(((float)LevelSize / (float)sbyte.MaxValue) * (float)ByteX, 0f, ((float)LevelSize / (float)sbyte.MaxValue) * (float)ByteY);
        }

        public static short GetClosestValueFromPosition(Vector3 Position)
        {
            sbyte ByteX = (sbyte)(Position.x / ((float)LevelSize / (float)sbyte.MaxValue));
            sbyte ByteY = (sbyte)(Position.z / ((float)LevelSize / (float)sbyte.MaxValue));

            return ToFlagValue(ByteX, ByteY);
        }
    }
}
