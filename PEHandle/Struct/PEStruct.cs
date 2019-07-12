using System;
using System.Drawing;

namespace PEHandle
{
    public class Element
    {
        public string Value { get; set; }
        public ushort Length { get; set; }
        public uint Offset { get; set; }
        public string Format { get; set; }
    }

    public class IMAGE_DOS_HEADER
    {
        [Description("EXE标志:'MZ'", "X4", RGBA = -65536)]
        public Element e_magic { get; set; }

        [Description("最后（部分）页中的字节数","X4")]
        public Element e_cblp { get; set; }

        [Description("文件中的全部和部分分页数","X4")]
        public Element e_cp { get; set; }
        /// <summary>
        ///     Relocations.
        /// </summary>
        [Description("重定位表中的指针数","X4")]
        public Element e_crlc { get; set; }
        /// <summary>
        ///     Size of the header in paragraphs.
        /// </summary>
        [Description("头部尺寸，以段落为单位","X4")]
        public Element e_cparhdr { get; set; }
        /// <summary>
        ///     Minimum extra paragraphs needed.
        /// </summary>
        [Description("所需的最小附加段","X4")]
        public Element e_minalloc { get; set; }
        /// <summary>
        ///     Maximum extra paragraphs needed.
        /// </summary>
        [Description("所需最大附加段", "X4")]
        public Element e_maxalloc { get; set; }
        /// <summary>
        ///     Initial (relative) SS value.
        /// </summary>
        [Description("初始的SS值", "X4")]
        public Element e_ss { get; set; }
        /// <summary>
        ///     Initial SP value.
        /// </summary>
        [Description("初始的SP的值", "X4")]
        public Element e_sp { get; set; }
        /// <summary>
        ///     Checksum
        /// </summary>
        [Description("补码校验值", "X4")]
        public Element e_csum { get; set; }
        /// <summary>
        ///     Initial IP value.
        /// </summary>
        [Description("初始的IP值", "X4")]
        public Element e_ip { get; set; }
        
        /// <summary>
        ///     Initial (relative) CS value.
        /// </summary>
        [Description("初始的CS值", "X4")]
        public Element e_cs { get; set; }
        /// <summary>
        ///     Raw address of the relocation table.
        /// </summary>
        [Description("重定位表的字节偏移量", "X4")]
        public Element e_lfarlc { get; set; }
        /// <summary>
        ///     Overlay number.
        /// </summary>
        [Description("覆盖号", "X4")]
        public Element e_ovno { get; set; }
        /// <summary>
        ///     Reserved.
        /// </summary>
        [Description("保留字", "X4")]
        public Element e_res { get; set; }
        /// <summary>
        ///     OEM identifier.
        /// </summary>
        [Description("OEM标识符", "X4")]
        public Element e_oemid { get; set; }

        /// <summary>
        ///     OEM information.
        /// </summary>
        [Description("OEM信息", "X4")]
        public Element e_oeminfo { get; set; }
        /// <summary>
        ///     Reserved.
        /// </summary>
        [Description("保留字", "X4")]
        public Element e_res2 // 10 * UInt16
        { 
            get; set;
        }
        /// <summary>
        ///     Raw address of the NT header.
        /// </summary>
        [Description("PE头相对于文件的偏移地址", "X8")]
        public Element e_lfanew { get; set; }
    }

    public class IMAGE_NT_HEADER
    {
        [Description("PE标志", "X4")]
        public uint Signature { get; set; }

        [Description("文件头", "")]
        public IMAGE_FILE_HEADER image_file_header { get; set; }

        [Description("可选头", "")]
        public IMAGE_OPTIONAL_HEADER image_optional_header { get; set; }
    }

    public class IMAGE_FILE_HEADER
    {

        [Description("运行平台","X4")]
        public ushort Machine { get; set; }


        [Description("PE中节的数量","X4")]
        public ushort NumberOfSections { get; set; }

        [Description("文件创建的日期和时间","X8")]
        public uint TimeDateStamp { get; set; }
        
        [Description("PE指向符号表（用于调试）","X8")]
        public uint PointerToSymbolTable { get; set; }

        [Description("符号表中的符号数量（用于调试）","X8")]
        public uint NumberOfSymbols { get; set; }

        [Description("扩展头结构的长度","X4")]
        public ushort SizeOfOptionalHeader { get; set; }

        [Description("文件属性","X4")]
        public ushort Characteristics { get; set; }

    }

    public class IMAGE_OPTIONAL_HEADER
    {
        [Description("魔术字", "X4")]
        public ushort Magic { get; set; }

        [Description("连接器版本号", "X2")]
        public byte MajorLinkerVersion { get; set; }

        [Description("", "X2")]
        public byte MinorLinkerVersion { get; set; }

        [Description("所有含代码的节的总大小", "X8")]
        public uint SizeOfCode { get; set; }
        [Description("所有含已初始化数据的节的总大小", "X8")]
        public uint SizeOfInitializedData { get; set; }
        [Description("所有含未初始化数据的节的大小", "X8")]
        public uint SizeOfUninitializedData { get; set; }

        [Description("程序执行入口RVA", "X8")]
        public uint AddressOfEntryPoint { get; set; }

        [Description("代码的节的起始RVA", "X8")]
        public uint BaseOfCode { get; set; }

        [Description("数据的节的起始RVA", "X8")]
        public uint BaseOfData { get; set; }

        [Description("程序的建议装载地址", "X8")]
        public uint ImageBase { get; set; }

