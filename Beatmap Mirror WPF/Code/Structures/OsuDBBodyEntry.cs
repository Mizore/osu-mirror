using Beatmap_Mirror_WPF.Code.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beatmap_Mirror_WPF.Code.Structures
{
    public class OsuDBBodyEntry
    {
        public string Artist;
        public string ArtistUnicode;
        public string Title;
        public string TitleUnicode;

        public string Creator;
        public string Difficulty;
        public string AudioFile;
        public string MD5;
        public string Name;

        public MapStatus Status;

        public ushort Circles;
        public ushort Sliders;
        public ushort Spinners;

        public ulong LastEditTicks;

        public byte DiffApproachRate;
        public byte DiffCircleSize;
        public byte DiffHPDrainRate;
        public byte DiffOverallDiff;
        public double DiffSliderMulti;

        public int DrainingTime;
        public int TotalTime;
        public int PreviewTime;

        public int MapID;
        public int MapSetID;
        public int MapThreadID;
        public int MapRatings;
        public int MapOffset;
        public uint MapStackLeniency;
        public MapMode MapMode;
        public string MapSource;
        public string MapTags;
        public short MapAudioOffset;
        public string MapLetterbox;
        public bool MapPlayed;
        public ulong MapLastPlayedTicks;
        public bool MapIsOSZ2;
        public string MapDir;
        public ulong MapLastSyncTicks;
        public bool MapDisableHitsounds;
        public bool MapDisableSkin;
        public bool MapDisableSB;
        public bool MapPassed;
        public short MapBGDim;
    }
}
