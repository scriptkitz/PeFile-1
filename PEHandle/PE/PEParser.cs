using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace PEHandle
{
    public class PEParser
    {
        public string FilePath { get; set; }
        public PEParser(string filePath)
        {
            FilePath = filePath;
        }

        //private uint offset;

        public PEFile GetPEFile()
        {
            byte[] peBytes = File.ReadAllBytes(FilePath);
            //offset = 0;
            PEFile peFile = new PEFile();
            peFile.peBytes = peBytes;
            parseImageDosHeader(peBytes, peFile);       //DOS头
            //parseImageNtHeader(peBytes, peFile);        //NT 头
            //parseImageFileHeader(peBytes, peFile);      //文件头
            //parseImageOptionalHeader(peBytes, peFile);  //可选头
            //parseImageDataDirectory(peBytes, peFile);   //数据目录

            return peFile;
        }

        private void parseImageDosHeader(byte[] peBytes,PEFile peFile)
        {
            uint offset = 0;
            peFile.image_dos_header = new IMAGE_DOS_HEADER();

            offset = offset + 0x0;
            peFile.image_dos_header.e_magic = new Element();
            peFile.image_dos_header.e_magic.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_magic.Length = 2;
            peFile.image_dos_header.e_magic.Offset = offset;
            peFile.image_dos_header.e_magic.Format = ("X4");

            offset = offset + 0x2;
            peFile.image_dos_header.e_cblp = new Element();
            peFile.image_dos_header.e_cblp.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_cblp.Length = 2;
            peFile.image_dos_header.e_cblp.Offset = offset;
            peFile.image_dos_header.e_cblp.Format = ("X4");

            //peFile.image_dos_header.e_cp = peBytes.BytesToUInt16(offset + 0x04);
            offset = offset + 0x2;
            peFile.image_dos_header.e_cp = new Element();
            peFile.image_dos_header.e_cp.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_cp.Length = 2;
            peFile.image_dos_header.e_cp.Offset = offset;
            peFile.image_dos_header.e_cp.Format = ("X4");

            //peFile.image_dos_header.e_crlc = peBytes.BytesToUInt16(offset + 0x06);
            offset = offset + 0x2;
            peFile.image_dos_header.e_crlc = new Element();
            peFile.image_dos_header.e_crlc.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_crlc.Length = 2;
            peFile.image_dos_header.e_crlc.Offset = offset;
            peFile.image_dos_header.e_crlc.Format = ("X4");


            //peFile.image_dos_header.e_cparhdr = peBytes.BytesToUInt16(offset + 0x08);
            offset = offset + 0x2;
            peFile.image_dos_header.e_cparhdr = new Element();
            peFile.image_dos_header.e_cparhdr.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_cparhdr.Length = 2;
            peFile.image_dos_header.e_cparhdr.Offset = offset;
            peFile.image_dos_header.e_cparhdr.Format = ("X4");


            //peFile.image_dos_header.e_minalloc = peBytes.BytesToUInt16(offset + 0x0A);
            offset = offset + 0x2;
            peFile.image_dos_header.e_minalloc = new Element();
            peFile.image_dos_header.e_minalloc.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_minalloc.Length = 2;
            peFile.image_dos_header.e_minalloc.Offset = offset;
            peFile.image_dos_header.e_minalloc.Format = ("X4");

            //peFile.image_dos_header.e_maxalloc = peBytes.BytesToUInt16(offset + 0x0C);
            offset = offset + 0x2;
            peFile.image_dos_header.e_maxalloc = new Element();
            peFile.image_dos_header.e_maxalloc.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_maxalloc.Length = 2;
            peFile.image_dos_header.e_maxalloc.Offset = offset;
            peFile.image_dos_header.e_maxalloc.Format = ("X4");

            //peFile.image_dos_header.e_ss = peBytes.BytesToUInt16(offset + 0x0E);
            offset = offset + 0x2;
            peFile.image_dos_header.e_ss = new Element();
            peFile.image_dos_header.e_ss.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_ss.Length = 2;
            peFile.image_dos_header.e_ss.Offset = offset;
            peFile.image_dos_header.e_ss.Format = "X4";

            //peFile.image_dos_header.e_sp = peBytes.BytesToUInt16(offset + 0x10);
            offset = offset + 0x2;
            peFile.image_dos_header.e_sp = new Element();
            peFile.image_dos_header.e_sp.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_sp.Length = 2;
            peFile.image_dos_header.e_sp.Offset = offset;
            peFile.image_dos_header.e_sp.Format = "X4";

            //peFile.image_dos_header.e_csum = peBytes.BytesToUInt16(offset + 0x12);
            offset = offset + 0x2;
            peFile.image_dos_header.e_csum = new Element();
            peFile.image_dos_header.e_csum.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_csum.Length = 2;
            peFile.image_dos_header.e_csum.Offset = offset;
            peFile.image_dos_header.e_csum.Format = "X4";

            //peFile.image_dos_header.e_ip = peBytes.BytesToUInt16(offset + 0x14);
            offset = offset + 0x2;
            peFile.image_dos_header.e_ip = new Element();
            peFile.image_dos_header.e_ip.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_ip.Length = 2;
            peFile.image_dos_header.e_ip.Offset = offset;
            peFile.image_dos_header.e_ip.Format = "X4";

            //peFile.image_dos_header.e_cs = peBytes.BytesToUInt16(offset + 0x16);
            offset = offset + 0x2;
            peFile.image_dos_header.e_cs = new Element();
            peFile.image_dos_header.e_cs.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_cs.Length = 2;
            peFile.image_dos_header.e_cs.Offset = offset;
            peFile.image_dos_header.e_cs.Format = "X4";

            //peFile.image_dos_header.e_lfarlc = peBytes.BytesToUInt16(offset + 0x18);
            offset = offset + 0x2;
            peFile.image_dos_header.e_lfarlc = new Element();
            peFile.image_dos_header.e_lfarlc.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_lfarlc.Length = 2;
            peFile.image_dos_header.e_lfarlc.Offset = offset;
            peFile.image_dos_header.e_lfarlc.Format = "X4";

            //peFile.image_dos_header.e_ovno = peBytes.BytesToUInt16(offset + 0x1A);
            offset = offset + 0x2;
            peFile.image_dos_header.e_ovno = new Element();
            peFile.image_dos_header.e_ovno.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_ovno.Length = 2;
            peFile.image_dos_header.e_ovno.Offset = offset;
            peFile.image_dos_header.e_ovno.Format = "X4";

            //peFile.image_dos_header.e_res = new[] { 
            //    peBytes.BytesToUInt16(offset + 0x1C), 
            //    peBytes.BytesToUInt16(offset + 0x1E), 
            //    peBytes.BytesToUInt16(offset + 0x20), 
            //    peBytes.BytesToUInt16(offset + 0x22) 
            //};
            offset = offset + 0x2;
            peFile.image_dos_header.e_res = new Element();
            for (uint i = 0; i < 4; i++)
            {
                peFile.image_dos_header.e_res.Value += peBytes.BytesToUInt16(offset).ToString("X4");
                offset += 0x2;
            }
            peFile.image_dos_header.e_res.Length = 8;
            peFile.image_dos_header.e_res.Offset = offset;
            peFile.image_dos_header.e_res.Format = "X4";


            //peFile.image_dos_header.e_oemid = peBytes.BytesToUInt16(offset + 0x24);
            //offset = offset + 8;
            peFile.image_dos_header.e_oemid = new Element();
            peFile.image_dos_header.e_oemid.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_oemid.Length = 2;
            peFile.image_dos_header.e_oemid.Offset = offset;
            peFile.image_dos_header.e_oemid.Format = "X4";

            //peFile.image_dos_header.e_oeminfo = peBytes.BytesToUInt16(offset + 0x26);
            offset = offset + 0x2;
            peFile.image_dos_header.e_oeminfo = new Element();
            peFile.image_dos_header.e_oeminfo.Value = peBytes.BytesToUInt16(offset).ToString("X4");
            peFile.image_dos_header.e_oeminfo.Length = 2;
            peFile.image_dos_header.e_oeminfo.Offset = offset;
            peFile.image_dos_header.e_oeminfo.Format = "X4";

            //peFile.image_dos_header.e_res2 = new[] { 
            //    peBytes.BytesToUInt16(offset + 0x28), 
            //    peBytes.BytesToUInt16(offset + 0x2A), 
            //    peBytes.BytesToUInt16(offset + 0x2C), 
            //    peBytes.BytesToUInt16(offset + 0x2E),
            //    peBytes.BytesToUInt16(offset + 0x30),
            //    peBytes.BytesToUInt16(offset + 0x32),
            //    peBytes.BytesToUInt16(offset + 0x34),
            //    peBytes.BytesToUInt16(offset + 0x36),
            //    peBytes.BytesToUInt16(offset + 0x38),
            //    peBytes.BytesToUInt16(offset + 0x3A)
            //};
            offset = offset + 0x2;
            peFile.image_dos_header.e_res2 = new Element();
            for (uint i = 0; i < 10; i++)
            {
                peFile.image_dos_header.e_res2.Value += peBytes.BytesToUInt16(offset).ToString("X4");
                offset += 0x2;
            }
            peFile.image_dos_header.e_res2.Length = 20;
            peFile.image_dos_header.e_res2.Offset = offset;
            peFile.image_dos_header.e_res2.Format = "X40";

            //peFile.image_dos_header.e_lfanew = peBytes.BytesToUInt32(offset + 0x3C);
            //offset = offset + 20;
            peFile.image_dos_header.e_lfanew = new Element();
            peFile.image_dos_header.e_lfanew.Value = peBytes.BytesToUInt16(offset).ToString("X8");
            peFile.image_dos_header.e_lfanew.Length = 2;
            peFile.image_dos_header.e_lfanew.Offset = offset;
            peFile.image_dos_header.e_lfanew.Format = "X8";
        }

        private void parseImageNtHeader(byte[] peBytes,PEFile peFile)
        {
            peFile.image_nt_header = new IMAGE_NT_HEADER();
            peFile.image_nt_header.Signature = 0;// peBytes.BytesToUInt32(peFile.image_dos_header.e_lfanew);
        }

        private void parseImageFileHeader(byte[] peBytes, PEFile peFile)
        {
            IMAGE_FILE_HEADER temp = new IMAGE_FILE_HEADER();
            uint offset = 0;//peFile.image_dos_header.e_lfanew;
            temp.Machine = peBytes.BytesToUInt16(offset + 0x4);
            temp.NumberOfSections = peBytes.BytesToUInt16(offset + 0x6);
            temp.TimeDateStamp = peBytes.BytesToUInt32(offset + 0x8);
            temp.PointerToSymbolTable = peBytes.BytesToUInt32(offset + 0xC);
            temp.NumberOfSymbols = peBytes.BytesToUInt32(offset + 0x10);
            temp.SizeOfOptionalHeader = peBytes.BytesToUInt16(offset + 0x14);
            temp.Characteristics = peBytes.BytesToUInt16(offset + 0x16);
            peFile.image_nt_header.image_file_header = temp;
        }

        private void parseImageOptionalHeader(byte[] peBytes, PEFile peFile)
        {
            IMAGE_OPTIONAL_HEADER temp = new IMAGE_OPTIONAL_HEADER();
            uint offset = 0;// peFile.image_dos_header.e_lfanew;
            //temp
            temp.Magic = peBytes.BytesToUInt16(offset + 0x18);
            temp.MajorLinkerVersion = peBytes[offset + 0x1A];
            temp.MinorLinkerVersion = peBytes[offset + 0x1B];
            temp.SizeOfCode = peBytes.BytesToUInt32(offset + 0x1C);
            temp.SizeOfInitializedData = peBytes.BytesToUInt32(offset + 0x20);
            temp.SizeOfUninitializedData = peBytes.BytesToUInt32(offset + 0x24);
            temp.AddressOfEntryPoint = peBytes.BytesToUInt32(offset + 0x28);
            temp.BaseOfCode = peBytes.BytesToUInt32(offset + 0x2C);
            temp.BaseOfData = peBytes.BytesToUInt32(offset + 0x30);
            temp.ImageBase = peBytes.BytesToUInt32(offset + 0x34);
            temp.SectionAlignment = peBytes.BytesToUInt32(offset + 0x38);
            temp.FileAlignment = peBytes.BytesToUInt32(offset + 0x3C);
            temp.MajorOperatingSystemVersion = peBytes.BytesToUInt16(offset + 0x40);
            temp.MinorOperatingSystemVersion = peBytes.BytesToUInt16(offset + 0x42);
            temp.MajorImageVersion = peBytes.BytesToUInt16(offset + 0x44);
            temp.MinorImageVersion = peBytes.BytesToUInt16(offset + 0x46);
            temp.MajorSubsystemVersion = peBytes.BytesToUInt16(offset + 0x48);
            temp.MinorSubsystemVersion = peBytes.BytesToUInt16(offset + 0x4A);
            temp.Win32VersionValue = peBytes.BytesToUInt32(offset + 0x4C);
            temp.SizeOfImage = peBytes.BytesToUInt32(offset + 0x50);
            temp.SizeOfHeaders = peBytes.BytesToUInt32(offset + 0x54);
            temp.CheckSum = peBytes.BytesToUInt32(offset + 0x58);
            temp.Subsystem = peBytes.BytesToUInt16(offset + 0x5C);
            temp.DllCharacteristics = peBytes.BytesToUInt16(offset + 0x5E);
            temp.SizeOfStackReserve = peBytes.BytesToUInt32(offset + 0x60);
            temp.SizeOfStackCommit = peBytes.BytesToUInt32(offset + 0x64);
            temp.SizeOfHeapReserve = peBytes.BytesToUInt32(offset + 0x68);
            temp.SizeOfHeapCommit = peBytes.BytesToUInt32(offset + 0x6C);
            temp.LoaderFlags = peBytes.BytesToUInt32(offset + 0x70);
            temp.NumberOfRvaAndSizes = peBytes.BytesToUInt32(offset + 0x74);

            peFile.image_nt_header.image_optional_header = temp;
        }

        private void parseImageDataDirectory(byte[] peBytes,PEFile peFile)
        {
            IMAGE_DATA_DIRECTORY temp = new IMAGE_DATA_DIRECTORY();
            uint offset = 0;// peFile.image_dos_header.e_lfanew;

            temp.ExportDirectoryRVA = peBytes.BytesToUInt32(offset + 0x78);
            temp.ExportDirectorySize = peBytes.BytesToUInt32(offset+ 0x7C);

            temp.ImportDirectoryRVA = peBytes.BytesToUInt32(offset + 0x80);
            temp.ImportDirectorySize = peBytes.BytesToUInt32(offset + 0x84);

            temp.ResourceDirectoryRVA = peBytes.BytesToUInt32(offset + 0x88);
            temp.ResourceDirectorySize = peBytes.BytesToUInt32(offset + 0x8C);

            temp.ExceptionDirectoryRVA = peBytes.BytesToUInt32(offset + 0x90);
            temp.ExceptionDirectorySize = peBytes.BytesToUInt32(offset + 0x94);


            temp.SecurityDirectoryRVA = peBytes.BytesToUInt32(offset + 0x98);
            temp.SecurityDirectorySize = peBytes.BytesToUInt32(offset + 0x9C);

            temp.RelocationDirectoryRVA = peBytes.BytesToUInt32(offset + 0xA0);
            temp.RelocationDirectorySize = peBytes.BytesToUInt32(offset + 0xA4);

            temp.DebugDirectoryRVA = peBytes.BytesToUInt32(offset + 0xA8);
            temp.DebugDirectorySize = peBytes.BytesToUInt32(offset + 0xAC);

            temp.ArchitectureDirectoryRVA = peBytes.BytesToUInt32(offset + 0xB0);
            temp.ArchitectureDirectorySize = peBytes.BytesToUInt32(offset + 0xB4);

            temp.GlobalPtrDirectoryRVA = peBytes.BytesToUInt32(offset + 0xB8);
            temp.GlobalPtrDirectorySize = peBytes.BytesToUInt32(offset + 0xBC);

            temp.TLSDirectoryRVA = peBytes.BytesToUInt32(offset + 0xC0);
            temp.TLSDirectorySize = peBytes.BytesToUInt32(offset + 0xC4);

            temp.ConfigurationDirectoryRVA = peBytes.BytesToUInt32(offset + 0xC8);
            temp.ConfigurationDirectorySize = peBytes.BytesToUInt32(offset + 0xCC);

            temp.BoundImportDirectoryRVA = peBytes.BytesToUInt32(offset + 0xD0);
            temp.BoundImportDirectorySize = peBytes.BytesToUInt32(offset + 0xD4);

            temp.IATDirectoryRVA = peBytes.BytesToUInt32(offset + 0xD8);
            temp.IATDirectorySize = peBytes.BytesToUInt32(offset + 0xDC);

            temp.DelayDirectoryRVA = peBytes.BytesToUInt32(offset + 0xE0);
            temp.DelayDirectorySize = peBytes.BytesToUInt32(offset + 0xE4);

            temp.NetMetaDataDirectoryRVA = peBytes.BytesToUInt32(offset + 0xE8);
            temp.NetMetaDataDirectorySize = peBytes.BytesToUInt32(offset + 0xEC);

            temp.Reserved1 = peBytes.BytesToUInt32(offset + 0xF0);
            temp.Reserved2 = peBytes.BytesToUInt32(offset + 0xF4);

            peFile.image_data_directory = temp;
        }

        public bool IsPEFile(string filePath)
        {

            return false;
        }

        public void Save(string path)
        {

        }

        public void SaveAs(string path)
        {

        }

    }
}