        [Description("内存中的节的对齐粒度", "X8")]
        public uint SectionAlignment { get; set; }

        [Description("文件中的节的对齐粒度", "X8")]
        public uint FileAlignment { get; set; }

        [Description("操作系统版本号", "X4")]
        public ushort MajorOperatingSystemVersion { get; set; }

        [Description("", "X4")]
        public ushort MinorOperatingSystemVersion { get; set; }

        [Description("该PE的版本号", "X4")]
        public ushort MajorImageVersion { get; set; }

        [Description("该PE", "X4")]
        public ushort MinorImageVersion { get; set; }

        [Description("所需子系统的版本号", "X4")]
        public ushort MajorSubsystemVersion { get; set; }

        [Description("", "X4")]
        public ushort MinorSubsystemVersion { get; set; }

        [Description("", "X8")]
        public uint Win32VersionValue { get; set; }

        [Description("内存中的整个PE映像尺寸", "X8")]
        public uint SizeOfImage { get; set; }

        [Description("所有头+节表的大小", "X8")]
        public uint SizeOfHeaders { get; set; }
        [Description("校验和", "X8")]
        public uint CheckSum { get; set; }
        [Description("文件的子系统", "X4")]
        public ushort Subsystem { get; set; }
        [Description("DLL文件特效", "X4")]
        public ushort DllCharacteristics { get; set; }

        [Description("初始化时的栈大小", "X8")]
        public ulong SizeOfStackReserve { get; set; }

        [Description("初始化时实际提交的栈大小", "X8")]
        public ulong SizeOfStackCommit { get; set; }

        [Description("初始化时保留的堆大小", "X8")]
        public ulong SizeOfHeapReserve { get; set; }

        [Description("初始化时实际提交的堆大小", "X8")]
        public ulong SizeOfHeapCommit { get; set; }
        [Description("与调试有关", "X8")]
        public uint LoaderFlags { get; set; }
        [Description("下面数据目录的项目数量", "X8")]
        public uint NumberOfRvaAndSizes { get; set; }
    }

    public class IMAGE_DATA_DIRECTORY
    {
        [Description("导出表RVA", "X8")]
        public uint ExportDirectoryRVA { get; set; }

        [Description("导出表大小", "X8")]
        public uint ExportDirectorySize { get; set; }
        [Description("导入表RVA", "X8")]
        public uint ImportDirectoryRVA { get; set; }
        [Description("导入表大小", "X8")]
        public uint ImportDirectorySize { get; set; }
        [Description("资源表RVA", "X8")]
        public uint ResourceDirectoryRVA { get; set; }
        [Description("资源表大小", "X8")]
        public uint ResourceDirectorySize { get; set; }
        [Description("异常表RVA", "X8")]
        public uint ExceptionDirectoryRVA { get; set; }
        [Description("异常表大小", "X8")]
        public uint ExceptionDirectorySize { get; set; }
        [Description("安全表RVA", "X8")]
        public uint SecurityDirectoryRVA { get; set; }
        [Description("安全表大小", "X8")]
        public uint SecurityDirectorySize { get; set; }
        [Description("重定位表RVA", "X8")]
        public uint RelocationDirectoryRVA { get; set; }
        [Description("重定位表大小", "X8")]
        public uint RelocationDirectorySize { get; set; }
        [Description("调试表RVA", "X8")]
        public uint DebugDirectoryRVA { get; set; }
        [Description("调试表大小", "X8")]
        public uint DebugDirectorySize { get; set; }
        [Description("版权表RVA", "X8")]
        public uint ArchitectureDirectoryRVA { get; set; }
        [Description("版权表大小", "X8")]
        public uint ArchitectureDirectorySize { get; set; }
        [Description("全局指针表RVA", "X8")]
        public uint GlobalPtrDirectoryRVA { get; set; }
        [Description("全局指针表大小", "X8")]
        public uint GlobalPtrDirectorySize { get; set; }
        [Description("线程本地存储RVA", "X8")]
        public uint TLSDirectoryRVA { get; set; }
        [Description("线程本地存储大小", "X8")]
        public uint TLSDirectorySize { get; set; }
        [Description("加载配置表RVA", "X8")]
        public uint ConfigurationDirectoryRVA { get; set; }
        [Description("加载配置表大小", "X8")]
        public uint ConfigurationDirectorySize { get; set; }
        [Description("绑定导入表RVA", "X8")]
        public uint BoundImportDirectoryRVA { get; set; }
        [Description("绑定导入表大小", "X8")]
        public uint BoundImportDirectorySize { get; set; }
        [Description("IAT表RVA", "X8")]
        public uint IATDirectoryRVA { get; set; }
        [Description("IAT表大小", "X8")]
        public uint IATDirectorySize { get; set; }
        [Description("延迟导入表RVA", "X8")]
        public uint DelayDirectoryRVA { get; set; }
        [Description("延迟导入表大小", "X8")]
        public uint DelayDirectorySize { get; set; }
        [Description("CLR表RVA", "X8")]
        public uint NetMetaDataDirectoryRVA { get; set; }
        [Description("CLR表大小", "X8")]
        public uint NetMetaDataDirectorySize { get; set; }
        [Description("预留", "X8")]
        public uint Reserved1 { get; set; }
        [Description("预留", "X8")]
        public uint Reserved2 { get; set; }

        //public uint VirtualAddress { get; set; }
        //public uint Size { get; set; }
    }

}
