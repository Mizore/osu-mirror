using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beatmap_Mirror_WPF.Code.Tools
{
    public class ExtendedBinaryReader : BinaryReader
    {
        public ExtendedBinaryReader(Stream stream)
            : base(stream, Encoding.UTF8)
        {

        }

        public override string ReadString()
        {
            if (this.ReadByte() == 0)
                return null;

            return base.ReadString();
        }
    }
}
