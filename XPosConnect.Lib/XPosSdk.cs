using System.Runtime.InteropServices;

namespace XPosConnect.Lib
{
    public class XPosSdk
    {
        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_init", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_init(int id, int mode);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_set_manufacturer_id", CallingConvention = CallingConvention.StdCall)]
        public static extern void mf_set_manufacturer_id(int id);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_connect", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_connect();

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_readPosInfo", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_readPosInfo(IntPtr posInfo);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_card_exec", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_card_exec(IntPtr param, IntPtr returnInfo);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_setKeyIndex", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_setKeyIndex(byte mainkeyindex);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_loadMasterkey", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_loadMasterkey(MFEU_MAINKEY_ENCRYPT type, byte mainkeyindex, byte[] key);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_loadworkkey", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_loadworkkey(byte mainkeyindex, byte[] pinKey, byte[] macKey, byte[] trackKey);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_aidManager", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_aidManager(MFEU_AID_ACTION action, string aid);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_pukManager", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_pukManager(MFEU_PUK_ACTION action, string puk);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_LoadDukpt", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_LoadDukpt(MFEU_DUKPT_TYPE type, byte mainKeyIndex, string key, string ksn, IntPtr returnInfo);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_setDatetime", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_setDatetime(string dateTime);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_showText", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_showText(byte timeOut, byte[] text, int len);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_showQrCode", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_showQrCode(byte timeOut, string qrCode);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_genQrCode", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_genQrCode(byte timeOut, byte[] qrCode, int len);

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_resetPos", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_resetPos();

        [DllImport("Lib/mpos_sdk.dll", EntryPoint = "mf_playAudio", CallingConvention = CallingConvention.StdCall)]
        public static extern int mf_playAudio(byte playType, byte playTimes, int playDelay);
    }
}
