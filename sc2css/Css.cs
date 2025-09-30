using System.Collections.Generic;
using System.IO;

namespace sc2css;

internal class Css
{
    public enum Console : byte
    {
        GC,
        XBOX,
        PS2,
        X360,
        PS3,
    }

    public enum Human
    {
        Dummy = 0,
        Mitsurugi = 1,
        SeungMina = 2,
        Taki = 3,
        Maxi = 4,
        Voldo = 5,
        Sophitia = 6,
        Dummy2 = 7,
        Dummy3 = 8,
        Dummy4 = 9,
        Dummy5 = 10,
        Ivy = 11,
        Kilik = 12,
        Xianghua = 13,
        Dummy6 = 14,
        Yoshimitsu = 15,
        Dummy7 = 16,
        Nightmare = 17,
        Astaroth = 18,
        Inferno = 19,
        Cervantes = 20,
        Raphael = 21,
        Talim = 22,
        Cassandra = 23,
        Charade = 24,
        Necrid = 25,
        YunSeong = 26,
        Link = 27,
        Heihachi = 28,
        Spawn = 29,
        LizardMan = 30,
        Assassin = 31,
        Berserker = 32,
        Null = -1,
        Random = -2
    }

    public class Entry
    {
        public Human HumanIdx { get; set; }

        public ushort CostumeCount { get; set; }

        public uint Unk1 { get; set; }

        public byte[] CostumeIcon { get; set; }

        public byte[] BgIcon { get; set; }

        public uint Unk2 { get; set; }

        public uint Unk3 { get; set; }

        public ushort Unk4 { get; set; }

        public ushort Unk5 { get; set; }

        public Entry()
        {
            HumanIdx = Human.Dummy;
            CostumeCount = 0;
            Unk1 = 0u;
            CostumeIcon = new byte[8];
            BgIcon = new byte[8];
            Unk2 = 0u;
            Unk3 = 0u;
            Unk4 = 0;
            Unk5 = 0;
        }

        public Entry(Entry entry)
        {
            HumanIdx = entry.HumanIdx;
            CostumeCount = entry.CostumeCount;
            Unk1 = entry.Unk1;
            CostumeIcon = entry.CostumeIcon;
            BgIcon = entry.BgIcon;
            Unk2 = entry.Unk2;
            Unk3 = entry.Unk3;
            Unk4 = entry.Unk4;
            Unk5 = entry.Unk5;
        }

        public Entry(BinaryReader br)
        {
            HumanIdx = (Human)Helper.readInt16(br, endian);
            CostumeCount = Helper.readUInt16(br, endian);
            Unk1 = Helper.readUInt32(br, endian);
            CostumeIcon = br.ReadBytes(8);
            BgIcon = br.ReadBytes(8);
            Unk2 = Helper.readUInt32(br, endian);
            Unk3 = Helper.readUInt32(br, endian);
            Unk4 = Helper.readUInt16(br, endian);
            Unk5 = Helper.readUInt16(br, endian);
        }
    }

    public static string filePath;

    public static Helper.Endian endian = Helper.Endian.Big;

    public static Console console = Console.GC;

    public static int tableOffset;

    public static int charInfoOffset;

    public static int xPosOff;

    public static int cssIdxOff;

    public static int wmTableOffset;

    public static List<short> characterEntryCostumes = new List<short>();

    public static List<byte> cssIdx = new List<byte>();

    public static List<short> wmEntries = new List<short>();

    public static void EndianSet(Console c)
    {
        switch (c)
        {
            case Console.GC:
            case Console.X360:
            case Console.PS3:
                endian = Helper.Endian.Big;
                break;
            case Console.XBOX:
            case Console.PS2:
                endian = Helper.Endian.Little;
                break;
        }
    }

    public static void GetConsoleOffsets(Console c)
    {
        switch (c)
        {
            case Console.GC:
                tableOffset = 2413856;
                charInfoOffset = 2566752;
                xPosOff = 2839580;
                cssIdxOff = 2414936;
                wmTableOffset = 2664308;
                break;
            case Console.XBOX:
                tableOffset = 1496688;
                charInfoOffset = 1642488;
                xPosOff = 1483772;
                cssIdxOff = 1497768;
                wmTableOffset = 3539024;
                break;
            case Console.PS2:
                tableOffset = 3737944;
                charInfoOffset = 3128248;
                xPosOff = 0;
                cssIdxOff = 3739024;
                wmTableOffset = 3463696;
                break;
            case Console.X360:
                tableOffset = 51024;
                charInfoOffset = 5356440;
                xPosOff = 36644;
                cssIdxOff = 52104;
                wmTableOffset = 5353848;
                break;
            case Console.PS3:
                tableOffset = 4466408;
                charInfoOffset = 4908628;
                xPosOff = 0;
                cssIdxOff = 4036416;
                wmTableOffset = 4772656;
                break;
        }
    }

    public static void GetPracticeOffsets()
    {
        tableOffset = 2421140;
        charInfoOffset = 2574036;
        xPosOff = 2846864;
        cssIdxOff = 2422220;
        wmTableOffset = 2671592;
    }
}
