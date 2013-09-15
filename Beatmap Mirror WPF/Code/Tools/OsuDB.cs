using Beatmap_Mirror_WPF.Code.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beatmap_Mirror_WPF.Code.Tools
{
    public enum MapStatus : byte
    {
        Unknown1 = 0x00,
        Unknown2 = 0x01,
        Pending = 0x02,
        Unknown3 = 0x03,
        Ranked = 0x04,
        Approved = 0x05
    }

    public enum MapMode : byte
    {
        Osu = 0x00,
        Taiko = 0x02,
        CatchTheBeat = 0x03,
        OsuMania = 0x04,

        Unknown1 = 0x05,
        Unknown2 = 0x06
    }


    public class OsuDB
    {
        private ExtendedBinaryReader reader;
        private string file;

        public OsuDBData Data = new OsuDBData();

        public OsuDB(string file)
        {
            this.file = file;
            this.reader = new ExtendedBinaryReader(new FileStream(this.file, FileMode.Open, FileAccess.Read));

            this.Read();
        }

        public void Read()
        {
            this.ReadHeader();
            this.ReadBody();
        }

        private void ReadHeader()
        {
            this.Data.Header.UpdateDate = this.reader.ReadInt32();
            this.Data.Header.BeatmapSetCount = this.reader.ReadInt32();
            this.Data.Header._somebool = this.reader.ReadBoolean();
            this.Data.Header.DateTimeTicks = this.reader.ReadUInt64();
            this.Data.Header.UserName = this.reader.ReadString();
            this.Data.Header.BeatmapCount = this.reader.ReadInt32();
        }

        private void ReadBody()
        {
            if (this.Data.Header.BeatmapSetCount == 0)
                throw new Exception("No beatmaps found in database.");

            for (int i = 0; i < this.Data.Header.BeatmapSetCount; i++)
            {
                OsuDBBodyEntry ent = new OsuDBBodyEntry();
                ent.Artist = this.reader.ReadString();
                ent.ArtistUnicode = this.reader.ReadString();
                ent.Title = this.reader.ReadString();
                ent.TitleUnicode = this.reader.ReadString();

                ent.Creator = this.reader.ReadString();
                ent.Difficulty = this.reader.ReadString();
                ent.AudioFile = this.reader.ReadString();
                ent.MD5 = this.reader.ReadString();
                ent.Name = this.reader.ReadString();

                ent.Status = (MapStatus)this.reader.ReadByte();

                ent.Circles = this.reader.ReadUInt16();
                ent.Sliders = this.reader.ReadUInt16();
                ent.Spinners = this.reader.ReadUInt16();

                ent.LastEditTicks = this.reader.ReadUInt64();

                ent.DiffApproachRate = this.reader.ReadByte();
                ent.DiffCircleSize = this.reader.ReadByte();
                ent.DiffHPDrainRate = this.reader.ReadByte();
                ent.DiffOverallDiff = this.reader.ReadByte();
                ent.DiffSliderMulti = this.reader.ReadDouble();

                
                ent.DrainingTime = this.reader.ReadInt32();
                ent.TotalTime = this.reader.ReadInt32();
                ent.PreviewTime = this.reader.ReadInt32();

                this.reader.ReadBytes(17 * this.reader.ReadInt32()); // 2 doubles, 1 bool

                ent.MapID = this.reader.ReadInt32();
                ent.MapSetID = this.reader.ReadInt32();
                ent.MapThreadID = this.reader.ReadInt32();
                ent.MapRatings = this.reader.ReadInt32();
                ent.MapOffset = this.reader.ReadInt16();
                ent.MapStackLeniency = this.reader.ReadUInt32();
                ent.MapMode = (MapMode)this.reader.ReadByte();

                ent.MapSource = this.reader.ReadString();
                ent.MapTags = this.reader.ReadString();
                ent.MapAudioOffset = this.reader.ReadInt16();       //skipBytes(2) 'Unknowns //             this.int_11 = class31_0.ReadInt16();
                ent.MapLetterbox = this.reader.ReadString();
                ent.MapPlayed = !this.reader.ReadBoolean();
                ent.MapLastPlayedTicks = this.reader.ReadUInt64();
                ent.MapIsOSZ2 = this.reader.ReadBoolean();          //skipBytes(1) 'Unknown //             this.bool_9 = class31_0.ReadBoolean();
                ent.MapDir = this.reader.ReadString();
                ent.MapLastSyncTicks = this.reader.ReadUInt64();
                ent.MapDisableHitsounds = this.reader.ReadBoolean();
                ent.MapDisableSkin = this.reader.ReadBoolean();
                ent.MapDisableSB = this.reader.ReadBoolean();

                this.reader.ReadBytes(9);

                //ent.MapPassed = this.reader.ReadBoolean();
                    //skipBytes(1) 'Unknown
                    /*
                        if (Class414.int_0 >= 0x1332b40) loks like date: 2013/06/24
                            this.bool_23 = class31_0.ReadBoolean();
                     
                        if (Class414.int_0 >= 0x1332c61) looks like date: 2013/09/13
                            this.bool_24 = class31_0.ReadBoolean();
                        else
                            this.bool_24 = ((this.bool_23 || this.bool_22) || this.bool_21) || (this.int_18 != 30);
                    */

                //ent.MapBGDim = this.reader.ReadInt16();
                //this.reader.ReadInt32();
                //this.reader.ReadBoolean();
                    //skipBytes(3) 'Unknowns ;--; 

                this.Data.Body.Data.Add(ent);
            }
        }
    }
}
