using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEHandle
{
    public class PEFile
    {
        public byte[] peBytes { get; set; }
        public IMAGE_DOS_HEADER image_dos_header { get; set; }

        public IMAGE_NT_HEADER image_nt_header { get; set; }

        public IMAGE_DATA_DIRECTORY image_data_directory { get; set; }

    }



}
