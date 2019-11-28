using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml;
using System.IO;

namespace TestPos
{
    public partial class Form1 : Form
    {
        #region External Library

        [System.Runtime.InteropServices.DllImport("msvcrt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern uint _controlfp(uint a, uint b);

        [DllImport("IAE17.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void IAE17AX_GetVersion([MarshalAs(UnmanagedType.LPArray, SizeConst = 6)] byte[] sText);

        [DllImport("IAE17.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void IAE17AX_Free();

        [DllImport("IAE17.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void IAE17AX_SetTimeout(int timeout);

        [DllImport("IAE17.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int IAE17AX_Payment(ref TECRData ecrDatal, ref TPOSData posData2);

        [DllImport("IAE17.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int IAE17AX_Status(ref TECRData ecrDatal, ref TPOSData posData2);

        [DllImport("IAE17.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void IAE17AX_InitRS232(ref TCOMParameters comParameters);

        [DllImport("IAE17.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int IAE17AX_Closure(ref TECRData ecrDatal, ref TPOSData posData2);

        [DllImport("IAE17.dll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void IAE17AX_InitEth(ref TETHParameters tethParameters);


        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TPOSData
        {
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 + 1)]
            public byte[] TerminalId;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 11 + 1)]
            public byte[] AcquirerId;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 + 1)]
            public byte[] TransactionType;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 + 1)]
            public byte[] TransactionResult;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 24 + 1)]
            public byte[] KODescription;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] CardType;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 + 1)]
            public byte[] STAN;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 + 1)]
            public byte[] POSBalance;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 + 1)]
            public byte[] BankBalance;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 19 + 1)]
            public byte[] PAN;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 + 1)]
            public byte[] AuthorizationCode;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 + 1)]
            public byte[] OperationNumber;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 + 1)]
            public byte[] AmountAuth;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 + 1)]
            public byte[] PreauthorizationCode;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 + 1)]
            public byte[] ActionCode;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 + 1)]
            public byte[] DataTrs;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 + 1)]
            public byte[] AmountEcho;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096 + 1)]
            public byte[] Ticket;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 + 1)]
            public byte[] EsitoLetturaTrk2;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 40 + 1)]
            public byte[] Trk2;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 + 1)]
            public byte[] EsitoLetturaTrk1;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 254 + 1)]
            public byte[] Trk1;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] StatoPos;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 + 1)]
            public byte[] InfoRelease;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 255 + 1)]
            public byte[] DatiAggiuntiviDaGT;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TECRData
        {
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 + 1)]
            public byte[] Amount;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 + 1)]
            public byte[] ECRId;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] PaymentType;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 + 1)]
            public byte[] TerminalId;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 128 + 1)]
            public byte[] Contract;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 9 + 1)]
            public byte[] PreauthorizationCode;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 + 1)]
            public byte[] STAN;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] Ticket2Ecr;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] DatiAgg;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] TypeReprint;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] TipoStornoR;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 5 + 1)]
            public byte[] PANABI;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 11 + 1)]
            public byte[] IdAcquirer;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 10 + 1)]
            public byte[] DataStornoR;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 6 + 1)]
            public byte[] AuthorizationCode;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] DllType;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 + 1)]
            public byte[] DatiAggiuntiviIsoRisposta;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 + 1)]
            public byte[] DatiAggiuntiviTagRisposta;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 + 1)]
            public byte[] DatiAggiuntiviNumeroTag;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 100 + 1)]
            public byte[] DatiAggiuntiviTag1;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 100 + 1)]
            public byte[] DatiAggiuntiviTag2;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 100 + 1)]
            public byte[] DatiAggiuntiviTag3;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 100 + 1)]
            public byte[] DatiAggiuntiviTag4;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1 + 1)]
            public byte[] ExtendedPaymentType;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TCOMParameters
        {
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 5 + 1)]
            public byte[] COMPort;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] BaudRate;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] DataBits;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Parity;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] StopBits;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TETHParameters
        {
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 15 + 1)]
            public byte[] IPAddress;
            [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 5 + 1)]
            public byte[] Port;
        }

        #endregion

        private const string Test = "Empty bytes";

        private const string xsl =
  @"<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:pos=""tcpos"">
