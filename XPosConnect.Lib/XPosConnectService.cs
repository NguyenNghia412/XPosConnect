using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPosConnect.Lib.Dto.Communicate;
using XPosConnect.Lib.Dto.Sdk;

namespace XPosConnect.Lib
{
    public class XPosConnectService
    {
        private static bool isConnected = false;

        public XPosConnectService() {
            XPosSdk.mf_init(0, 0);
            ConnectDevice();
        }

        public ResultGenerateQrDto GenQrCode(ShowQrDto dto)
        {
            ConnectDevice();

            if (!isConnected)
            {
                return new ResultGenerateQrDto
                {
                    Success = false,
                    Message = "Không kết nối được thiết bị XPos",
                };
            }

            UTF8Encoding utf8 = new UTF8Encoding();

            string unicodeString = dto.Data ?? "";

            unicodeString += $"|{dto.Amount}";

            if (!string.IsNullOrEmpty(dto.Note))
            {
                unicodeString += $"|{dto.Note}";
            }

            Console.WriteLine("Full text:");
            Console.WriteLine(unicodeString);

            byte[] encodedBytes = utf8.GetBytes(unicodeString);

            int ret = XPosSdk.mf_genQrCode(30, encodedBytes, encodedBytes.Length);

            if (ret == 0)
            {
                Console.WriteLine("QR Showed Success");
                return new ResultGenerateQrDto
                {
                    Success = true,
                    Message = "success",
                };
            }
            else
            {
                return new ResultGenerateQrDto
                {
                    Success = false,
                    Message = "Không hiển thị được mã QR",
                };
            }
        }

        public ResultGenerateQrDto ShowText(ShowTextDto dto)
        {
            ConnectDevice();

            if (!isConnected)
            {
                return new ResultGenerateQrDto
                {
                    Success = false,
                    Message = "Không kết nối được thiết bị XPos",
                };
            }

            UTF8Encoding utf8 = new UTF8Encoding();

            string unicodeString = dto.Text;

            byte[] encodedBytes = utf8.GetBytes(unicodeString);

            int ret = XPosSdk.mf_showText(30, encodedBytes, encodedBytes.Length);

            if (ret == 0)
            {
                Console.WriteLine("Text Showed");
                return new ResultGenerateQrDto
                {
                    Success = true,
                    Message = "success",
                };
            }
            else
            {
                return new ResultGenerateQrDto
                {
                    Success = false,
                    Message = "Không hiển thị được text",
                };
            }
        }

        public void ConnectDevice()
        {
            int countTry = 0;
            int maxTry = 2;

            do
            {
                isConnected = XPosSdk.mf_connect() == 1;
                countTry++;
            }
            while (!isConnected && countTry < maxTry);
        }
    }
}