<xsl:strip-space elements=""*""/>
<xsl:output method=""html"" version=""4.0"" indent=""no""/>
<xsl:template name=""Transaction"">
</xsl:template>
</xsl:stylesheet>";

        TPOSData tposData = new TPOSData();
        TECRData ecrData = new TECRData();
        TETHParameters teth = new TETHParameters();
        TCOMParameters tcom = new TCOMParameters();

        uint _MCW_EW = 0x8001F;
        uint _EM_INVALID = 0x10;

        public void initStructure()
        {
            tposData.TerminalId = new byte[8 + 1];
            tposData.AcquirerId = new byte[11 + 1];
            tposData.TransactionType = new byte[3 + 1];
            tposData.TransactionResult = new byte[2 + 1];
            tposData.KODescription = new byte[24 + 1];
            tposData.CardType = new byte[1 + 1];
            tposData.STAN = new byte[6 + 1];
            tposData.POSBalance = new byte[16 + 1];
            tposData.BankBalance = new byte[16 + 1];
            tposData.PAN = new byte[19 + 1];
            tposData.AuthorizationCode = new byte[6 + 1];
            tposData.OperationNumber = new byte[6 + 1];
            tposData.AmountAuth = new byte[6 + 1];
            tposData.PreauthorizationCode = new byte[6 + 1];
            tposData.ActionCode = new byte[3 + 1];
            tposData.DataTrs = new byte[7 + 1];
            tposData.AmountEcho = new byte[8 + 1];
            tposData.Ticket = new byte[4096 + 1];
            tposData.EsitoLetturaTrk2 = new byte[3 + 1];
            tposData.Trk2 = new byte[40 + 1];
            tposData.EsitoLetturaTrk1 = new byte[3 + 1];
            tposData.Trk1 = new byte[254 + 1];
            tposData.StatoPos = new byte[1 + 1];
            tposData.InfoRelease = new byte[64 + 1];
            tposData.DatiAggiuntiviDaGT = new byte[255 + 1];

            ecrData.Amount = new byte[8 + 1];
            ecrData.ECRId = new byte[8 + 1];
            ecrData.PaymentType = new byte[1 + 1];
            ecrData.TerminalId = new byte[8 + 1];
            ecrData.Contract = new byte[128 + 1];
            ecrData.PreauthorizationCode = new byte[9 + 1];
            ecrData.STAN = new byte[6 + 1];
            ecrData.Ticket2Ecr = new byte[1 + 1];
            ecrData.DatiAgg = new byte[1 + 1];
            ecrData.TypeReprint = new byte[1 + 1];
            ecrData.TipoStornoR = new byte[1 + 1];
            ecrData.PANABI = new byte[5 + 1];
            ecrData.IdAcquirer = new byte[11 + 1];
            ecrData.DataStornoR = new byte[10 + 1];
            ecrData.AuthorizationCode = new byte[6 + 1];
            ecrData.DllType = new byte[1 + 1];
            ecrData.DatiAggiuntiviIsoRisposta = new byte[2 + 1];
            ecrData.DatiAggiuntiviTagRisposta = new byte[8 + 1];
            ecrData.DatiAggiuntiviNumeroTag = new byte[4 + 1];
            ecrData.DatiAggiuntiviTag1 = new byte[100 + 1];
            ecrData.DatiAggiuntiviTag2 = new byte[100 + 1];
            ecrData.DatiAggiuntiviTag3 = new byte[100 + 1];
            ecrData.DatiAggiuntiviTag4 = new byte[100 + 1];
            ecrData.ExtendedPaymentType = new byte[1 + 1];

            tcom.COMPort = new byte[5 + 1];
            tcom.BaudRate = new byte[1];
            tcom.DataBits = new byte[1];
            tcom.Parity = new byte[1];
            tcom.StopBits = new byte[1];

            teth.IPAddress = new byte[15 + 1];
            teth.Port = new byte[5 + 1];
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void EncodeStringValueInField(String value, ref byte[] field)
        {
            byte[] Temp = System.Text.Encoding.UTF8.GetBytes(value);
            Temp.CopyTo(field, 0);
        }

        private void _btnTransazione_Click(object sender, EventArgs e)
        {
            initStructure();

            EncodeStringValueInField("00000001", ref ecrData.Amount);
            EncodeStringValueInField("0", ref ecrData.PaymentType);
            EncodeStringValueInField("09800355", ref ecrData.TerminalId);
            EncodeStringValueInField("00000000", ref ecrData.ECRId);

            try
            {
                EncodeStringValueInField(IP.Text, ref teth.IPAddress);
                EncodeStringValueInField(Porta.Text, ref teth.Port);

                _controlfp(_MCW_EW, _EM_INVALID);
                IAE17AX_InitEth(ref teth);

                int c = IAE17AX_Status(ref ecrData, ref tposData);

                int i = IAE17AX_Payment(ref ecrData, ref tposData);
                IAE17AX_Free();
                _controlfp(_MCW_EW, _EM_INVALID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }

            /*
            // In seriale
            initStructure();

            EncodeStringValueInField("COM1", ref tcom.COMPort);

            tcom.BaudRate[0] = (byte)4;  // #define IAE_br9600  4
            tcom.DataBits[0] = (byte)1;  // #define IAE_db8BITS 1
            tcom.Parity[0] = (byte)0;    // #define IAE_sb1BITS 0
            tcom.StopBits[0] = (byte)1;  // #define IAE_ptNONE  0

            try
            {
                _controlfp(_MCW_EW, _EM_INVALID);
                IAE17AX_InitRS232(ref tcom);

                int c = IAE17AX_Status(ref ecrData, ref tposData);

                int i = IAE17AX_Payment(ref ecrData, ref tposData);
                IAE17AX_Free();
                _controlfp(_MCW_EW, _EM_INVALID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }
            */
        }

        private void btnChiusura_Click(object sender, EventArgs e)
        {

            initStructure();

            try
            {
                EncodeStringValueInField(IP.Text, ref teth.IPAddress);
                EncodeStringValueInField(Porta.Text, ref teth.Port);

                _controlfp(_MCW_EW, _EM_INVALID);
                IAE17AX_InitEth(ref teth);
                _controlfp(_MCW_EW, _EM_INVALID);

                EncodeStringValueInField("09800355", ref ecrData.TerminalId);
                EncodeStringValueInField("00000000", ref ecrData.ECRId);

                _controlfp(_MCW_EW, _EM_INVALID);
                int i = IAE17AX_Closure(ref ecrData, ref tposData);
                IAE17AX_Free();
                _controlfp(_MCW_EW, _EM_INVALID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint _MCW_EW = 0x8001F;
            uint _EM_INVALID = 0x10;

            initStructure();
            EncodeStringValueInField(IP.Text, ref teth.IPAddress);
            EncodeStringValueInField(Porta.Text, ref teth.Port);
            try
            {

                _controlfp(_MCW_EW, _EM_INVALID);
                IAE17AX_InitEth(ref teth);
                int c = IAE17AX_Status(ref ecrData, ref tposData);
                _controlfp(_MCW_EW, _EM_INVALID);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Reset();
                settings.ProhibitDtd = false;
                settings.CheckCharacters = false;
                settings.CloseInput = true;


                XslCompiledTransform xslt = null;
                StringReader XLSStringRdr = new StringReader(xsl);
                XmlReader xslReader = XmlReader.Create(XLSStringRdr, settings);
                xslt = new XslCompiledTransform();
                xslt.Load(xslReader);
                xslReader.Close();
                xslReader = null;
                xslt = null;
                MessageBox.Show("OK - nessuna eccezione");

                _controlfp(_MCW_EW, _EM_INVALID);
                IAE17AX_Free();
                _controlfp(_MCW_EW, _EM_INVALID);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }
        }
    }
/*        {

            int Retries = 0;
            byte[] Version = { 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37 };

            string localXsl =   @"<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:pos=""tcpos"">
                                <xsl:strip-space elements=""*""/>
                                <xsl:output method=""html"" version=""4.0"" indent=""no""/>
                                <xsl:template name=""Transaction"">
                                </xsl:template>
                                </xsl:stylesheet>";

            try
            {
            Retry:

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Reset();
                settings.ProhibitDtd = false;
                settings.CheckCharacters = false;
                settings.CloseInput = true;
                XslCompiledTransform xslt = null;
                XmlReader xslReader = null;
                StringReader XLSStringRdr = new StringReader(localXsl);
                xslReader = XmlReader.Create(XLSStringRdr,settings);
                xslt = new XslCompiledTransform();
                xslt.Load(xslReader);
                xslReader.Close();
                xslReader = null;
                xslt = null;


                _controlfp(_MCW_EW, _EM_INVALID);

                IAE17AX_GetVersion(Version);
                IAE17AX_Free();

                _controlfp(_MCW_EW, _EM_INVALID);

                MessageBox.Show("DLL:" + Encoding.UTF8.GetString(Version, 0, Version.Length));

            }catch (Exception ex){
                MessageBox.Show("Exception:" + ex.Message);
            }
        }

    }*/


}
